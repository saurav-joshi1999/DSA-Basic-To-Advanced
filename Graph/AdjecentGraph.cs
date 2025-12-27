using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

public static class AdjacentListGraph
{
    public static void mainn()
    {
        // List<List<int>> graph = new List<List<int>> { new List<int> { 2,3}, new List<int> {1, 5,6},
        // new List<int> {1,4,7}, new List<int> { 3,8}, new List<int> { 2}, new List<int> { 2},  new List<int> { 3,8},
        // new List<int> { 7,4} };

        // List<List<int>> graph2 = new List<List<int>> { new List<int> { 2,3}, new List<int> { 1,5}, new List<int> { 1,4, 6},
        //  new List<int> { 3}, new List<int> { 2}, new List<int> { 3, 7}, new List<int> { 6 }};

        // List<int> bfs = BFSotLevelOrderTraversal(graph);
        // System.Console.WriteLine("BFS : " + string.Join(", ", bfs));

        // List<int> dfs = new List<int>();
        // bool[] isVisited = new bool[graph.Count + 1];
        // GraphDFS(graph, isVisited, 1, dfs);
        // System.Console.WriteLine("DFS : " + string.Join(", ", dfs));

        // System.Console.WriteLine("IsLoopExits : " + DetectCycleInGraph(graph));

        // List<List<int>> bipartite = new List<List<int>> { new List<int> { 2}, new List<int> { 1,3,6}, new List<int> { 2,4},
        //  new List<int> { 3,5,7}, new List<int> { 4,6}, new List<int> { 2, 5}, new List<int> { 4,8 }, new List<int> { 7 }};
        // int[] color = Enumerable.Repeat(-1, 8).ToArray();
        // System.Console.WriteLine("isPartiteGraph : " + isBiPartiteGraph(bipartite));
        // int[] color1 = Enumerable.Repeat(-1, 8).ToArray();
        // System.Console.WriteLine("isPartiteGraph using DFS : " + isBiPartiteGraph(bipartite, 1, 0, color1));
        // List<List<int>> directGraph = new List<List<int>> { new List<int> { 2 }, new List<int> { 3 },
        // new List<int> { 7,4 }, new List<int> { 5 }, new List<int> { 6 }, new List<int> {  }, new List<int> { 5 },
        // new List<int> { 2, 9 }, new List<int> { 10 }, new List<int> { 8 }};
        // System.Console.WriteLine("Detect Cycle in Directed using DFS : "+ DetectCycleInDirectedGraphDFS(directGraph));
        //TopologicalSortingDAG();
        // List<List<int>> dG = new List<List<int>> { new List<int> {  },new List<int> {  }, new List<int> { 3 }, new List<int> { 1 },
        // new List<int> { 0,1 }, new List<int> { 0,2 },};
        //System.Console.WriteLine("Topo Using kahn's : "+ string.Join(", ",KahnAlgorithem(dG)));
        // List<List<int>> DirectCyclicGraph = new List<List<int>> {
        // new List<int> { 1 }, new List<int> { 2 },new List<int> { 3,4 },
        // new List<int> { 4,5 }, new List<int> { 6 },new List<int> { 6 },
        // new List<int> { 7 }, new List<int> {  }, new List<int> { 1,9 }, new List<int> { 10 },
        // new List<int> { 8 }, new List<int> { 9 }
        // }; 
        // SafeStateUsingTopologicalSort(DirectCyclicGraph);

        //string[] alienDic = { "baa", "abcd", "abca", "cab", "cad" };
        //ALienDictionary(alienDic, alienDic.Length, 4);
        List<List<KeyValuePair<int, int>>> keyValuesGraph = new List<List<KeyValuePair<int, int>>>
        {
            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (1,2) },
            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (3,1) },
            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (3,3) },
            new List<KeyValuePair<int, int>> {  },
            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (0,3), new KeyValuePair<int, int> (2,1) },
            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (4,1) },
            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (4,2), new KeyValuePair<int, int> (5,3) },
        };
        //ShortestPathFromEnd(keyValuesGraph);
        List<List<int>> DirectCyclicGraph = new List<List<int>> {
        new List<int> { 1,3 }, new List<int> {0, 2,3 },new List<int> { 1,6 },
        new List<int> { 0,4 }, new List<int> { 3,5 },new List<int> { 4,6 },
        new List<int> { 2,5,7,8 }, new List<int> { 6,8 }, new List<int> { 6,7 }
        };
        //ShortestPathInDCG(DirectCyclicGraph, 0);
        //int step = MinimumOperationFromStartToTarget("der", "dfs", new string[] { "des", "der", "dfr", "dgt", "dfs" });
        //System.Console.WriteLine("Maxi Mum Step to reach Target : "+ step);
        List<List<KeyValuePair<int, int>>> keyValuesGraph1 = new List<List<KeyValuePair<int, int>>>
        {
            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (1,4), new KeyValuePair<int, int> (2,4) },
            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (2,2), new KeyValuePair<int, int> (0,4) },

            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (0,4), new KeyValuePair<int, int> (1,2),
            new KeyValuePair<int, int> (3,3), new KeyValuePair<int, int> (4,1), new KeyValuePair<int, int> (5,6) },

            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (2,3), new KeyValuePair<int, int> (5,2) },

            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (2,1), new KeyValuePair<int, int> (5,3) },
            new List<KeyValuePair<int, int>> { new KeyValuePair<int, int> (3,2), new KeyValuePair<int, int> (2,6), 
            new KeyValuePair<int, int> (4,3) },
        };
        //DijkstraAlgorithem(keyValuesGraph1);

        int[,] maze = { {1,1,1,1}, {1,1,0,1}, {1,1,1,1}, {1,1,0,0}, {1,0,0,0}};
        int dist = ShortestDistance(maze, 0,1, 2,2, new bool[5,4]);
        System.Console.WriteLine("Mini Dist : "+ dist);
    }

    public static List<int> BFSotLevelOrderTraversal(List<List<int>> graph)
    {
        int len = graph.Count;
        List<int> bfs = new List<int>();
        Queue<int> q = new Queue<int>();
        bool[] isVisited = new bool[len + 1];
        q.Enqueue(1);
        isVisited[0] = isVisited[1] = true;

        while (q.Count != 0)
        {
            int node = q.Dequeue();
            bfs.Add(node);

            foreach (int neighbour in graph[node - 1])
            {
                if (!isVisited[neighbour])
                {
                    q.Enqueue(neighbour);
                    isVisited[neighbour] = true;
                }
            }
        }

        return bfs;
    }

    public static void GraphDFS(List<List<int>> graph, bool[] isVisited, int ind, List<int> dfs)
    {
        isVisited[ind] = true;
        dfs.Add(ind);
        foreach (int i in graph[ind - 1])
        {
            if (!isVisited[i])
                GraphDFS(graph, isVisited, i, dfs);
        }
    }

    public static bool DetectCycleInGraph(List<List<int>> graph)
    {
        int member = graph.Count;
        bool[] isVisited = new bool[member + 1];
        Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
        q.Enqueue(new KeyValuePair<int, int>(1, 0));
        bool isLoopExist = false; ;
        isVisited[1] = isVisited[0] = true;
        while (q.Count != 0)
        {
            KeyValuePair<int, int> nodeParent = q.Dequeue();
            foreach (int neighbour in graph[nodeParent.Key - 1])
            {
                if (!isVisited[neighbour])
                {
                    isVisited[neighbour] = true;
                    q.Enqueue(new KeyValuePair<int, int>(neighbour, nodeParent.Key));
                }
                else
                {
                    if (neighbour != nodeParent.Value)
                    {
                        isLoopExist = true;
                        break;
                    }
                }
            }

            if (isLoopExist)
                return true;
        }

        return false;
    }

    public static bool isBiPartiteGraph(List<List<int>> graph)
    {
        Queue<int> q = new Queue<int>();
        q.Enqueue(1);
        int[] color = Enumerable.Repeat(-1, graph.Count).ToArray();
        color[0] = 1;
        bool isBiPartite = true;
        while (q.Count != 0)
        {
            int node = q.Dequeue();
            foreach (int neighbour in graph[node - 1])
            {
                if (color[neighbour - 1] == -1)
                {
                    q.Enqueue(neighbour);
                    color[neighbour - 1] = color[node - 1] == 0 ? 1 : 0;
                }
                else if (color[neighbour - 1] == color[node - 1])
                {
                    isBiPartite = false;
                }
            }

            if (!isBiPartite)
                return false;
        }
        return true;
    }

    public static bool isBiPartiteGraph(List<List<int>> graph, int i, int color, int[] VisitedGraph)
    {
        VisitedGraph[i] = color;
        foreach (int neighbour in graph[i - 1])
        {
            if (VisitedGraph[neighbour - 1] == -1)
            {
                int neighbourColor = color == 1 ? 0 : 1;
                VisitedGraph[neighbour - 1] = neighbourColor;
                isBiPartiteGraph(graph, neighbour, neighbourColor, VisitedGraph);
            }
            else if (VisitedGraph[neighbour - 1] == color)
                return false;
        }

        return true;
    }

    public static bool DetectCycleInDirectedGraphDFS(List<List<int>> graph)
    {
        bool[] visitedPath = new bool[graph.Count + 1];
        bool[] isVisited = new bool[graph.Count + 1];

        for (int i = 1; i <= graph.Count; i++)
        {
            if (!isVisited[i])
            {
                if (DFSDitectCycle(graph, isVisited, visitedPath, i))
                    return true;
            }
        }
        return false;
    }

    private static bool DFSDitectCycle(List<List<int>> graph, bool[] isVisited, bool[] visitedPath, int i)
    {
        visitedPath[i] = true;
        isVisited[i] = true;

        foreach (int neighbour in graph[i - 1])
        {
            if (!isVisited[neighbour])
            {
                if (DFSDitectCycle(graph, isVisited, visitedPath, neighbour))
                    return true;
            }
            else if (visitedPath[neighbour])
                return true;
        }

        visitedPath[i] = false;
        return false;
    }

    private static void TopologicalSortingDAG()
    {
        List<List<int>> graph = new List<List<int>> { new List<int> {  }, new List<int> {  },
        new List<int> { 3 }, new List<int> { 1 }, new List<int> { 0,1 }, new List<int> { 0,2 }};
        Stack<int> st = new Stack<int>();
        bool[] isVisited = new bool[graph.Count()];
        for (int i = 0; i < graph.Count(); i++)
        {
            if (!isVisited[i])
                DFSDAG(graph, st, isVisited, i);
        }
        System.Console.WriteLine("Topological Sorting : "+ string.Join(", ", st));
    }

    private static void DFSDAG(List<List<int>> graph, Stack<int> st, bool[] isVisited, int i)
    {
        isVisited[i] = true;
        foreach (int neighbour in graph[i])
        {
            if (!isVisited[neighbour])
            {
                DFSDAG(graph, st, isVisited, neighbour);
            }
        }

        st.Push(i);
    }

    public static List<int> KahnAlgorithem(List<List<int>> graph)
    {
        int[] inDegree = new int[graph.Count];

        for (int i = 0; i < graph.Count; i++)
        {
            foreach (int neighbour in graph[i])
            {
                inDegree[neighbour]++;
            }
        }

        Queue<int> q = new Queue<int>();
        List<int> topoList = new List<int>();
        int n = graph.Count;
        for (int i = 0; i < n; i++)
        {
            if (inDegree[i] == 0)
                q.Enqueue(i);
        }

        while (q.Count != 0)
        {
            int node = q.Dequeue();
            topoList.Add(node);
            foreach (int inDegreeNeighbour in graph[node])
            {
                inDegree[inDegreeNeighbour]--;

                if (inDegree[inDegreeNeighbour] == 0)
                {
                    q.Enqueue(inDegreeNeighbour);
                }
            }
        }

        return topoList;
    }

    public static void SafeStateUsingTopologicalSort(List<List<int>> graph)  // nodes which leads to terminal node,                                                                         //terminal nodes itself or any single node
    {
        //change the in-degree to out degree to get the terminate node and then proceed with topological sort.
        List<int>[] newGraph = new List<int>[graph.Count];

        List<int> safeNode = new List<int>();
        for (int node = 0; node < graph.Count; node++)
        {
            foreach (int neighbour in graph[node])
            {
                if (newGraph[neighbour] == null)
                {
                    newGraph[neighbour] = new List<int>() { node };
                }
                else
                {
                    newGraph[neighbour].Add(node);
                }
            }
        }

        int[] inDegrees = new int[newGraph.Length];
        for (int i = 0; i < newGraph.Length; i++)
        {
            if (newGraph[i] == null)
            {
                newGraph[i] = new List<int>();
                continue;
            }
            foreach (int neighbour in newGraph[i])
            {
                inDegrees[neighbour]++;
            }
        }

        Queue<int> q = new Queue<int>();
        for (int node = 0; node < newGraph.Length; node++)
        {
            if (inDegrees[node] == 0)
            {
                q.Enqueue(node);
            }
        }

        while (q.Count != 0)
        {
            int node = q.Dequeue();
            safeNode.Add(node);
            foreach (int neighbour in newGraph[node])
            {
                inDegrees[neighbour]--;
                if (inDegrees[neighbour] == 0)
                {
                    q.Enqueue(neighbour);
                }
            }
        }

        System.Console.WriteLine("Safe And Termial Node : " + string.Join(", ", safeNode));
    }

    public static string ALienDictionary(string[] dic, int n, int k)
    {
        List<List<int>> graph = new List<List<int>>();
        for (int i = 0; i < k; i++)
        {
            graph.Add(new List<int>());
        }

        for (int i = 0; i < n - 1; i++)
        {
            string s1 = dic[i];
            string s2 = dic[i + 1];
            int len = Math.Min(s1.Length, s2.Length);
            for (int j = 0; j < len; j++)
            {
                if (s1[j] != s2[j])
                {
                    graph[s1[j] - 'a'].Add(s2[j] - 'a');
                    break;
                }
            }
        }

        List<int> AlienAlphabet = KahnAlgorithem(graph);
        string str = "";
        foreach (int alpla in AlienAlphabet)
        {
            str += (char)(alpla + 'a');
        }
        System.Console.WriteLine("Alient Alphabet : " + str);
        return str;
    }

    public static List<int> ShortestPathFromEnd(List<List<KeyValuePair<int, int>>> graph)
    {
        Stack<int> topo = new Stack<int>();
        bool[] isVisited = new bool[graph.Count];
        for (int i = 0; i < graph.Count; i++)
        {
            if (!isVisited[i])
            {
                GetTopoSort(graph, isVisited, i, topo);
            }
        }

        int[] pathVal = Enumerable.Repeat(int.MaxValue, graph.Count).ToArray();
        int endNode = topo.Peek();
        pathVal[endNode] = 0;

        while (topo.Count != 0)
        {
            int node = topo.Pop();
            foreach (KeyValuePair<int, int> neighbour in graph[node])
            {
                pathVal[neighbour.Key] = Math.Min(pathVal[node] + neighbour.Value, pathVal[neighbour.Key]);
            }
        }
        int nn = 0;
        System.Console.WriteLine($"Min Path Value form End {endNode} : " + string.Join(", ", pathVal));
        return pathVal.ToList();
    }

    private static void GetTopoSort(List<List<KeyValuePair<int, int>>> graph, bool[] isVisited, int i,
    Stack<int> topo)
    {
        isVisited[i] = true;
        foreach (KeyValuePair<int, int> neighbour in graph[i])
        {
            if (!isVisited[neighbour.Key])
            {
                GetTopoSort(graph, isVisited, neighbour.Key, topo);
            }
        }

        topo.Push(i);
    }

    public static int[] ShortestPathInDCG(List<List<int>> graph, int node)
    {
        Queue<KeyValuePair<int, int>> nodeWithPath = new Queue<KeyValuePair<int, int>>();
        nodeWithPath.Enqueue(new KeyValuePair<int, int>(node, 0));
        int[] pathVal = Enumerable.Repeat(int.MaxValue, graph.Count).ToArray();
        pathVal[node] = 0;
        while (nodeWithPath.Count != 0)
        {
            KeyValuePair<int, int> nodeAndWeight = nodeWithPath.Dequeue();
            foreach (int neighbour in graph[nodeAndWeight.Key])
            {
                if (pathVal[neighbour] == int.MaxValue)
                {
                    pathVal[neighbour] = nodeAndWeight.Value + 1;
                    nodeWithPath.Enqueue(new KeyValuePair<int, int>(neighbour, pathVal[neighbour]));
                }
                else
                {
                    pathVal[neighbour] = Math.Min(pathVal[neighbour], nodeAndWeight.Value + 1);
                }
            }
        }

        System.Console.WriteLine($"Shorted Path From Node {node} : " + string.Join(", ", pathVal));
        return pathVal;
    }

    public static int MinimumOperationFromStartToTarget(string start, string target, string[] wordList)
    {
        Queue<KeyValuePair<string, int>> wordWithStep = new Queue<KeyValuePair<string, int>>();
        wordWithStep.Enqueue(new KeyValuePair<string, int>(start, 1));
        // using hashset insteal of actual wordlist, since it do the opeation at O(1)
        HashSet<string> set = new HashSet<string>() {  };
        set.UnionWith(wordList);
        set.Remove(start);
        while (wordWithStep.Count != 0)
        {
            KeyValuePair<string, int> wordAndStep = wordWithStep.Dequeue();
            if (wordAndStep.Key == target)
                return wordAndStep.Value;
            string word = wordAndStep.Key;
            StringBuilder sb = new StringBuilder(word);
            for (int l = 0; l < sb.Length; l++)
            {
                char originalChar = sb[l];
                for (char c = 'a'; c <= 'z'; c++)
                {
                    sb[l] = c;
                    if (set.Contains(sb.ToString()))
                    {
                        set.Remove(sb.ToString());
                        wordWithStep.Enqueue(new KeyValuePair<string, int>(sb.ToString(), wordAndStep.Value+1));
                    }
                }
                sb[l] = originalChar;
            }
        }

        return 0;
    }

    public static List<int> DijkstraAlgorithem(List<List<KeyValuePair<int, int>>> graph)
    {
        List<int> dist = Enumerable.Repeat(int.MaxValue, graph.Count).ToList();
        List<int> path = new List<int>();
        for(int n = 0;n<graph.Count; n++)
        {
            path.Add(n);
        }

        dist[0] = 0;
        SortedSet<Tuple<int, int>> keyValue = [Tuple.Create(0,0)];
        while(keyValue.Count != 0)
        {
            Tuple<int, int> tuple = keyValue.First();
            keyValue.Remove(tuple);
            foreach(KeyValuePair<int, int> keyValuePair in graph[tuple.Item2])
            {
                int val = tuple.Item1 + keyValuePair.Value;
                if (dist[keyValuePair.Key] > val)
                {
                    path[keyValuePair.Key] = tuple.Item2;
                    dist[keyValuePair.Key] = val;
                    keyValue.Add(Tuple.Create(val, keyValuePair.Key));
                }
            }
        }

        System.Console.WriteLine(string.Join(", ", dist));
        int ind = graph.Count-1;
        string pathRoot = ind.ToString();
        while(ind != 0)
        {
            pathRoot = path[ind]+ " => "+ pathRoot;
            ind = path[ind];
        }
        System.Console.WriteLine("Path Root : "+ pathRoot);
        return dist;
    }
    public static int ShortestDistance(int[,] maze, int i, int j, int ti, int tj, bool[,] isvisited)
    {
        if (i< 0 || i == maze.GetLength(0) || j < 0 || j == maze.GetLength(1) || isvisited[i,j] || maze[i,j] == 0)
            return 10000;

        if (i == ti && j == tj)
            return 0;

        isvisited[i,j] = true;
        int down = 1 + ShortestDistance(maze, i+1, j, ti,tj, isvisited);
        int up = 1 + ShortestDistance(maze, i-1, j, ti,tj, isvisited);
        int right = 1 + ShortestDistance(maze, i, j+1, ti,tj, isvisited);
        int left = 1 + ShortestDistance(maze, i, j-1, ti,tj, isvisited);
        isvisited[i,j] = false;

        return Math.Min(Math.Min(down, up), Math.Min(left, right));
    }
}