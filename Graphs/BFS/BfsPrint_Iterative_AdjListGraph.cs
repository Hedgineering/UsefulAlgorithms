using System;
using System.Collections.Generic;

namespace Hedgineering.Algorithms.Graphs.BFS;

/**
 * This is a BFS for an unweighted directed graph.
 * It is implemented with an adjacency list.
 * It contains both iterative and recursive implementations.
 */
public class BfsPrint_Iterative_AdjListGraph {
  public static void Main() {
    Dictionary<char, List<char>> graph = new();
    graph.Add('a', new List<char>() { 'c', 'b' });
    graph.Add('b', new List<char>() { 'd', 'a' });
    graph.Add('c', new List<char>() { 'e' });
    graph.Add('d', new List<char>() { 'f' });
    graph.Add('e', new List<char>());
    graph.Add('f', new List<char>());

    // ======================================================================================
    // BFS - Breadth First Search - Use Queue & Visited ; Adjacency List Graph Implementation
    // ======================================================================================
    Console.WriteLine("Iterative BFS starting at 'a'");
    BfsIterativePrint('a', graph); // acbedf
  }

  // Use queue, will visit the first neighbor from adjlist first (FIFO),
  // process on dequeue, add neighbors to queue, repeat while queue not empty
  public static void BfsIterativePrint(char source, Dictionary<char, List<char>> graph) {
    Dictionary<char, bool> visited = new(); // so we don't visit same node twice
    Queue<char> queue = new();
    queue.Enqueue(source);

    // Iterate until queue is empty
    while (queue.Count != 0) {
      // Get current node
      char curr = queue.Dequeue();

      // Handle Visited Checks
      if (visited.ContainsKey(curr) && visited[curr]) continue; // don't process if already visited
      visited[curr] = true; // mark as visited

      // Process current node
      Console.WriteLine(curr);

      // Handle Neighbors
      foreach (char c in graph[curr]) {
        queue.Enqueue(c);
      }
    }
  }
}