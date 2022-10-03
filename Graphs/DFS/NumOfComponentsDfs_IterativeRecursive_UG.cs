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
}