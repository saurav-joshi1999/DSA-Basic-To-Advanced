

public static class MatrixGraph
{
    public static void mainn()
    {
        // int[,] matrixGraph = new int[5, 4] { { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 0 }, { 1, 1, 0, 1 } };
        // System.Console.WriteLine("Num of Islant " + NoIfIsland(matrixGraph));

        //int[,] pixelGraph = new int[4, 4] { { 1, 1, 1, 0 }, { 1, 1, 0, 1 }, { 1, 0, 1, 2 }, { 1, 1, 1, 1 } };
        // UpdateColorPixel(pixelGraph, 3, 1, 3);

        //int[,] zeroOneGraph = new int[4, 3] { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 1 } };
        //int[,] distancrGraph = NearestDistanceOfOne(zeroOneGraph);

        //int[,] originalZeroOneGraph = new int[5, 4] { { 1, 1, 0, 1 }, { 1, 1, 1, 1 }, { 0, 0, 0, 1 }, { 1, 0, 0, 1 }, { 1, 1, 1, 0 } };
        //int[,] OneAndZeroGraph = ConvertXToO(originalZeroOneGraph);

        // int[,] seaandLand = new int[5, 4] { { 0, 0, 1, 1 }, { 0, 1, 1, 0 }, { 0, 1, 1, 0 }, { 0, 0, 0, 1 }, { 0, 1, 1, 0 } };
        // System.Console.WriteLine("No of Enclave: " + NoOfEnclaves(seaandLand));

        int[,] IdenticalValueInGraph = new int[4, 5]
        { { 1, 1, 0, 1, 1 }, { 1, 0, 0, 0 , 0}, { 0, 0, 0, 1, 1 }, { 1, 1, 0, 1, 0 }};
        System.Console.WriteLine("No of Identical Island: " + NoOfIdentialIslandUsingDFS(IdenticalValueInGraph));

        // for (int i = 0; i < OneAndZeroGraph.GetLength(0); i++)
        // {
        //     for (int j = 0; j < OneAndZeroGraph.GetLength(1); j++)
        //     {
        //         Console.Write(OneAndZeroGraph[i, j] + " ");
        //     }
        //     Console.WriteLine();
        // }

    }

