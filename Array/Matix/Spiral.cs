public static class Spiral
{
    public static void SpiralOrder(int[][] matrix)
    {
        // Write your code here
        // Return a List<int> containing elements in spiral order
        int top = 0; int bottom = matrix.Length-1;
        int left = 0; int right = matrix[0].Length-1;

        while (top <= bottom && left <= right)
        {
            for (int i = left; i <= right; i++)
            {
                int val = matrix[top][i];
                Console.Write(" ",val) ;
            }
            top++;

            for (int i = top; i <= bottom; i++)
            {
                int val = matrix[i][right];
                Console.Write(" ",matrix[i][right]);
            }
            right--;

            if (top <= bottom)
            {
                for (int i = right; i >= left; i--)
                {
                    int val = matrix[bottom][i];
                    Console.Write(" ",matrix[bottom][i]);
                }
                bottom--;
            }

            if (left <= right)
            {
                for (int i = bottom; i >= top; i--)
                {
                    int val = matrix[i][left];
                    Console.Write(" ",matrix[i][left]);
                }
                left++;
            }
        }
    }
}