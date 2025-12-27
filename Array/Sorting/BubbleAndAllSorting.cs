public static class Sorting
{ 
    //Fibonacci series - 
        // 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, ...
        public static int Fibonacii(int n)
        {
            if (n <= 1)
                return n;

            return Fibonacii(n - 1) + Fibonacii(n - 2);
        }

        //dp
        public static int DpFibonacci(int n, int[] dp)
        {
            if (n <= 1)
                return n;

            if (dp[n] != -1)
                return dp[n];

            dp[n] = DpFibonacci(n - 1, dp) + DpFibonacci(n - 2, dp);
            return dp[n];
        }

        public static int TabulationFibo(int n, int[] dp)
        {
            if (n <= 1)
                return n;

            for (int i = 2; i < n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n - 1];
        }

        public static void bubbleSOrt(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }

            Console.Write(string.Join(", ", arr));
        }

        // find minium element ina aaray and put it on its sorted position
        public static void selectionSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                int posi = i;
                for (int j = i + 1; j < arr.Length - 1; j++)
                {
                    if (arr[posi] < arr[j])
                    {
                        posi = j;
                    }
                }
                int temp = arr[i];
                arr[i] = arr[posi];
                arr[posi] = temp;
            }

            Console.WriteLine(string.Join(", ", arr));
        }

        // select the temp array and put it into its actual position
        public static void insertionSort(int[] arr)
        {
            for (int i = 1; i < arr.Length; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= 0 && temp > arr[j])
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = temp;
            }

            Console.WriteLine(string.Join(", ", arr));
        }

}