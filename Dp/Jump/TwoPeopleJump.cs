using System.Runtime;

public static class TwoPeopleJump
{
    public static void mainn()
    {
        int[][] arr = { new[] { 1, 2, 3 }, new[] { 1, 4, 1 }, new[] { 4, 4, 1 } };
        int[,,] dp = new int[3, 3, 3];
        int[,,] dp1 = new int[3, 3, 3];
        Console.WriteLine("Get Point by both : " + GetMaxPointForBoth(arr, 0, 0, 2, 2, dp));
        Console.WriteLine("Get Point by both : " + GetMaxPointForBothTabulation(arr, 2, dp1));
    }

    public static int GetMaxPointForBoth(int[][] arr, int i, int j1, int j2, int n, int[,,] dp)
    {
        if (j1 > n || j1 < 0 || j2 > n || j2 < 0 || i > n)
            return -100;

        if (dp[i, j1, j2] != 0)
            return dp[i, j1, j2];

        if (i == n)
        {
            if (j1 == j2)
                return dp[i, j1, j2] = arr[n][j1];
            return dp[i, 1, j2] = arr[n][j1] + arr[n][j2];
        }
        int maxi = -1;
        for (int d1 = -1; d1 <= 1; d1++)
        {
            for (int d2 = -1; d2 <= 1; d2++)
            {
                if (j1 == j2)
                    maxi = Math.Max(GetMaxPointForBoth(arr, i + 1, j1 + d1, j2 + d2, n, dp) + arr[i][j1], maxi);
                else
                    maxi = Math.Max(GetMaxPointForBoth(arr, i + 1, j1 + d1, j2 + d2, n, dp) + arr[i][j1] + arr[i][j2], maxi);
            }
        }

        return dp[i, j1, j2] = maxi;
    }

    public static int GetMaxPointForBothTabulation(int[][] arr, int n, int[,,] dp)
    {
        for (int j3 = 0; j3 <= n; j3++)
        {
            for (int j4 = 0; j4 <= n; j4++)
            {
                if (j3 == j4)
                    dp[n, j3, j4] = arr[n][j3];
                else
                {
                    dp[n, j3, j4] = arr[n][j3] + arr[n][j4];
                }
            }
        }

        for (int r = n - 1; r >= 0; r--)
        {
            // since in Tabulation we are moving from non-fixed start value to non-fixed and value, 
            // in recursion were moving from fixed start value to non-fixed end value.
            for (int c1 = 0; c1 <= n; c1++)
            {
                for (int c2 = 0; c2 <= n; c2++)
                {
                    int maxi = -100;
                    for (int d1 = -1; d1 <= 1; d1++)
                    {
                        for (int d2 = -1; d2 <= 1; d2++)
                        {
                            int val = 0;
                            if (c1 == c2)
                                val = arr[r][c1];
                            else
                                val = arr[r][c1] + arr[r][c2];
                            if (c1 + d1 <= n && c1 + d1 >= 0 && c2 + d2 <= n && c2 + d2 >= 0)
                                val += dp[r + 1, c1 + d1, c2 + d2];
                            else
                                val += -100;
                            maxi = Math.Max(maxi, val);
                        }
                    }
                    dp[r, c1, c2] = maxi;
                }
            }
        }

        return dp[0, 0, n];
    }
}