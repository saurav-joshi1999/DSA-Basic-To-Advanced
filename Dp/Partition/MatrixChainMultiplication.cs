using System.Runtime.Intrinsics.Arm;

public static class Partition
{

    public static void Mainn()
    {
        int[] arr = [10, 20, 30, 40, 50];
        int[,] dp = new int[arr.Length, arr.Length];
        //System.Console.WriteLine("Mini Multiplication : " + MatrixMuliplication(arr, 1, arr.Length - 1, dp));
        //System.Console.WriteLine("Mini Multiplication Tabu : " + MatrixMuliplicationTab(arr));
        List<int> stick = new List<int> { 1, 3, 4, 5 };
        // List<int> stick1 = new List<int> { 0, 1, 3, 4, 5 };  // 0 - stating point to measure the length
        // stick1.Sort();
        // stick1.Add(8);
        // int[,] dp1 = new int[stick.Count + 1, stick.Count + 1];
        // // System.Console.WriteLine("Mini Cost to cut stick: " + MinimumCostToCutWood1(stick1, 1, stick.Count, dp));

        // List<int> stick1 = new List<int> { 0, 1, 3, 4, 5, 8 };
        // Console.WriteLine("Mini Cost to cut stick: " + MinimumCostToCutWood1(stick1, 1, 4, dp1));
        //Console.WriteLine("Mini Cost to cut stick Tab: " + MinimumCostToCutWoodTab(stick1, 4));
        // int[] bustedBollenVal = new int[] { 1, 3, 1, 5, 8, 1 };
        // Console.WriteLine("Maxi Bollena Pop Val: " + MaxBollenBurstVal(bustedBollenVal, 1, 4));
        // Console.WriteLine("Maxi Bollena Pop Val Tab: " + MaxBollenBurstValTab(bustedBollenVal,4));
        //string str = "T&F^T|T";
        //System.Console.WriteLine("NoOfBooleanExpresion : "+ booleanExpression(str, 0, str.Length-1, true));
        // string str = "bababcbadcede";
        // int[] dp1 = Enumerable.Repeat(-1, str.Length).ToArray();
        // System.Console.WriteLine("Mini Palindrome Partition: " + (PalindromePartition(str, 0, str.Length, dp1) - 1));
        // System.Console.WriteLine("Mini Palindrome Partition Tab: " + (PalindromePartitionTab(str)));

        // int[] arr1 = { 1, 15, 7, 9, 2, 5, 10 };
        // int p = 3;
        // int[] dp1 = Enumerable.Repeat(-1, arr1.Length+1).ToArray();
        // System.Console.WriteLine("MaxSumWithGivenPartition: " + MaxSumWithGivenPartition(arr1, 0, p, arr1.Length, dp1));
        // System.Console.WriteLine("MaxSumWithGivenPartition Tab: " + MaxSumWithGivenPartition(arr1, p));
        int[,] arr2 = new int[3, 3] { { 1, 1, 0 }, { 1, 1, 1 }, { 1, 1, 0 }, };
        System.Console.WriteLine("No. of Square : " + NoOfSquare(arr2));
    }

    private static int MatrixMuliplication(int[] arr, int i, int j, int[,] dp)
    {
        if (i == j)
            return 0;

        if (dp[i, j] != 0)  // should have check the -1 instead of zero, since i am returning 0 in base case.
            return dp[i, j];

        int mini = 1000000000;
        for (int k = i; k <= j - 1; k++)
        {
            int step = arr[i - 1] * arr[k] * arr[j] + MatrixMuliplication(arr, i, k, dp) + MatrixMuliplication(arr, k + 1, j, dp);
            mini = Math.Min(step, mini);
        }

        return dp[i, j] = mini;
    }

    private static int MatrixMuliplicationTab(int[] arr)
    {
        int n = arr.Length;
        int[,] dp = new int[arr.Length, arr.Length];
        for (int i = 0; i < n; i++)
        {
            dp[i, i] = 0;
        }

        for (int i = n - 1; i >= 1; i--)
        {
            for (int j = i + 1; j < n; j++)
            {
                int mini = 1000000000;
                for (int k = i; k <= j - 1; k++)
                {
                    int step = arr[i - 1] * arr[k] * arr[j] + dp[i, k] + dp[k + 1, j];
                    mini = Math.Min(step, mini);
                }
                dp[i, j] = mini;
            }

        }

        return dp[1, arr.Length - 1];
    }

    public static int MinimumCostToCutWood(List<int> stick, int i, int j, int[,] dp)
    {
        if (i > j) return 0;

        if (dp[i, j] != 0)
            return dp[i, j];

        int mini = 10000;
        for (int k = i; k <= j; k++)
        {
            int cost = stick[j + 1] - stick[i - 1] + MinimumCostToCutWood(stick, i, k - 1, dp) + MinimumCostToCutWood(stick, k + 1, j, dp);
            mini = Math.Min(mini, cost);
        }

        return dp[i, j] = mini;
    }

    public static int MinimumCostToCutWood1(List<int> stick, int i, int j, int[,] dp)
    {
        if (i > j) return 0;
        if (dp[i, j] != 0)
            return dp[i, j];
        int mini = int.MaxValue;
        for (int k = i; k <= j; k++)
        {
            int cost = stick[j + 1] - stick[i - 1]
                     + MinimumCostToCutWood1(stick, i, k - 1, dp)
                     + MinimumCostToCutWood1(stick, k + 1, j, dp);
            mini = Math.Min(mini, cost);
        }

        dp[i, j] = mini;
        return mini;
    }

