public static class TargetSubsequence
{
    public static void mainn()
    {
        int[] arr = { 1, 2, 4, 3 };
        int target = 4;
        // int[,] dp = new int[arr.Length, target + 1];
        // int[,] dp1 = new int[arr.Length, target + 1];
        // Console.WriteLine("Target present :" + GetTargetSubsequence(arr, target, arr.Length - 1, dp));
        // Console.WriteLine("Target Present with Tab :" + GetTargetSubsequenceTab(arr, target, arr.Length - 1, dp1));
        // Console.WriteLine("Target Present with Tab :" + GetTargetSubsequenceTabSpaceOpti(arr, target, arr.Length - 1));
        //Console.WriteLine("Mini Abs Diff :" + MinPossibleDifference());
        //Console.WriteLine("Subsequence Count with K :" + GetCountOfSubSequenceWithSumK(arr, target, arr.Length - 1));
        //Console.WriteLine("No. of Subswquence with difference d :" + DiffOfSubSqequenceToTarget(arr, target));
        Console.WriteLine("No of Subsquence with sum target " + TargetSumWithDuplicate(arr, target, 3));
        Console.WriteLine("No of Subsquence with sum target with tab " + TargetSumWithDuplicateTab(arr, target, 3));
    }
    public static int GetTargetSubsequence(int[] arr, int target, int index, int[,] dp)
    {
        if (index < 0) return -1;
        if (target == 0) return 1;
        if (index == 0) return arr[0] == target ? 1 : -1;

        if (dp[index, target] != 0) return dp[index, target];

        int notTake = GetTargetSubsequence(arr, target, index - 1, dp);
        int take = -1;
        if (arr[index] <= target)
        {
            take = GetTargetSubsequence(arr, target - arr[index], index - 1, dp);
        }

        return dp[index, target] = take == 1 || notTake == 1 ? 1 : -1;
    }

    public static int GetTargetSubsequenceTab(int[] arr, int target, int index, int[,] dp)
    {
        for (int i = 0; i <= index; i++)
        {
            dp[i, 0] = 1;
        }
        dp[0, arr[0]] = 1;

        for (int i = 1; i <= index; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                int notTake = dp[i - 1, j];
                int take = -1;
                if (arr[i] <= j)
                    take = dp[i - 1, j - arr[i]];
                dp[i, j] = take == 1 || notTake == 1 ? 1 : -1;
            }
        }

        return dp[index, target];
    }

    public static int GetTargetSubsequenceTabSpaceOpti(int[] arr, int target, int index)
    {
        int[] pre = new int[target + 1];
        int[] curr = new int[target + 1];
        pre[0] = 1;
        pre[arr[0]] = 1;

        for (int i = 1; i <= index; i++)
        {
            for (int j = 1; j <= target; j++)
            {
                int notTake = pre[j];
                int take = -1;
                if (arr[i] <= j)
                    take = pre[j - arr[i]];
                curr[j] = take == 1 || notTake == 1 ? 1 : -1;
            }
            pre = (int[])curr.Clone(); ;
        }

        return pre[target];
    }

    public static int MinPossibleDifference()
    {
        int[] arr = { 1, 2, 3, 1, 2, 1, 3, 2, 1, 3 };
        int target = 0;
        foreach (int ar in arr)
        {
            target += ar;
        }
        int[,] dp1 = new int[arr.Length, target + 1];
        GetTargetSubsequenceTab(arr, target, arr.Length - 1, dp1);
        int mini = target;
        for (int s1 = 0; s1 <= target / 2; s1++)
        {
            if (dp1[arr.Length - 1, s1] == 1)
            {
                mini = Math.Min(mini, Math.Abs((target - s1) - s1));
            }
        }
        return mini;
    }

    public static int GetCountOfSubSequenceWithSumK(int[] arr, int target, int index)
    {
        //if (target == 0) return 1;
        if (index == 0)
        {
            if (target == 0 && arr[0] == 0) return 2;
            if (target == 0) return 1;
            if (arr[0] == target) return 1;
            return 0;
        }

        int notTake = GetCountOfSubSequenceWithSumK(arr, target, index - 1);
        int take = 0;
        if (arr[index] <= target)
            take = GetCountOfSubSequenceWithSumK(arr, target - arr[index], index - 1);
        return take + notTake;
    }

    public static int DiffOfSubSqequenceToTarget(int[] arr, int d)
    {
        int sm = arr.Sum();
        if (sm < d || (sm - d) % 2 != 0)
            return -1;

        int t = (sm - d) / 2;
        return GetCountOfSubSequenceWithSumK(arr, t, arr.Length - 1);
    }

    public static int TargetSumWithDuplicate(int[] arr, int target, int n)
    {
        //if (target == 0) return 1; //this is not required 
        if (n == 0)
        {
            return target % arr[n] == 0 ? 1 : 0;
        }

        int notTake = TargetSumWithDuplicate(arr, target, n - 1);
        int take = 0;
        if (arr[n] <= target)
        {
            take = TargetSumWithDuplicate(arr, target - arr[n], n);
        }
        return take + notTake;
    }

    public static int TargetSumWithDuplicateTab(int[] arr, int target, int n)
    {
        int[,] dp = new int[n+1, target + 1];
        for (int t = 0; t <= target; t++)
        {
            if (t % arr[0] == 0)
                dp[0, t] = 1;
            else
                dp[0, t] = 0;
        }

        for (int i = 1; i <= n; i++)
        {
            for (int t = 0; t <= target; t++)
            {
                int notTake = dp[i - 1, t];
                int take = 0;
                if (arr[i] <= t)
                    take = dp[i, t - arr[i]];
                dp[i, t] = take + notTake;
            }
        }

        return dp[n, target];
    }

}