
public static class Max2DScore
{
    public static void GetMaxSPoints(int[][] arr, int n)
    {
        int[][] dp = { new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 }, new int[] { 0, 0, 0, 0 } };
        //Console.WriteLine("Maxi Points : "+GetSPoints(arr, arr.Length-1, 3, dp));
        Console.WriteLine("Maxi Points Tabulaion : " + GetPointWithTabulation(arr, arr.Length - 1, 3, dp));
    }

    private static int GetPointWithTabulation(int[][] arr, int day, int last, int[][] dp)
    {
        for (int i = 0; i <= last; i++)
            {
                int max = 0;
                for (int task = 0; task <= 2; task++)
                {
                    if (task != last)
                        max = Math.Max(max, arr[0][task]);
                }
                dp[0][last] = max;
            }
        

        for (int i = 1; i <= day; i++)
        {
            for (int lt = 0; lt <= last; lt++)
            {
                for (int task = 0; task <= 2; task++)
                {
                    if (task != last)
                    {
                        int point = arr[i][task] + dp[i - 1][task];
                        dp[i][lt] = Math.Max(point, dp[i][lt]);
                    }
                }
            }
        }

        return dp[day][3];
    }

    private static int GetSPoints(int[][] arr, int day, int last, int[][] dp)
    {
        if (day == 0)
        {
            int max = 0;
            for (int j = 0; j <= 2; j++)
            {
                if (j != last)
                    max = Math.Max(max, arr[0][j]);
            }
            return max;
        }

        if (dp[day][last] != 0)
            return dp[day][last];

        int maxi = 0;
        int point = 0;
        for (int j = 0; j <= 2; j++)
        {
            if (j != last)
                point = arr[day][j] + GetSPoints(arr, day - 1, j, dp);
            maxi = Math.Max(point, maxi);
        }

        return dp[day][last] = maxi;
    }
}