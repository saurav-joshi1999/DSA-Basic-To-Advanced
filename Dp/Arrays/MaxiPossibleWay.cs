using System.Reflection.Metadata.Ecma335;

public static class MaxPath
{
    public static void Mainn()
    {
        int[][] arr = { new[] { 1, 2, 3 }, new[] { 4, 2, 6 }, new[] { 2, 8, 9 }, new[] { 3, 2, 3 }, new int[] { 2, 2, 1 } };
        int[][] dp = { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };
        dp[0][0] = arr[0][0];
        int[][] dp2 = { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };
        int[][] dp3 = { new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 }, new int[] { 0, 0, 0 } };
        // Console.WriteLine("Get Max Path to (0,0) : " + GetMaxPath(arr, 2, 2, dp));
        // Console.WriteLine("Get Max Path with Obstables (0,0) : " + GetMaxPathWithOstacles(arr, 2, 2));
        //Console.WriteLine("Get Min Path Value (0,0) : " + GetMinPathValue(arr, 2, 2, dp));
        //Console.WriteLine("Get Min Path Value with Tabulation (0,0) : " + GetMinPathValueTabulation(arr, 2, 2, dp));
        //Console.WriteLine("Get Min Path Value with Obstacles (0,0) : " + GetMinPathValueWithObstacles(arr, 2, 2, dp));
        //Console.WriteLine("Get Min Path Value with Obstacles in Tabulation (0,0) : " + GetMinPathValueTabulationWithObstacles(arr, 2, 2, dp2));
        int mini = int.MaxValue;
        for (int j = 0; j <= 2; j++)
        {
            int sum = MinValWithVariableStartAndEndPoint(arr, 4, j, dp2);
            mini = Math.Min(sum, mini);
        }
        Console.WriteLine("Get Min Path Value with Variable start and end : " + mini);

        Console.WriteLine("Get Min Path Value with Variable start and end Tabulation : " + MinValWithVariableStartAndEndPointWithTabulation(arr, 4, 2, dp3));
    }
    private static int GetMaxPath(int[][] arr, int i, int j, int[][] dp)
    {
        if (i == 0 && j == 0)
            return dp[i][j];

        if (i < 0 || j < 0)
            return 0;

        if (dp[i][j] != 0)
            return dp[i][j];

        int up = GetMaxPath(arr, i - 1, j, dp);
        int left = GetMaxPath(arr, i, j - 1, dp);
        return dp[i][j] = up + left;
    }

    private static int GetMaxPathWithOstacles(int[][] arr, int i, int j)
    {
        if (i == 0 && j == 0)
            return 1;
        if (i < 0 || j < 0)
            return 0;

        if (arr[i][j] == -1)
            return 0;

        int up = GetMaxPathWithOstacles(arr, i - 1, j);
        int left = GetMaxPathWithOstacles(arr, i, j - 1);
        return up + left;
    }

    private static int GetMinPathValue(int[][] arr, int i, int j, int[][] dp)
    {
        if (i == 0 && j == 0)
            return dp[0][0];

        if (i < 0 || j < 0)
            return int.MaxValue;

        if (dp[i][j] != 0) return dp[i][j];

        int up = GetMinPathValue(arr, i - 1, j, dp);
        int left = GetMinPathValue(arr, i, j - 1, dp);
        return dp[i][j] = arr[i][j] + Math.Min(up, left);
    }

    private static int GetMinPathValueWithObstacles(int[][] arr, int i, int j, int[][] dp)
    {
        if (i == 0 && j == 0)
            return dp[0][0];

        if (i < 0 || j < 0)
            return int.MaxValue;

        if (arr[i][j] == -1)
            return dp[i][j] = int.MaxValue;

        if (dp[i][j] != 0) return dp[i][j];

        int up = GetMinPathValueWithObstacles(arr, i - 1, j, dp);
        int left = GetMinPathValueWithObstacles(arr, i, j - 1, dp);
        int minPath = Math.Min(up, left);
        return dp[i][j] = (minPath == int.MaxValue) ? int.MaxValue : arr[i][j] + minPath;
    }

    private static int GetMinPathValueTabulationWithObstacles(int[][] arr, int r, int c, int[][] dp)
    {
        for (int i = 0; i <= r; i++)
        {
            for (int j = 0; j <= c; j++)
            {
                if (arr[i][j] == -1)
                {
                    dp[i][j] = int.MaxValue;
                    continue;
                }

                int up = i > 0 ? dp[i - 1][j] : int.MaxValue;
                int left = j > 0 ? dp[i][j - 1] : int.MaxValue;
                int minValue = Math.Min(up, left);
                dp[i][j] = minValue == int.MaxValue ? int.MaxValue : arr[i][j] + minValue;
            }
        }

        return dp[r][c] == int.MaxValue ? -1 : dp[r][c];
    }

    public static int MinValWithVariableStartAndEndPoint(int[][] arr, int r, int c, int[][] dp)
    {
        if (r < 0 || c < 0 || c > 2) return int.MaxValue;
        if (r == 0)
            return arr[0][c];

        if (dp[r][c] != 0) return dp[r][c];

        int left = MinValWithVariableStartAndEndPoint(arr, r - 1, c - 1, dp);
        int down = MinValWithVariableStartAndEndPoint(arr, r - 1, c, dp);
        int right = MinValWithVariableStartAndEndPoint(arr, r - 1, c + 1, dp);
        int mini = Math.Min(Math.Min(left, down), right);
        return dp[r][c] = mini == int.MaxValue ? int.MaxValue : arr[r][c] + mini;
    }

    public static int MinValWithVariableStartAndEndPointWithTabulation(int[][] arr, int r, int c, int[][] dp)
    {
        for (int j = 0; j <= c; j++)
        {
            dp[0][j] = arr[0][j];
        }

        for (int i = 1; i <= r; i++)
        {
            for (int j = 0; j <= c; j++)
            {
                int left = int.MaxValue, right = int.MaxValue;
                if (j > 0)
                {
                    left = dp[i-1][j - 1];
                }
                if (j < 2)
                {
                    right = dp[i-1][j + 1];
                }
                dp[i][j] = arr[i][j] + Math.Min(Math.Min(dp[i-1][j], left), right);
            }
        }

        return dp[r][c];
    }
}