using System;
using System.Collections.Generic;

namespace Hedgineering.Algorithms.Graphs.DFS;

/**
 * This is a DFS for a weighted directed graph
 * 
 * Implementation: 
 *   Node of some type T, 
 *   Edges with startNode, endNode, and weight
 *   Graph represented with an adjacency matrix such that matrix[startNode][endNode] = weight
 */
public class Node<T> {
  public T value;
}

public class Edge<T, U> where U : IComparable<U> {
  Node<T> start;
  Node<T> end;
  U weight;
}