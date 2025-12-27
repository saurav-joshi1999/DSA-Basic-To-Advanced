public static class MatrixZero
{
    public static void MarkRowAndColZero(int[][] arr, int r, int c)
    {
        if (r < 0 || c < 0) return;

        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (arr[i][j] == 0)
                {
                    MarkRow(arr, i, c);
                    MarkCol(arr, j, r);
                }
            }
        }

        MarkNegativeToZero(arr, r, c);
    }

    private static void MarkNegativeToZero(int[][] arr, int r, int c)
    {
        for (int i = 0; i < r; i++)
        {
            for (int j = 0; j < c; j++)
            {
                if (arr[i][j] == -1)
                {
                    arr[i][j] = 0;
                }
            }
        }
    }

    private static void MarkCol(int[][] arr, int j, int r)
    {
        for (int i = 0; i < r; i++)
        {
            if (arr[i][j] != 0)
            {
                arr[i][j] = -1;
            }
        }
    }

    private static void MarkRow(int[][] arr, int i, int c)
    {
        for (int j = 0; j < c; j++)
        {
            if (arr[i][j] != 0)
            {
                arr[i][j] = -1;
            }
        }
    }
}