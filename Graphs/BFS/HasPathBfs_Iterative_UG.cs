using System;
using System.Collections.Generic;

namespace Hedgineering.Algorithms.Graphs.BFS;

/**
 * This is to see if a path exists via a BFS for an unweighted undirected graph.
 * It is implemented with an adjacency list. Processes edge list into adjacency list.
 * It contains only an iterative implementation.
 * Made in parallel to : https://youtu.be/tWVWeAqZ0WU
 * Similar to : ../DFS/HasPathDfs_IterativeRecursive_UG.cs
 */
 public class HasPathDfs_IterativeRecursive_DAG {
  public static void Main() {
    List<List<char>> edges = new() {
      new() {'i', 'j'},
      new() {'k', 'i'},
      new() {'m', 'k'},
      new() {'k', 'l'},
      new() {'o', 'n'},
    };

    // ======================================================================================
    // BFS - Breadth First Search - Use Queue & Visited ; Edge List -> Adjacency List Graph Implementation
    // ======================================================================================

   /**
    * Convert edge list to more convenient adj list representation
    * 1. Create key for each pair, value being empty list if not already existing
    * 2. Add each pair to other's list
    */

    // node -> neighbors
    Dictionary<char, List<char>> graph = new();
    foreach(List<char> pair in edges) {
      char a = pair[0], b = pair[1];
      
      if(!graph.ContainsKey(a)) graph[a] = new List<char>();
      if(!graph.ContainsKey(b)) graph[b] = new List<char>();

      graph[a].Add(b);
      graph[b].Add(a);
    }

    Console.WriteLine(HasPathBfsIterative('j', 'm', graph)); // true
    Console.WriteLine(HasPathBfsIterative('o', 'i', graph)); // false
  }

  public static bool HasPathBfsIterative(char source, char destination, Dictionary<char, List<char>> graph) {
    if(source == destination) return true; // found path

    HashSet<char> visited = new(); // prevent cycles inf loops
    Queue<char> q = new(); // BFS

    q.Enqueue(source);

    while(q.Count > 0) {
      char curr = q.Dequeue();

      // process
      if(curr == destination) return true; // found path
      if(visited.Contains(curr)) continue; // found cycle, no path in inf cycle

      visited.Add(curr); // mark since we're visiting it now

      // prep for next iteration
      foreach(char neighbor in graph[curr]) {
        if(!visited.Contains(neighbor)) q.Enqueue(neighbor);
      }
    }

    return false;
  }
}