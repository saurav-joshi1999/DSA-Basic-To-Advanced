public static class NumOfMinCoinsRequired
{
    public static void mainn()
    {
        int[] arr = { 1, 2, 3 };
        int target = 6;
        int[,] dp = new int[arr.Length, target + 1];
        Console.WriteLine(" Min Coin Sum : " + GetMinCoin(arr, target, arr.Length - 1, 0, dp));
        int[,] dp1 = new int[arr.Length, target + 1];
        Console.WriteLine(" Min Coin Sum with Method2 : " + GetMinCoin2(arr, target, arr.Length - 1, dp));
        Console.WriteLine(" Min Coin Sum with Tabulation : " + GetMinCoinTabulation(arr, target, arr.Length - 1));
    }

    public static int GetMinCoin(int[] arr, int target, int n, int count, int[,] dp) // in this code memoisation may fail as along 
    // with index and target count in also changing
    {
        if (n == 0)
        { 
            return target % arr[n] == 0 ? target / arr[n] + count : 1000; 
        }
        if (target == 0) return count;

        if (dp[n, target] != 0)
            return dp[n, target];

        int notTakeCount = GetMinCoin(arr, target, n - 1, count, dp);
        int takeCount = int.MaxValue;
        if (target >= arr[n])
            takeCount = GetMinCoin(arr, target - arr[n], n, count + 1, dp); // will won't unti the target is less then the arr[n]
                                                                            // since duplicate is allowed

        return dp[n, target] = Math.Min(takeCount, notTakeCount);
    }

    public static int GetMinCoin2(int[] arr, int target, int n, int[,] dp)
    {
        if (target == 0) return 0;
        if (n == 0)
        {
            return target % arr[n] == 0 ? target / arr[n] : 1000; 
        }

        if (dp[n, target] != 0)
                return dp[n, target];

        int notTake = GetMinCoin2(arr, n - 1, target, dp);
        int take = 1000;
        if (target >= arr[n])
            take = 1 + GetMinCoin2(arr, n, target - arr[n], dp);
            
        return dp[n, target] = Math.Min(take, notTake);
    }

    public static int GetMinCoinTabulation(int[] arr, int target, int n)
    {
        int[,] dp = new int[arr.Length, target + 1];

        for (int t = 0; t <= target; t++)
        {
            if (t % arr[0] == 0)
                dp[0, t] = t / arr[0];
            else
                dp[0, t] = 1000;
        }

        for (int i = 1; i <= n; i++)
        {
            for (int t = 0; t <= target; t++)
            {
                int notTake = dp[i - 1, t];
                int take = 1000;
                if (arr[i] <= t)
                    take = 1+ dp[i, t - arr[i]];

                dp[i, t] = Math.Min(take, notTake);
            }
        }

        return dp[n, target];  
    }
}