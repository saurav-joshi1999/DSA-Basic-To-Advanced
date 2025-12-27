using System.Reflection.PortableExecutable;

public class Solution
{
    public List<int> TargetIndices(int[] nums, int target)
    {

        if (nums.Length == 0) return new List<int>();

        List<int> arr = new List<int>();
        QuickSort(nums, target, arr, 0, nums.Length - 1);
        return arr;
    }

    public void QuickSort(int[] nums, int target, List<int> arr, int s, int e)
    {
        if (s < e)
        {
            int ind = partition(nums, s, e);
            if (nums[ind] == target)
                arr.Add(ind);


                //if (nums[ind] <= target)
                QuickSort(nums, target, arr, s, ind - 1);
            //else
            QuickSort(nums, target, arr, ind + 1, e);
        }
    }

    public int partition(int[] nums, int s, int e)
    {
        int ind = -1;
        for (int i = s; i < e; i++)
        {
            if (nums[i] < nums[e])
            {
                ind++;
                swap(nums, ind, i);
            }

        }

        ind++;
        swap(nums, ind, e);
        return ind;
    }

    public void swap(int[] nums, int i, int j)
    {
        int temp = nums[i];
        nums[i] = nums[j];
        nums[j] = temp;
    }

    public void SortSentence(string s)
    {

        string[] lt = new string[s.Split(" ").Length];
        int j = 0;
        for (int i = 0; i < s.Count(); i++)
        {
            if (int.TryParse(s[i].ToString(), out int pp))
            {
                lt[pp-1] = s.Substring(j, i-j);
                j = i + 2;
            }
        }

        string str = string.Join(" ", lt).Trim();
        Console.WriteLine(str);
    }
}