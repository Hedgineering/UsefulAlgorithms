using System;
using System.Collections.Generic;

namespace Hedgineering.Algorithms.Graphs.DFS;

/**
 * This is to see if a path exists via a DFS for an unweighted directed acyclic graph.
 * It is implemented with an adjacency list.
 * It contains both iterative and recursive implementations.
 * Made in parallel to : https://youtu.be/tWVWeAqZ0WU
 * Similar to : ../BFS/HasPathBfs_Iterative_DAG.cs
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

    // ====================================================================================
    // DFS - Depth First Search - Use Stack ; Adjacency List Graph Implementation
    // ====================================================================================
    Console.WriteLine(HasPathDfsRecursive('f', 'k', graph)); // true
    Console.WriteLine(HasPathDfsRecursive('j', 'f', graph)); // false

    Console.WriteLine(HasPathDfsIterative('f', 'k', graph)); // true
    Console.WriteLine(HasPathDfsIterative('f', 'j', graph)); // false
  }

  /**
   * Use call stack, check current node, then check neighbors, repeat until stack empty
   * If found, pass the found flag up the stack
   * If not found, terminate this search path by returning false
   */
  public static bool HasPathDfsRecursive(char source, char destination, Dictionary<char, List<char>> graph) {
    // if source is destination, return true
    if(source == destination) return true;

    // check neighbors for path
    foreach(char c in graph[source]) {
      if(HasPathDfsRecursive(c, destination, graph)) return true;
    }

    // if can't find a path via neighbors, return false
    return false;
  }

  /**
   * Use stack, check current node, then check neighbors, repeat until stack empty
   * If found, return true, else return false (when stack is empty)
   */
  public static bool HasPathDfsIterative(char source, char destination, Dictionary<char, List<char>> graph) {
    if(source == destination) return true;

    Stack<char> stack = new();
    HashSet<char> visited = new();

    stack.Push(source);

    // while stack is not empty
    while(stack.Count > 0) {
      char current = stack.Pop();
      if(current == destination) return true;

      // if current is not visited, we mark it as visited and stack up it's neighbors to be checked
      if(!visited.Contains(current)) {
        visited.Add(current);

        foreach(char c in graph[current]) {
          stack.Push(c);
        }
      }
    }

    // if can't find a path via neighbors, return false
    return false;
  }
}