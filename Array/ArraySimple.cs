public static class ArrayQuestion
{
    public static void mainn()
    {
        //Console.WriteLine(string.Join(", ", GetLeaders()));
        LongestConsecutiveSubquence();
    }

    public static List<int> GetLeaders()
    {
        int[] arr = { 10, 22, 12, 3, 0, 6 };
        int n = arr.Length - 1;
        int leader = arr[n];
        List<int> leaders = new List<int> { arr[n] };

        for (int i = n - 1; i >= 0; i--)
        {
            if (arr[i] > leader)
            {
                leader = arr[i];
                leaders.Add(leader);
            }
        }

        return leaders;
    }


    public static void mainn2()
    {
        int[] arr = { 2, 1, 5, 6, 2, 3, 1 };
        System.Console.WriteLine("Max Rec Area : " + GetlargestRectangelArea(arr));
        System.Console.WriteLine("Max Rec Area Opti : " + GetlargestRectangelAreaOptimise(arr));
        System.Console.WriteLine("Max Rec Area Opti2 : " + GetLargestRectangularArea(arr));
    }

    public static void LongestConsecutiveSubquence()
    {
        List<int> arr = new List<int> { 1, 1, 1, 2, 2, 2, 3, 3, 3, 5, 5, 5, 6, 6, 101, 102, 103, 201, 205, 206, 207, 208, 210 };
        arr.Sort();
        int count = 1;
        int newCount = 1;
        int series = arr[0] + 1;
        for (int i = 1; i < arr.Count; i++)
        {
            if (arr[i] == arr[i - 1])
                continue;
            if (arr[i] == series)
            {
                series += 1;
                newCount++;
                if (newCount > count)
                    count = newCount;
            }
            else
            {
                newCount = 1;
                series = arr[i] + 1;
            }
        }

        Console.WriteLine("Longest Consecutive Sqquence :" + count);
    }

    public static int GetlargestRectangelArea(int[] arr)
    {
        int n = arr.Length;
        int[] leftS = Enumerable.Repeat(0, n).ToArray(); ;
        int[] rightS = Enumerable.Repeat(n, n).ToArray();
        Stack<int> indexSt = new Stack<int>();

        for (int i = 0; i < n; i++)
        {
            while (indexSt.Count != 0)
            {
                if (arr[indexSt.Peek()] > arr[i])
                {
                    indexSt.Pop();
                    //continue;
                }
                else
                {
                    leftS[i] = indexSt.Peek() + 1;
                    break;
                }
            }

            indexSt.Push(i);
        }

        indexSt = new Stack<int>();
        for (int i = n - 1; i >= 0; i--)
        {
            while (indexSt.Count != 0)
            {
                if (arr[indexSt.Peek()] > arr[i])
                {
                    indexSt.Pop();
                    //continue;
                }
                else
                {
                    rightS[i] = indexSt.Peek() - 1;
                    break;
                }
            }

            indexSt.Push(i);
        }

        int maxSum = int.MinValue;
        for (int i = 0; i < n; i++)
        {
            int sum = (rightS[i] - leftS[i] + 1) * arr[i];
            maxSum = Math.Max(sum, maxSum);
        }

        return maxSum;
    }

    public static int GetlargestRectangelAreaOptimise(int[] arr)
    {
        Stack<int> indexSt = new Stack<int>();
        indexSt.Push(0);
        int maxi = arr[0];
        int n = arr.Count();
        for (int i = 1; i < n; i++)
        {
            while (indexSt.Count != 0 && arr[indexSt.Peek()] > arr[i])
            {
                if (arr[indexSt.Peek()] < arr[i])
                {
                    indexSt.Push(i);
                    break;
                }
                else if (arr[indexSt.Peek()] > arr[i])
                {
                    int popindex = indexSt.Pop();
                    if (!indexSt.TryPeek(out int aa))
                    {
                        maxi = Math.Max(arr[popindex] * i, maxi);
                    }
                    else
                    {
                        maxi = Math.Max((i - aa - 1) * arr[popindex], maxi);
                    }
                    indexSt.Push(i);
                }
            }
        }

        while (indexSt.Count != 0)
        {
            int popindex = indexSt.Pop();
            if (!indexSt.TryPeek(out int aa))
            {
                maxi = Math.Max(arr[popindex] * n, maxi);
            }
            else
            {
                maxi = Math.Max((n - aa - 1) * arr[popindex], maxi);
            }
        }
        return maxi;
    }

    public static int GetLargestRectangularArea(int[] arr)
    {
        Stack<int> indexSt = new Stack<int>();
        int maxArea = 0;
        int n = arr.Length;

        // A common optimization: Add a sentinel element with height 0 to the end.
        // This ensures all bars remaining in the stack at the end are processed correctly.
        //int[] extendedArr = new int[n + 1];
        //Array.Copy(arr, extendedArr, n);
        // extendedArr[n] = 0;
        // n++;

        for (int i = 0; i <= n; i++)
        {
            while (indexSt.Count > 0 &&(i ==n || arr[indexSt.Peek()] >= arr[i]))
            {
                int height = arr[indexSt.Pop()];
                int width;

                if (indexSt.Count == 0)
                {
                    width = i;
                }
                else
                {
                    width = i - indexSt.Peek() - 1;
                }

                maxArea = Math.Max(maxArea, width * height);
            }
            indexSt.Push(i);
        }
        return maxArea;
    }

}