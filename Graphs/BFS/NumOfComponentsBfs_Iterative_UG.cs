using System;
using System.Collections.Generic;

namespace Hedgineering.Algorithms.Graphs.BFS;

/**
 * This is to count # of components (islands) via a BFS for an unweighted undirected graph.
 * It is implemented with an adjacency list.
 * It contains only an iterative implementation.
 * Made in parallel to : https://youtu.be/tWVWeAqZ0WU
 * Similar to : ../DFS/NumOfComponentsDfs_IterativeRecursive_UG.cs
 */
 public class NumOfComponentsBfs_Iterative_UG {
  public static void Main() {
    Dictionary<int, List<int>> graph = new();
    graph.Add(0, new List<int>() {8,1,5});
    graph.Add(1, new List<int>() {0});
    graph.Add(5, new List<int>() {0,8});
    graph.Add(8, new List<int>() {0,5});
    graph.Add(2, new List<int>() {3,4});
    graph.Add(3, new List<int>() {2,4});
    graph.Add(4, new List<int>() {3,2});

    // ======================================================================================
    // BFS - Breadth First Search - Use Queue & Visited ; Adjacency List Graph Implementation
    // ======================================================================================
    Console.WriteLine(NumOfComponentsBfsIterative(graph)); // 2
  }

  public static int NumOfComponentsBfsIterative(Dictionary<int, List<int>> graph) {
    HashSet<int> visited = new();
    Queue<int> q = new();
    int count = 0;

    foreach(int node in graph.Keys) {
      // A visited node cannot be the starting point of a new 
      // component (island) to explore
      if(visited.Contains(node)) continue;

      // BFS
      q.Clear();
      q.Enqueue(node);

      // Explore component via bfs
      while(q.Count > 0) {
        // Get current
        int curr = q.Dequeue();
        // Mark as visited
        visited.Add(curr);
        // Prep all neighbors for processing
        foreach(int neighbor in graph[curr]) {
          if(!visited.Contains(neighbor)) q.Enqueue(neighbor);
        }
      }

      // Increment explored components
      count++;
    }

    return count;
  }
}