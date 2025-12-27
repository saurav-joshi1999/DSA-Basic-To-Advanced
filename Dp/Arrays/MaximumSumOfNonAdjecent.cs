using System.Runtime.Serialization;

public static class MaximunSum
{
    public static int GetMaximumSum(int[] arr, int n, int[] dp)
    {
        if (n == 0) return arr[n];
        if (n < 0) return 0;

        if (dp[n] != 0) return dp[n];

        int pic = arr[n] + GetMaximumSum(arr, n - 2, dp);
        int notPic = 0 + GetMaximumSum(arr, n - 1, dp);
        return dp[n] = Math.Max(pic, notPic);
    }

    public static int GetMaximumSumTabulation(int[] arr, int n, int[] dp)
    {
        dp[0] = arr[0];
        int exclude = 0;
        int incSum = 0, excSum = 0;
        for (int i = 1; i <= n; i++)
        {
            incSum = arr[i];
            if (i > 1)
                incSum += dp[i - 2];
            excSum = dp[i - 1];
            dp[i] = Math.Max(incSum, excSum);
        }

        return dp[n];
    }
    
    public static int GetMaximumSumTabulationWithoutDp(int[] arr, int n, int[] dp)
    {
        int pre = arr[0];
        int pre2 = 0;
        for (int i = 1; i <= n; i++)
        {
            int incSum = arr[i];
            if (i > 1)
                incSum += pre2;
            int excSum = pre;
            int current = Math.Max(incSum, excSum);
            pre2 = pre;
            pre = current;
        }

        return pre;
    }
}