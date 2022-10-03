using System;
using System.Collections.Generic;

namespace Hedgineering.Algorithms.Graphs.DFS;

/**
 * This is to print all nodes via a DFS for an unweighted directed graph.
 * It is implemented with an adjacency list.
 * It contains both iterative and recursive implementations.
 * Made in parallel to : https://youtu.be/tWVWeAqZ0WU
 * Similar to : ../DFS/DfsPrint_IterativeRecursive_AdjListGraph.cs
 */
public class DfsPrint_IterativeRecursive_AdjListGraph {
  public static void Main() {
    Dictionary<char, List<char>> graph = new();
    graph.Add('a', new List<char>() { 'c', 'b' });
    graph.Add('b', new List<char>() { 'd', 'a' });
    graph.Add('c', new List<char>() { 'e' });
    graph.Add('d', new List<char>() { 'f' });
    graph.Add('e', new List<char>());
    graph.Add('f', new List<char>());

    // ====================================================================================
    // DFS - Depth First Search - Use Stack & Visited ; Adjacency List Graph Implementation
    // ====================================================================================
    Console.WriteLine("Iterative DFS starting at 'a'");
    DfsIterativePrint('a', graph); // abdfce

    Console.WriteLine("\nRecursive DFS starting at 'a'");
    Dictionary<char, bool> visited = new();
    DfsRecursivePrint('a', graph, visited); // acebdf
  }

  // Use stack, will visit the last neighbor from adjlist first (LIFO),
  // process on pop, add neighbors to stack, repeat while stack not empty
  public static void DfsIterativePrint(char source, Dictionary<char, List<char>> graph) {
    Dictionary<char, bool> visited = new(); // so we don't visit same node twice
    Stack<char> stack = new();
    stack.Push(source);

    // Iterate until stack is empty
    while (stack.Count != 0) {
      // Get current node
      char curr = stack.Pop();

      // Handle Visited Checks
      if (visited.ContainsKey(curr) && visited[curr]) continue; // don't process if already visited
      visited[curr] = true; // mark as visited

      // Process current node
      Console.WriteLine(curr);

      // Handle Neighbors
      foreach (char c in graph[curr]) {
        stack.Push(c);
      }
    }
  }

  // Recurse while not visited, it will visit the first neighbor in adjlist first
  // uses recursive stack frame as the stack and base case on visited = true if cyclic or on 
  // lack of neighbors if acyclic
  public static void DfsRecursivePrint(char source, Dictionary<char, List<char>> graph, Dictionary<char, bool> visited) {
    // Check & Update Visited to avoid cycles
    if (visited.ContainsKey(source) && visited[source]) return;
    visited[source] = true;

    // Process current (akin to process on pop for iterative with stack)
    Console.WriteLine(source);

    // Handle Neighbors
    foreach (char c in graph[source]) {
      DfsRecursivePrint(c, graph, visited);
    }
  }
}