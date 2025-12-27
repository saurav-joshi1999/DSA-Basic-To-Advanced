public static class GetMinSum
{
    public static void WriteMethods()
    {
        int[][] arr = { new[] { 1 }, new int[] { 2, 3 }, new[] { 3, 4, 5 }, new[] { 6, 7, 8, 9 } };
        int[][] dp = { new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 } };
        int[][] dp1 = { new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 } };
        int minVal = int.MaxValue;
        for (int j = 0; j <= 3; j++)
        {
            minVal = Math.Min(JumpBelowOrSideOfTraingle(arr, 3, j), minVal);
        }
        Console.WriteLine("Min Traingle Jump From bottom :" + minVal);
        Console.WriteLine("Min Traingle Jump From Top :" + JumpBelowOrSideOfTraingleStartFromTop(arr, 0, 0, 3, dp));
        Console.WriteLine("Min Traingle Jump From Top :" + JumpBelowOrSideOfTrainglBottomToTopTabula(arr, 3, 3,dp1));
    }

    // we need the for loop to check for all the col, which we have called in its calling methods
    private static int JumpBelowOrSideOfTraingle(int[][] arr, int r, int c)
    {
        if (r < 0 || c < 0 || c > r)
            return int.MaxValue;

        if (r == 0)
            return arr[0][0];

        int up = JumpBelowOrSideOfTraingle(arr, r - 1, c);
        int left = JumpBelowOrSideOfTraingle(arr, r - 1, c - 1);
        return arr[r][c] + Math.Min(up, left);
    }

    // In this code top is fixed that why we do not need for loop to check for all the col.
    private static int JumpBelowOrSideOfTraingleStartFromTop(int[][] arr, int i, int j, int rc, int[][] dp)
    {
        if (i == rc) return arr[i][j];

        if (dp[i][j] != 0)
            return dp[i][j];

        int down = JumpBelowOrSideOfTraingleStartFromTop(arr, i + 1, j, rc, dp);
        int right = JumpBelowOrSideOfTraingleStartFromTop(arr, i + 1, j + 1, rc, dp);
        return dp[i][j] = arr[i][j] + Math.Min(down, right);
    }

    public static int JumpBelowOrSideOfTrainglBottomToTopTabula(int[][] arr, int r, int c, int[][] dp)
    {
        for (int j = 0; j <= c; j++)
        {
            dp[r][j] = arr[r][j];
        }
        for (int i = r - 1; i >= 0; i--)
        {
            for (int j = i; j >=0; j--)
            {
                int up = arr[i][j] + dp[i + 1][j];
                int left = arr[i][j] + dp[i + 1][j + 1];
                dp[i][j] = Math.Min(up, left);
            }
        }
        return dp[0][0];
    }
}