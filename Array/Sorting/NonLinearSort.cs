

using System.Collections;
using System.Collections.Concurrent;

public static class NonLinearSort
{
    public static void MergeSort(int[] arr, int s, int l)
    {
        if (s < l)
        {
            int mid = s + (l - s) / 2;
            MergeSort(arr, s, mid);
            MergeSort(arr, mid + 1, l);
            CombineArray(arr, s, mid, l);
        }
    }

    private static void CombineArray(int[] arr, int s, int mid, int l)
    {
        List<int> temp = new List<int>();
        int i = s; int j = mid + 1;
        while (i <= mid && j <= l)
        {
            if (arr[i] > arr[j])
            {
                temp.Add(arr[j]);
                j++;
            }
            else
            {
                temp.Add(arr[i]);
                i++;
            }
        }

        while (i <= mid)
        {
            temp.Add(arr[i]);
            i++;
        }

        while (j <= l)
        {
            temp.Add(arr[j]);
            j++;
        }

        for (int p = 0; p < temp.Count; p++)
        {
            arr[p + s] = temp[p];
        }

    }

    public static void QuickSort(int[] arr, int s, int e) // based in pivot and partition
    {
        if (s < e)
        {
            int ind = Partition(arr, s, e);
            QuickSort(arr, s, ind - 1);
            QuickSort(arr, ind + 1, e);
        }
    }

    private static int Partition(int[] arr, int s, int e)
    {
        int ind = s-1; int j = s;
        while (j < e)
        {
            if (arr[j] > arr[e])
            {
                ind++;
                swap(arr, j, ind);
            }

            j++;
        }

        ind++;
        swap(arr, ind, e);
        return ind;
    }

    private static void swap(int[] arr, int v1, int v2)
    {
        int temp = arr[v1];
        arr[v1] = arr[v2];
        arr[v2] = temp;
    }
}