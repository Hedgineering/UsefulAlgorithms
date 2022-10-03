using System;
using System.Collections.Generic;

namespace Hedgineering.Algorithms.Graphs.DFS;

/**
 * This is to see if a path exists via a DFS for an unweighted undirected graph.
 * It is implemented with an adjacency list. Processes edge list into adjacency list.
 * It contains both iterative and recursive implementations.
 * Made in parallel to : https://youtu.be/tWVWeAqZ0WU
 * Similar to : ../BFS/HasPathBfs_Iterative_UG.cs
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

    // ====================================================================================
    // DFS - Depth First Search - Use Stack ; Edge List -> Adjacency List Graph Implementation
    // ====================================================================================

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

    // Need a visited set to ensure we don't end up in infinite loop
    HashSet<char> visited = new();
    Console.WriteLine(HasPathDfsRecursive('j', 'm', graph, visited)); // true
    Console.WriteLine(HasPathDfsRecursive('i', 'o', graph, visited)); // false

    Console.WriteLine(HasPathDfsIterative('j', 'm', graph)); // true
    Console.WriteLine(HasPathDfsIterative('o', 'i', graph)); // false
  }

  public static bool HasPathDfsRecursive(char source, char destination, Dictionary<char, List<char>> graph, HashSet<char> visited) {
    if(source == destination) return true; // found path
    if(visited.Contains(source)) return false; // cycle found, no path to destination

    // mark as visited since we're processing it now
    visited.Add(source);

    foreach(char neighbor in graph[source]) {
      // check for path via neighbor, and if one neighbor works then break out
      // and pass the path found up through call stack, else continue checking
      // rest of neighbors
      if(HasPathDfsRecursive(neighbor, destination, graph, visited)) return true;
    }

    // checked all neighbors, and path was not found
    return false;
  }

  public static bool HasPathDfsIterative(char source, char destination, Dictionary<char, List<char>> graph) {
    if(source == destination) return true; // found path

    HashSet<char> visited = new();
    Stack<char> s = new();
    s.Push(source);

    while(s.Count > 0) {
      // get current
      char curr = s.Pop();

      // process
      if(curr == destination) return true; // found path
      if(visited.Contains(curr)) continue; // cycle found, no path to destination
      visited.Add(curr);

      // prep for next iteration
      foreach(char neighbor in graph[curr]) {
        s.Push(neighbor);
      }
    }

    return false;
  }
}