    public static int NoIfIsland(int[,] arr)
    {
        int row = arr.GetLength(0);
        int col = arr.GetLength(1);
        bool[,] isVisited = new bool[row + 1, col + 1];
        int noOfIsland = 0;
        Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                if (arr[i, j] == 1 && !isVisited[i, j])
                {
                    isVisited[i, j] = true;
                    noOfIsland++;
                    q.Enqueue(new KeyValuePair<int, int>(i, j));
                    BFSForMatrix(arr, isVisited, i, j, q);
                }
            }
        }
        return noOfIsland;
    }

    public static void UpdateColorPixel(int[,] arr, int sr, int sc, int newColor)
    {
        int row = arr.GetLength(0);
        int col = arr.GetLength(1);
        bool[,] isVisited = new bool[row + 1, col + 1];
        Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
        int startingPix = arr[sr, sc];
        q.Enqueue(new KeyValuePair<int, int>(sr, sc));
        isVisited[sr, sc] = true;
        arr[sr, sc] = newColor;
        BFSForPixalMatrix(startingPix, isVisited, q, newColor, arr);
    }

    private static void BFSForPixalMatrix(int startingPix, bool[,] isVisited, Queue<KeyValuePair<int, int>> q, int newColor, int[,] arr)
    {
        int n = arr.GetLength(0);
        int m = arr.GetLength(1);
        while (q.Count != 0)
        {
            KeyValuePair<int, int> currColos = q.Dequeue();
            int curri = currColos.Key;
            int currj = currColos.Value;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int ux = curri + x;
                    int uy = currj + y;
                    if (ux >= 0 && ux < n && uy >= 0 && uy < m && Math.Abs(x) != Math.Abs(y) && !isVisited[ux, uy] && arr[ux, uy] == startingPix)
                    {
                        isVisited[ux, uy] = true;
                        q.Enqueue(new KeyValuePair<int, int>(ux, uy));
                        arr[ux, uy] = newColor;
                    }
                }
            }
        }
    }

    private static void BFSForMatrix(int[,] arr, bool[,] isVisited, int i, int j, Queue<KeyValuePair<int, int>> q)
    {
        int n = arr.GetLength(0);
        int m = arr.GetLength(1);
        while (q.Count != 0)
        {
            KeyValuePair<int, int> cordi = q.Dequeue();
            int curri = cordi.Key;
            int currj = cordi.Value;
            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int ux = curri + x;
                    int uy = currj + y;
                    if (ux >= 0 && ux < n && uy >= 0 && uy < m && !isVisited[ux, uy] && arr[ux, uy] == 1)
                    {
                        isVisited[ux, uy] = true;
                        q.Enqueue(new KeyValuePair<int, int>(ux, uy));
                    }
                }
            }
        }
    }

    public static int[,] NearestDistanceOfOne(int[,] graph)
    {
        int n = graph.GetLength(0); int m = graph.GetLength(1);
        int[,] DistanceArray = new int[n, m];
        bool[,] isVisited = new bool[n, m];
        Queue<KeyValuePair<KeyValuePair<int, int>, int>> cordinateWithDis = new Queue<KeyValuePair<KeyValuePair<int, int>, int>>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (graph[i, j] == 1)
                {
                    cordinateWithDis.Enqueue
                    (new KeyValuePair<KeyValuePair<int, int>, int>(new KeyValuePair<int, int>(i, j), 0));
                    isVisited[i, j] = true;
                }
            }
        }

        if (cordinateWithDis.Count == 0)
            return graph;

        while (cordinateWithDis.Count != 0)
        {
            KeyValuePair<KeyValuePair<int, int>, int> corWithDis = cordinateWithDis.Dequeue();
            KeyValuePair<int, int> cordinate = corWithDis.Key;
            int distance = corWithDis.Value;
            DistanceArray[cordinate.Key, cordinate.Value] = distance;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int ux = cordinate.Key + x; int uy = cordinate.Value + y;
                    if (ux >= 0 && ux < n && uy >= 0 && uy < m && Math.Abs(x) != Math.Abs(y) && !isVisited[ux, uy])
                    {
                        isVisited[ux, uy] = true;
                        cordinateWithDis.Enqueue
                    (new KeyValuePair<KeyValuePair<int, int>, int>(new KeyValuePair<int, int>(ux, uy), distance + 1));
                    }
                }
            }
        }

        return DistanceArray;
    }

    public static int[,] ConvertXToO(int[,] graph)
    {
        int n = graph.GetLength(0); int m = graph.GetLength(1);
        bool[,] isVisited = new bool[n, m];
        int[,] updatedGraph = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                updatedGraph[i, j] = 1;
            }
        }

        Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if ((i == 0 || j == 0 || i == n - 1 || j == m - 1) && graph[i, j] == 0)
                {
                    q.Enqueue(new KeyValuePair<int, int>(i, j));
                    isVisited[i, j] = true;
                    updatedGraph[i, j] = 0;
                }
            }
        }

        while (q.Count != 0)
        {
            KeyValuePair<int, int> coordinate = q.Dequeue();
            for (int i = -1; i <= 1; i++)
            {
                for (int j = -1; j <= 1; j++)
                {
                    int ux = coordinate.Key + i; int uy = coordinate.Value + j;
                    if (ux >= 0 && ux < n && uy >= 0 && uy < m && !isVisited[ux, uy] && Math.Abs(i) != Math.Abs(j) &&
                     graph[ux, uy] == 0)
                    {
                        q.Enqueue(new KeyValuePair<int, int>(ux, uy));
                        isVisited[ux, uy] = true;
                        updatedGraph[ux, uy] = 0;
                    }
                }
            }
        }

        return updatedGraph;
    }

    public static int NoOfEnclaves(int[,] graph)
    {
        int n = graph.GetLength(0); int m = graph.GetLength(1);
        bool[,] isVisited = new bool[n, m];
        Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if ((i == 0 || i == n - 1 || j == 0 || j == m - 1) && graph[i, j] == 1)
                {
                    isVisited[i, j] = true;
                    q.Enqueue(new KeyValuePair<int, int>(i, j));
                }
            }
        }

        while (q.Count != 0)
        {
            KeyValuePair<int, int> cordinate = q.Dequeue();

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    int ux = cordinate.Key + x; int uy = cordinate.Value + y;
                    if (Math.Abs(x) != Math.Abs(y) && ux >= 0 && ux < n && uy >= 0 && uy < m &&
                    graph[ux, uy] == 1 && !isVisited[ux, uy])
                    {
                        isVisited[ux, uy] = true;
                        q.Enqueue(new KeyValuePair<int, int>(ux, uy));
                    }
                }
            }
        }

        int noOfEnclaves = 0;
        for (int i = 1; i < n - 1; i++)
        {
            for (int j = 1; j < m - 1; j++)
            {
                if (graph[i, j] == 1 && !isVisited[i, j])
                {
                    noOfEnclaves++;
                }
            }
        }

        return noOfEnclaves;
    }

    public static int NoOfIdentialIslandUsingDFS(int[,] graph)
    {
        int n = graph.GetLength(0); int m = graph.GetLength(1);
        bool[,] isVisited = new bool[n, m];
        HashSet<List<KeyValuePair<int, int>>> setWithPairList = new HashSet<List<KeyValuePair<int, int>>>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (!isVisited[i, j] && graph[i, j] == 1)
                {
                    List<KeyValuePair<int, int>> pairList = new List<KeyValuePair<int, int>>();
                    KeyValuePair<int, int> pair = new KeyValuePair<int, int>(i, j);
                    DFS(pair, isVisited, graph, pairList, pair);
                    setWithPairList.Add(pairList);
                }
            }
        }

        return setWithPairList.Count;
    }

    private static void DFS(KeyValuePair<int, int> pair1, bool[,] isVisited, int[,] graph, List<KeyValuePair<int, int>> pairList, KeyValuePair<int, int> pair2)
    {
        int n = graph.GetLength(0); int m = graph.GetLength(1); 
        isVisited[pair1.Key, pair1.Value] = true;
        pairList.Add(new KeyValuePair<int, int>(pair1.Key - pair2.Key, pair1.Value - pair2.Value));
        int[] delRow = [-1, 0, 1, 0];
        int[] delCol = [0, -1, 0, 1];
        for (int i = 0; i < 4; i++)
        {
            int x = pair1.Key + delRow[i]; int y = pair1.Value + delCol[i];
            if (x >= 0 && x < n && y >= 0 && y < m && !isVisited[x, y] && graph[x, y] == 1)
            {
                DFS(new KeyValuePair<int, int>(x,y), isVisited, graph, pairList, pair1);
            }
        }
    }
}