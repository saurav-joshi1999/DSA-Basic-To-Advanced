using System.Reflection;


    public static class ArrayProblem
    {
        public static int RemoveDuplicates(int[] nums)
        {
            int j = 0;
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] != nums[j])
                {
                    j++;
                nums[j] = nums[i];
                }
            }
            return j +1;
        }

        // private static void Main(string[] args)
        // {
        //     int[] arr = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
        //     int size = RemoveDuplicates(arr);
        //     Console.WriteLine(string.Join(", ", arr));
        // }
    }