    public static int MinimumCostToCutWoodTab(List<int> stick, int n)
    {
        int[,] dp = new int[n + 2, n + 1];

        for (int i = n; i >= 1; i--)
        {
            for (int j = i; j <= n; j++)
            {
                int mini = 10000;
                for (int k = i; k <= j; k++)
                {
                    int cost = stick[j + 1] - stick[i - 1] + dp[i, k - 1] + dp[k + 1, j];
                    mini = Math.Min(mini, cost);
                }

                dp[i, j] = mini;
            }
        }

        return dp[1, n];
    }

    public static int MaxBollenBurstVal(int[] bollenVal, int i, int j)
    {
        if (i > j) return 0;

        int maxi = -100000;
        for (int k = i; k <= j; k++)
        {
            int val = bollenVal[i - 1] * bollenVal[k] * bollenVal[j + 1] + MaxBollenBurstVal(bollenVal, i, k - 1) +
                                                                            MaxBollenBurstVal(bollenVal, k + 1, j);
            maxi = Math.Max(maxi, val);
        }

        return maxi;
    }

    public static int MaxBollenBurstValTab(int[] bollenVal, int n)
    {
        int[,] dp = new int[n + 2, n + 1];
        for (int i = n; i >= 1; i--)
        {
            for (int j = i; j <= n; j++)
            {
                int maxi = -100000;
                for (int k = i; k <= j; k++)
                {
                    int val = bollenVal[i - 1] * bollenVal[k] * bollenVal[j + 1] + dp[i, k - 1] + dp[k + 1, j];
                    maxi = Math.Max(maxi, val);
                }
                dp[i, j] = maxi;
            }
        }

        return dp[1, n];
    }

    public static int booleanExpression(string str, int i, int j, bool isTrue)
    {
        if (i > j) return 0;
        if (i == j)
        {
            if (isTrue)
                return str[i] == 'T' ? 1 : 0;
            else
                return str[i] == 'F' ? 1 : 0;
        }
        int way = 0;
        for (int k = i + 1; k <= j - 1; k = k + 2)
        {
            int lt = booleanExpression(str, i, k - 1, true);
            int lf = booleanExpression(str, i, k - 1, false);
            int rt = booleanExpression(str, k + 1, j, true);
            int rf = booleanExpression(str, k + 1, j, false);

            if (str[k] == '&')
            {
                if (isTrue)
                    way += lt * rt;
                else
                    way += lt * rf + lf * rt + lf * rf;
            }
            else if (str[k] == '|')
            {
                if (isTrue)
                    way += lt * rt + lt * rf + rt * lf;
                else
                    way += lf * rf;
            }
            else
            {
                if (isTrue)
                    way += lt * rf + rt * lf;
                else
                    way += lt * rt;
            }
        }

        return way;
    }

    public static int PalindromePartition(string str, int i, int n, int[] dp)
    {
        if (i == n) return 0;

        if (dp[i] != -1) return dp[i];

        int mini = int.MaxValue;
        for (int k = i; k < n; k++)
        {
            if (isPalindrome(str, i, k))
            {
                int palindrome = 1 + PalindromePartition(str, k + 1, n, dp);
                mini = Math.Min(mini, palindrome);
            }
        }

        return dp[i] = mini;
    }

    public static int PalindromePartitionTab(string str)
    {
        int[] dp = new int[str.Length + 1];
        int n = str.Length;
        for (int i = n - 1; i >= 0; i--)
        {
            int mini = int.MaxValue;
            for (int k = i; k < n; k++)
            {
                if (isPalindrome(str, i, k))
                {
                    int palindrome = 1 + dp[k + 1];
                    mini = Math.Min(mini, palindrome);
                }
            }

            dp[i] = mini;
        }

        return dp[0] - 1;
    }

    private static bool isPalindrome(string temp, int i, int j)
    {
        if (temp.Length == 1)
            return true;

        while (i < j)   
        {
            if (temp[i] == temp[j])
            {
                i++;
                j--;
            }
            else
            {
                return false;
            }
        }
        return true;
    }

    public static int MaxSumWithGivenPartition(int[] arr, int i, int p, int n, int[] dp)
    {
        if (i == n) return 0;

        if (dp[i] != -1) return dp[i];

        int maxiArr = int.MinValue; int len = 0; int sum = 0; int maxiSum = int.MinValue;
        for (int k = i; k < Math.Min(n, i + p); k++)
        {
            len++;
            maxiArr = Math.Max(maxiArr, arr[k]);
            sum = len * maxiArr + MaxSumWithGivenPartition(arr, k + 1, p, n, dp);
            maxiSum = Math.Max(sum, maxiSum);
        }

        return dp[i] = maxiSum;
    }

    public static int MaxSumWithGivenPartition(int[] arr, int p)
    {
        int n = arr.Length;
        int[] dp = new int[n + 1];
        for (int i = n - 1; i >= 0; i--)
        {
            int maxiArr = int.MinValue; int len = 0; int sum = 0; int maxiSum = int.MinValue;
            for (int k = i; k < Math.Min(n, i + p); k++)
            {
                len++;
                maxiArr = Math.Max(maxiArr, arr[k]);
                sum = len * maxiArr + dp[k + 1];
                maxiSum = Math.Max(sum, maxiSum);
            }

            dp[i] = maxiSum;
        }

        return dp[0];
    }

    public static int NoOfSquare(int[,] arr)
    {
        int n = arr.GetLength(0); int m = arr.GetLength(1);
        int[,] dp = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            dp[i, 0] = arr[i, 0];
        }

        for (int j = 0; j < m; j++)
        {
            dp[0, j] = arr[0, j];
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < m; j++)
            {

                if (arr[i, j] == 1)
                {
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1])+1;
                }
            }
        }

        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                sum += dp[i, j];
            }
        }

        return sum;
    }
}