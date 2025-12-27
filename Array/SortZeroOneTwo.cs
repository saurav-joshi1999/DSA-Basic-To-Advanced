using System.Runtime.InteropServices;
using System.Security.AccessControl;

public static class Sort
{
    public static void mainn()
    {
        int[] arr = { 2, 1, 2, 1, 0, 0, 0, 2, 1,0 };
        SortOneTwoZero(arr);
        System.Console.WriteLine(string.Join( ", ",arr));
    }

    public static void SortOneTwoZero(int[] arr)
    {
        // int i = 0; int j = 1; int k = arr.Length - 1;

        // for (int a = 1; a < arr.Length; a++)
        // {
        //     if (arr[a] == 1)
        //     {

        //     }
        // }

        int l = 0; int mid = 0; int h = arr.Length - 1;
        while (mid < h)
        {
            if (arr[mid] == 0)
            {
                Swap(l, mid, arr);
                l++;
                mid++;
            }
            else if (arr[mid] == 1)
            {
                mid++;
            }
            else
            {
                Swap(mid, h, arr);
                //mid++;
                h--;
            }
        }
    }

    public static void Swap(int i, int j, int[] arr)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }
}