public static class Knapsnap
{
    public static void mainn()
    {
        int[] itemsValues = { 5, 11, 13 };
        int[] itemsWeight = { 2, 4, 6 };
        int bagWeightCapacity = 10;
        int[,] dp = new int[itemsValues.Length, bagWeightCapacity + 1];
        int maxLoot = GetMaxMoneyItem(itemsValues.Length - 1, itemsValues, itemsWeight, bagWeightCapacity, dp);
        //int maxLoot = GetMaxMoneyItemTabulation(itemsValues.Length - 1, itemsValues, itemsWeight, bagWeightCapacity, dp);
        Console.WriteLine("Maximum Loots : " + maxLoot);
        Console.WriteLine("Maximum Loots with Repeatations : " +
        KanpSnakWithInfiniteSupply(itemsValues, itemsWeight, bagWeightCapacity, itemsValues.Length - 1));
    }

    public static int GetMaxMoneyItem(int n, int[] itemValues, int[] itemsWeight, int bagCapacity, int[,] dp)
    {
        if (n < 0 || bagCapacity <= 0) return 0;
        // if (n == 0)
        // {
        //    return itemsWeight[n] <= bagCapacity ? itemValues[n] : 0;
        // }

        if (dp[n, bagCapacity] != 0) return dp[n, bagCapacity];
        int notTake = GetMaxMoneyItem(n - 1, itemValues, itemsWeight, bagCapacity, dp);
        int take = int.MinValue;
        if (bagCapacity - itemsWeight[n] >= 0)
            take = GetMaxMoneyItem(n - 1, itemValues, itemsWeight, bagCapacity - itemsWeight[n], dp) + itemValues[n];
        return dp[n, bagCapacity] = Math.Max(take, notTake);
    }

    public static int GetMaxMoneyItemTabulation(int n, int[] itemValues, int[] itemsWeight, int bagCapacity, int[,] dp)
    {
        for (int w = 0; w <= bagCapacity; w++)
        {
            dp[0, w] = itemValues[0];
        }

        for (int i = 1; i <= n; i++)
        {
            for (int w = 0; w <= bagCapacity; w++)
            {
                int notTake = dp[i - 1, w];
                int take = int.MinValue;
                if (w - itemsWeight[i] >= 0)
                    take = dp[i - 1, w - itemsWeight[i]] + itemValues[i];

                dp[i, w] = Math.Max(take, notTake);
            }
        }

        return dp[n, bagCapacity];
    }

    public static int KanpSnakWithInfiniteSupply(int[] val, int[] wt, int limit, int n)
    {
        if (n == 0)
        {
            return limit % wt[n] == limit ? -10000 : (limit / wt[n])*val[n];
        }

        int notTake = KanpSnakWithInfiniteSupply(val, wt, limit, n - 1);
        int take = -10000;
        if (wt[n] <= limit)
        {
            take = KanpSnakWithInfiniteSupply(val, wt, limit - wt[n], n) + val[n];
        }

        return Math.Max(take, notTake);
    }
}