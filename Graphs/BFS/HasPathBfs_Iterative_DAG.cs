using System;
using System.Collections.Generic;

namespace Hedgineering.Algorithms.Graphs.BFS;

/**
 * This is to see if a path exists via a BFS for an unweighted directed acyclic graph.
 * It is implemented with an adjacency list.
 * It contains only an iterative implementation.
 * Made in parallel to : https://youtu.be/tWVWeAqZ0WU
 * Similar to : ../DFS/HasPathDfs_IterativeRecursive_DAG.cs
 */
 public class HasPathDfs_IterativeRecursive_DAG {
  public static void Main() {
    Dictionary<char, List<char>> graph = new();
    graph.Add('f', new List<char>() { 'g', 'i' });
    graph.Add('g', new List<char>() { 'h' });
    graph.Add('h', new List<char>());
    graph.Add('i', new List<char>() { 'g', 'k' });
    graph.Add('j', new List<char>() { 'i' });
    graph.Add('k', new List<char>());

    // ======================================================================================
    // BFS - Breadth First Search - Use Queue & Visited ; Adjacency List Graph Implementation
    // ======================================================================================
    Console.WriteLine(HasPathBfsIterative('f', 'k', graph)); // true
    Console.WriteLine(HasPathBfsIterative('f', 'j', graph)); // false
  }

  public static bool HasPathBfsIterative(char source, char destination, Dictionary<char, List<char>> graph) {
    if(source == destination) return true;

    Queue<char> q = new();
    q.Enqueue(source);

    while(q.Count > 0) {
      char curr = q.Dequeue();

      // process
      if(curr == destination) return true;

      // queue neighbors for processing in future iterations
      foreach(char neighbor in graph[curr]) {
        q.Enqueue(neighbor);
      }
    }

    return false;
  }
}