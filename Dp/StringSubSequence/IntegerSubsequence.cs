using System.Globalization;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Serialization;
using System.Transactions;

public static class SubSequence
{

    public static void Mainn()
    {
        int[] arr = { 1, 5,4,3,2,6,7,10,8,9 };
        int[,] dp = new int[arr.Length + 1, arr.Length];
        //Console.WriteLine("Largest Increasing SubSq : " + LargestIncreasingSubSq(arr, 0, -1, dp));
        //Console.WriteLine("Largest Increasing SubSq Tab : " + LargestIncreasingSubSqMemo(arr));
        Console.WriteLine("Largest Increasing SubSq Tab : " + LargestIncreasingSubSqTabulation(arr));
        Console.WriteLine("LDivisible Subset : " + string.Join(" ", LongestDivibleSubSet(arr)));
        string[] sarr = { "a", "b", "c", "ba", "bca", "bda", "bdca", "bdcaef" };
        Console.WriteLine("Longest substring Subset : " + string.Join(" ", LongestStringChain(sarr)));
    }
    public static int LargestIncreasingSubSq(int[] arr, int ind, int pre, int[,] dp)
    {
        if (ind == arr.Length)
            return 0;

        if (dp[pre + 1, ind] != 0)
            return dp[pre + 1, ind];
        int notTake = LargestIncreasingSubSq(arr, ind + 1, pre, dp);
        int take = 0;
        if (pre == -1 || arr[ind] > arr[pre])
        {
            take = 1 + LargestIncreasingSubSq(arr, ind + 1, ind, dp);
        }
        return dp[pre + 1, ind] = Math.Max(take, notTake);
    }

    public static int LargestIncreasingSubSqMemo(int[] arr)
    {
        int[,] dp = new int[arr.Length + 1, arr.Length + 1];

        for (int i = arr.Length - 1; i >= 0; i--)
        {
            for (int j = i - 1; j >= -1; j--)
            {
                int notTake = dp[j + 1, i + 1];
                int take = 0;
                if (j == -1 || arr[i] > arr[j])
                {
                    take = 1 + dp[i + 1, i + 1];
                }
                dp[j + 1, i] = Math.Max(take, notTake);
            }
        }
        return dp[0, 0];
    }

    public static int LargestIncreasingSubSqTabulation(int[] arr)  //TC - n*(n-1) SC - n 
    {
        int maxi = 1; int maxInd = 0;
        int[] dp = Enumerable.Repeat(1, arr.Length).ToArray();
        int[] hash = Enumerable.Repeat(0, arr.Length).ToArray();
        int[] longest = new int[arr.Length]; int noLongestSubse = 1;

        for (int curr = 0; curr < arr.Length; curr++)
        {
            hash[curr] = curr; longest[curr] = 1; dp[curr] = 1;
            for (int pre = 0; pre < curr; pre++)
            {
                if (arr[curr] > arr[pre] && 1 + dp[pre] > dp[curr])
                {
                    hash[curr] = pre;
                    dp[curr] = 1 + dp[pre];
                    longest[curr] = longest[pre];
                }

                else if (arr[curr] > arr[pre] && 1 + dp[pre] == dp[curr])
                {
                    longest[curr] += longest[pre];
                }

            }

            noLongestSubse = Math.Max(noLongestSubse, longest[curr]);
            if (dp[curr] > maxi)
            {
                maxi = dp[curr];
                maxInd = curr;
            }
        }

        Stack<int> st = new Stack<int>();
        st.Push(arr[maxInd]);
        while (hash[maxInd] != maxInd)
        {
            maxInd = hash[maxInd];
            int ar = arr[maxInd];
            st.Push(ar);
        }

        Console.WriteLine(string.Join(", ", st));
        Console.WriteLine("No of Longest Subsequence : " + noLongestSubse);
        return maxi;
    }

    public static List<int> LongestDivibleSubSet(int[] arr)
    {
        Array.Sort(arr);
        int[] dp = Enumerable.Repeat(1, arr.Length).ToArray();
        int[] hash = Enumerable.Repeat(0, arr.Length).ToArray();
        int maxi = arr[0]; int lastIndex = 0;
        List<int> lt = new List<int>();

        for (int curr = 0; curr < arr.Length; curr++)
        {
            hash[curr] = curr;
            for (int pre = 0; pre < curr; pre++)
            {
                if (arr[curr] % arr[pre] == 0)
                {
                    dp[curr] = Math.Max(dp[curr], 1 + dp[pre]);
                    hash[curr] = pre;
                }
            }

            if (maxi < dp[curr])
            {
                maxi = dp[curr];
                lastIndex = curr;
            }
        }

        lt.Add(arr[lastIndex]);
        while (lastIndex != hash[lastIndex])
        {
            lastIndex = hash[lastIndex];
            lt.Add(arr[lastIndex]);
        }

        return lt;
    }

    public static List<string> LongestStringChain(string[] arr)
    {
        int[] dp = Enumerable.Repeat(1, arr.Length).ToArray();
        int[] hash = Enumerable.Repeat(0, arr.Length).ToArray();
        int maxi = arr[0].Length; int lastIndex = 0;
        List<string> lt = new List<string>();

        for (int curr = 0; curr < arr.Length; curr++)
        {
            hash[curr] = curr;
            for (int pre = 0; pre < curr; pre++)
            {
                if (MisMatchedCharacter(arr[curr], arr[pre]) && dp[curr] < 1 + dp[pre])
                {
                    dp[curr] = 1 + dp[pre];
                    hash[curr] = pre;
                }
            }

            if (maxi < dp[curr])
            {
                maxi = dp[curr];
                lastIndex = curr;
            }
        }

        lt.Add(arr[lastIndex]);
        while (lastIndex != hash[lastIndex])
        {
            lastIndex = hash[lastIndex];
            lt.Add(arr[lastIndex]);
        }

        return lt;
    }

    private static bool MisMatchedCharacter(string v1, string v2)
    {
        if (v1.Length != v2.Length + 1)
            return false;

        int indv1 = 0; int indv2 = 0;
        while (indv1 < v1.Length)
        {
            if (indv2 < v2.Length && v1[indv1] == v2[indv2])
            {
                indv1++; indv2++;
            }
            else
            {
                indv1++;
            }
        }

        if (indv1 == v1.Length && indv2 == v2.Length)
            return true;
        return false;
    }
}