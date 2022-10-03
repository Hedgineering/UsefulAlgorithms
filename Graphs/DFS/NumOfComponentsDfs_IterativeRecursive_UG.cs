using System;
using System.Collections.Generic;

namespace Hedgineering.Algorithms.Graphs.DFS;

/**
 * This is to count # of components (islands) via a DFS for an unweighted undirected graph.
 * It is implemented with an adjacency list.
 * It contains both iterative and recursive implementations.
 * Made in parallel to : https://youtu.be/tWVWeAqZ0WU
 * Similar to : ../BFS/NumOfComponentsBfs_Iterative_UG.cs
 */
 public class NumOfComponentsDfs_IterativeRecursive_UG {
  public static void Main() {
    Dictionary<int, List<int>> graph = new();
    graph.Add(0, new List<int>() {8,1,5});
    graph.Add(1, new List<int>() {0});
    graph.Add(5, new List<int>() {0,8});
    graph.Add(8, new List<int>() {0,5});
    graph.Add(2, new List<int>() {3,4});
    graph.Add(3, new List<int>() {2,4});
    graph.Add(4, new List<int>() {3,2});

    // ====================================================================================
    // DFS - Depth First Search - Use Stack ; Adjacency List Graph Implementation
    // ====================================================================================
    Console.WriteLine(NumOfComponentsDfsRecursive(graph)); // 2
    Console.WriteLine(NumOfComponentsDfsIterative(graph)); // 2
  }

  public static int NumOfComponentsDfsRecursive(Dictionary<int, List<int>> graph) {
    HashSet<int> visited = new();
    int count = 0;
    foreach(int node in graph.Keys) {
      /**
       * Explore returns true after exploring all the nodes in a component
       * If it encounters an alredy visited node, you can't consider that 
       * the starting point of a new component to explore
       * It marks all nodes of a component as visited while exploring, so
       * each component is only explored once
       */
      if(Explore(node, graph, visited)) count++;
    }

    return count;
  }

  // Recursive runner for DFS
  private static bool Explore(int node, Dictionary<int, List<int>> graph, HashSet<int> visited) {
    // A visited node cannot be the starting point of a new 
    // component (island) to explore
    if(visited.Contains(node)) return false;

    // DFS Process, mark current node as visited if it's a valid start
    visited.Add(node);

    // Explore all neighbors, marking them as visited
    foreach(int neighbor in graph[node]) {
      Explore(neighbor, graph, visited);
    }

    // Component is fully explored, return true
    return true;
  }

  public static int NumOfComponentsDfsIterative(Dictionary<int, List<int>> graph) {
    HashSet<int> visited = new();
    Stack<int> s = new();
    int count = 0;

    foreach(int node in graph.Keys) {
      if(visited.Contains(node)) continue;

      // DFS
      s.Clear();
      s.Push(node);

      // Explore component via dfs
      while(s.Count > 0) {
        // Get current
        int curr = s.Pop();
        // Mark as visited
        visited.Add(curr);
        // Prep all neighbors for processing
        foreach(int neighbor in graph[curr]) {
          if(!visited.Contains(neighbor)) s.Push(neighbor);
        }
      }

      // Increment explored components
      count++;
    }

    return count;
  }
}