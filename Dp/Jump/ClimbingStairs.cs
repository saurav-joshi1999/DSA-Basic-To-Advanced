public static class ClimblingStairs
{ 
    public static int ClimbingStair(int[] arr, int n)
        {
            if (n == 0) return 0;

            int oneStep = ClimbingStair(arr, n - 1) + Math.Abs(arr[n] - arr[n - 1]);
            int twoStep = int.MaxValue;

            if (n > 1)
                twoStep = ClimbingStair(arr, n - 2) + Math.Abs(arr[n] - arr[n - 2]);

            return Math.Min(oneStep, twoStep);
        }

       public static int ClimbingStairMemoisationWithKJump(int[] arr, int n, int[] dp, int k)
        {
            if (n == 0) return 0;

            if (dp[n] != -1) return dp[n];

            int minEnergy = int.MaxValue;
            //int twoStep = 0;
            for (int i = 1; i <= k; i++)
            {
                if (n - i >= 0)
                {
                    int twoStep = dp[n] = ClimbingStair(arr, n - i) + Math.Abs(arr[n] - arr[n - i]);
                    minEnergy = Math.Min(minEnergy, twoStep);
                }
            }

            dp[n] = minEnergy;
            return dp[n];
        }


       public static int ClimbingStairsWithTabularionWithKJump(int[] arr, int n, int[] dp, int k)
        {
            if (n == 0) return 0;
            dp[0] = 0;

        
            for (int i = 1; i <=n; i++)
            {
                int minEnergy = int.MaxValue;
                for (int j = 1; j <= k; j++)
                {
                    if (i - j >= 0)
                    {
                        int stepEn = dp[i - j] + Math.Abs(arr[i] - arr[i - j]);
                        minEnergy = Math.Min(stepEn, minEnergy);
                    }
                }
                
                dp[i] = minEnergy;
            }

            return dp[n];
        }
}