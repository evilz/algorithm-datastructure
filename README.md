# algorithm-datastructure

algorithm and data structure


## O-Notation

| Complexity | Example                                                                    |
|------------|----------------------------------------------------------------------------|
| O(1)       | Fetching the first element from a set of data                              |
| O(lg n)    | Splitting a set of data in half, then splitting the halves in half, etc.   |
| O(n)       | Traversing a set of data                                                   |
| O(n lg n)  | Splitting a set of data in half repeatedly and traversing each half        |
| O(n2)      | Traversing a set of data once for each member of another set of equal size |
| O(2n)      | Generating all possible subsets of a set of data                           |
| O(n!)      | Generating all possible permutations of a set of data                      |


Sample :

|           |   n = 1   |   n = 16  |  n = 256  |   n = 4K  |  n = 64K  |   n = 1M  |
|-----------|:---------:|:---------:|:---------:|:---------:|:---------:|:---------:|
| O(1)      | 1.000E+00 | 1.000E+00 | 1.000E+00 | 1.000E+00 | 1.000E+00 | 1.000E+00 |
| O(lg n)   | 0.000E+00 | 4.000E+00 | 8.000E+00 | 1.200E+01 | 1.600E+01 | 2.000E+01 |
| O(n)      | 1.000E+00 | 1.600E+01 | 2.560E+02 | 4.096E+03 | 6.554E+04 | 1.049E+06 |
| O(n lg n) | 0.000E+00 | 6.400E+01 | 2.048E+03 | 4.915E+04 | 1.049E+06 | 2.097E+07 |
| O(n2)     | 1.000E+00 | 2.560E+02 | 6.554E+04 | 1.678E+07 | 4.295E+09 | 1.100E+12 |
| O(2n)     | 2.000E+00 | 6.554E+04 | 1.158E+77 |     —     |     —     |     —     |
| O(n!)     | 1.000E+00 | 2.092E+13 |     —     |     —     |     —     |     —     |


# Data Structures

## .net framework Data structure

|                  | Internal Implement- ation                                 | Add/insert                             | Add beyond capacity | Queue/Push | Dequeue/Pop/Peek | Remove/ RemoveAt              | Item[index]/ElementAt(index) | GetEnumerator | Contains(value)/IndexOf/ContainsValue/Find |
|------------------|-----------------------------------------------------------|----------------------------------------|---------------------|------------|------------------|-------------------------------|------------------------------|---------------|--------------------------------------------|
| List             | Array                                                     | O(1) to add, O(n) to insert            | O(n)                | -          | -                | O(n)                          | O(1)                         | O(1)          | O(n)                                       |
| LinkedList       | Doubly linked list                                        | O(1), before/after given node          | O(1)                | O(1)       | O(1)             | O(1), before/after given node | O(n)                         | O(1)          | O(n)                                       |
| Stack            | Array                                                     | O(1)                                   | O(n)                | O(1)       | O(1)             | -                             | -                            | O(1)          | O(n)                                       |
| Queue            | Array                                                     | O(1)                                   | O(n)                | O(1)       | O(1)             | -                             | -                            | O(1)          | O(n)                                       |
| Dictionary       | Hashtable with links to another array index for collision | O(1), O(n) if collision                | O(n)                | -          | -                | O(1), O(n) if collision       | O(1), O(n) if collision      | O(1)          | O(n)                                       |
| HashSet          | Hashtable with links to another array index for collision | O(1), O(n) if collision                | O(n)                | -          | -                | O(1), O(n) if collision       | O(1), O(n) if collision      | O(1)          | -                                          |
| SortedDictionary | Red-black tree                                            | O(log n)                               | O(log n)            | -          | -                | O(log n)                      | O(log n)                     | O(log n)      | O(n)                                       |
| SortedList       | Array                                                     | O(n), O(log n) if added to end of list | O(n)                | -          | -                | O(n)                          | O(log n)                     | O(1)          | O(n)                                       |
| SortedSet        | Red-black tree                                            | O(log n)                               | O(log n)            | -          | -                | O(log n)                      | O(log n)                     | O(log n)      | -                                          |

## Set

- Union Find : :white_medium_square:

## Collection
- Deque :white_medium_square:
- RandomizedQueue  :white_medium_square:


# Algorithms

- GraphTraversal
  - [BreadthFirstSearch](src/Algorithms/GraphTraversal/BreadthFirstSearch.cs)
  - [DepthFirstSearch](src/Algorithms/GraphTraversal/DepthFirstSearch.cs)
  - [GreedyBestFirstSearch](src/Algorithms/GraphTraversal/GreedyBestFirstSearch.cs)
  - [Dijkstra](src/Algorithms/GraphTraversal/Dijkstra.cs)
  - [AStar](src/Algorithms/GraphTraversal/AStar.cs)


### DFS Console visualizer

![](https://raw.githubusercontent.com/evilz/algorithm-datastructure/master/DFS-Visualizer.gif)
