public static class GetTargetSum
{
    public static void getIndexLists(List<int> arr, int target)
    {
        arr.Sort();
        List<string> lt = new List<string>();
        int p1 = 0; int p2 = arr.Count - 1;
        while (p1 < p2)
        {
            int sum = arr[p1] + arr[p2];
            if (sum == target)
            {
                lt.Add($"({arr[p1]}, {arr[p2]})");
                p1++;p2--;
            }
            else if (sum > target)
                p2--;
            else
                p1++;
        }

        Console.WriteLine(string.Join(", " , lt));
    }
}