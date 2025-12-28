



using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;

public static class CombineQuestion
{
    public static void mainn()
    {
        // //int miniBookLen = AllocatingBookWithMinPageDiff(new int[]{12,12,12,12}, 3);
        // int miniBookLen = MinLargestDistancePlacingCow([1, 2, 4, 8, 9], 3);
        // System.Console.WriteLine("Mini Book len : " + miniBookLen);
        MaxContinuousSumSubArray(new int[] {2,-2,5,-5-7,8,9,-10});
    }
    public static void Pairs(int[] arr, int i, List<string> lt)
    {
        if (i == arr.Length - 1) return;

        for (int j = i + 1; j < arr.Length; j++)
        {
            if (arr[i] > arr[j] * 2)
                lt.Add($"({arr[i]}, {arr[j]})");
        }
        Pairs(arr, i + 1, lt);   //TC - n2 
    }

    private static int qCount = 0;
    public static void NQueenProblem(string[,] arr, int j)
    {
        if (j == arr.GetLength(1))
        {
            qCount++;
            return;
        }

        for (int x = 0; x < arr.GetLength(0); x++)
        {
            if (CanPlace(arr, x, j))
            {
                arr[x, j] = "Q";
                NQueenProblem(arr, j + 1);
                arr[x, j] = "";
            }
        }
    }

    private static bool CanPlace(string[,] arr, int x, int j)
    {
        int dx = x;
        int dy = j;

        while (x >= 0 && j >= 0)
        {
            if (arr[x, j] == "Q")
                return false;
            x--;
            j--;
        }

        x = dx;
        j = dy;
        while (j >= 0)
        {
            if (arr[x, j] == "Q")
                return false;
            j--;
        }

        x = dx;
        j = dy;
        while (x < arr.GetLength(0) && j >= 0)
        {
            if (arr[x, j] == "Q")
                return false;
            x++;
            j--;
        }
        return true;
    }

    public static bool SudokuProblem(int[,] arr, int x)
    {
        int n = arr.GetLength(0);
        for (int i = x; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (arr[i, j] == 0)
                {
                    for (int s = 1; s <= 9; s++)
                    {
                        if (canAdd(s, i, j, arr))   // check if number can be add at this place.
                        {
                            arr[i, j] = s;

                            if (SudokuProblem(arr, i))  // if parent can sit at (i,j) and called the recursion for next 0 number.
                            {
                                return true;   // if child process return true, we won;t backtrack the value, 
                                               //no need to try any other no.
                            }
                            else
                            {
                                arr[i, j] = 0;  // backttrack, try other value of parent
                            }
                        }
                    }
                    return false;   //can't add any number at that empty place, will return false to parent method.

                }
            }
        }
        return true;   // at the end if all the zero are replaced, then return zero.

    }

    private static bool canAdd(int s, int i, int j, int[,] arr)
    {
        for (int x = 0; x < arr.GetLength(0); x++)
        {
            if (arr[i, x] == s)
                return false;

            if (arr[x, j] == s)
                return false;

            if (arr[(3 * (i / 3) + x / 3), 3 * (j / 3) + x % 3] == s)
                return false;
        }

        return true;
    }

    private static List<List<int>> llt = new List<List<int>>();
    public static void NumOfSubsequence(int[] arr, int i, List<int> lt)
    {
        if (i == arr.Length)
        {
            //llt.Add(lt);
            System.Console.WriteLine(string.Join(", ", lt));
            return;
        }

        lt.Add(arr[i]);
        NumOfSubsequence(arr, i + 1, lt);
        lt.Remove(arr[i]);
        NumOfSubsequence(arr, i + 1, lt);
    }

    public static int SubsequenceWithSumK(int[] arr, int k, int i, List<int> lt)
    {
        if (k == 0)
        {
            llt.Add(lt.ToList());
            return 1;
        }

        if (k < 0 || i > arr.Length)
            return 0; ;

        lt.Add(arr[i]);
        int take = SubsequenceWithSumK(arr, k - arr[i], i + 1, lt);

        lt.Remove(arr[i]);
        int notTake = SubsequenceWithSumK(arr, k, i + 1, lt);
        return take + notTake;
    }

    public static void SumWithRepeatation(int[] arr, int i, int k, List<int> lt)
    {
        if (k == 0)
        {
            llt.Add(lt.ToList());
            return;
        }

        if (i == arr.Length || k < 0)
            return;


        lt.Add(arr[i]);
        //SumWithRepeatation(arr, i + 1, k - arr[i], lt); 
        SumWithRepeatation(arr, i, k - arr[i], lt);


        //lt.Remove(arr[i]);
        lt.Remove(arr[i]);
        SumWithRepeatation(arr, i + 1, k, lt);
    }

    public static int SumWithRepeatationCount(int[] arr, int i, int k)
    {
        if (k == 0)
        {
            return 1;
        }

        if (i == arr.Length || k < 0)
            return 0;


        return SumWithRepeatationCount(arr, i + 1, k) + SumWithRepeatationCount(arr, i, k - arr[i]);
        //SumWithRepeatation(arr, i + 1, k - arr[i], lt);    
    }

    static List<List<string>> pathList = new List<List<string>>();

    public static bool AllPathToReachEnd2(int[,] arr, int i, int j, List<int> lt)
    {
        if (i == arr.GetLength(0) || j == arr.GetLength(1))
            return false;

        if (i == arr.GetLength(0) - 1 && j == arr.GetLength(1) - 1)
        {
            List<int> newLt = lt.ToList();
            newLt.Add(arr[i, j]);
            llt.Add(newLt);
            return true;
        }

        //bool rightDirec = false;
        lt.Add(arr[i, j]);
        bool rightDirec = AllPathToReachEnd2(arr, i, j + 1, lt);
        bool leftDirec = AllPathToReachEnd2(arr, i + 1, j, lt);
        // if (rightDirec || leftDirec)
        // {
        lt.Remove(arr[i, j]);
        //}
        return rightDirec || leftDirec;
    }

    public static int AllPathToReachEnd(int[,] arr, int i, int j)
    {
        if (i == arr.GetLength(0) || j == arr.GetLength(1))
            return 0;

        if (i == arr.GetLength(0) - 1 && j == arr.GetLength(1) - 1)
        {
            return 1;
        }

        int rightDirec = AllPathToReachEnd(arr, i, j + 1);
        int leftDirec = AllPathToReachEnd(arr, i + 1, j);
        return rightDirec + leftDirec;
    }

    public static void Sort123Arr(int[] arr)
    {
        int s = 0; int mid = s + 1; int l = arr.Length - 1;
        while (mid < l)
        {
            if (arr[mid] == 0)
            {
                swap(mid, s, arr);
                s++;
                //mid++;
            }

            if (arr[mid] == 2)
            {
                swap(mid, l, arr);
                l--;
            }

            if (arr[mid] == 1)
                mid++;
        }
    }

    private static void swap(int i, int j, int[] arr)
    {
        int temp = arr[i];
        arr[i] = arr[j];
        arr[j] = temp;
    }

    public static int SingleReapted(int[] arr)
    {
        int slow = arr[0];
        int fast = slow;

        do
        {
            slow = arr[slow];
            fast = arr[arr[fast]];
        }
        while (slow != fast);

        slow = arr[0];
        while (slow != fast)
        {
            slow = arr[slow];
            fast = arr[fast];
        }

        return slow;
    }

    static List<List<string>> llt1 = new List<List<string>>();
    public static bool MazeProblem(int[,] arr, int i, int j, List<string> lt, bool[,] isVisited)
    {
        if (i >= arr.GetLength(0) || j >= arr.GetLength(1) || i < 0 || j < 0)
        {
            return false;
        }

        if (i == arr.GetLength(0) - 1 && j == arr.GetLength(1) - 1)
        {
            llt1.Add(lt.ToList());
            return true;
        }

        if (arr[i, j] == 1 && !isVisited[i, j])
        {
            isVisited[i, j] = true;

            lt.Add("D");
            bool down = MazeProblem(arr, i + 1, j, lt, isVisited);
            lt.RemoveAt(lt.Count - 1);
            //isVisited[i, j] = false;

            lt.Add("U");
            //isVisited[i, j] = true;
            bool up = MazeProblem(arr, i - 1, j, lt, isVisited);
            lt.RemoveAt(lt.Count - 1);
            //isVisited[i, j] = false;

            lt.Add("R");
            //isVisited[i, j] = true;
            bool right = MazeProblem(arr, i, j + 1, lt, isVisited);
            lt.RemoveAt(lt.Count - 1);
            //isVisited[i, j] = false;

            lt.Add("L");
            //isVisited[i, j] = true;
            bool left = MazeProblem(arr, i, j - 1, lt, isVisited);
            lt.RemoveAt(lt.Count - 1);

            isVisited[i, j] = false;

            if (down || up || right || left)
                return true;
        }
        return false;
    }

    public static void AllPermutation(int[] arr, List<int> lt, bool[] isVisited)
    {
        if (lt.Count == arr.Count())
        {
            llt.Add(lt.ToList());
            return;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (!isVisited[i])
            {
                lt.Add(arr[i]);
                isVisited[i] = true;
                AllPermutation(arr, lt, isVisited);
                lt.RemoveAt(lt.Count - 1);
                isVisited[i] = false;
            }
        }
    }

    public static void PalindromePartition(string str, int i, List<string> lt)
    {
        if (i == str.Length)
        {
            llt1.Add(lt.ToList());
            return;
        }

        for (int k = i; k < str.Length; k++)
        {
            if (isPalindrome(str, i, k))
            {
                lt.Add(str.Substring(i, k - i + 1));
                PalindromePartition(str, k + 1, lt);
                lt.RemoveAt(lt.Count - 1);
            }
        }
    }

    private static bool isPalindrome(string str, int i, int k)
    {
        while (i < k)
        {
            if (str[i] == str[k])
            {
                i++; k--;
            }
            else
                return false;
        }
        return true;
    }

    public static void AllCombinationToGetSumK(int[] arr, int i, int k, List<int> lt)
    {
        if (k == 0)
        {
            llt.Add(lt.ToList());
            return;
        }

        if (i == arr.Length || k < 0)
            return;

        lt.Add(arr[i]);
        AllCombinationToGetSumK(arr, i, k - arr[i], lt);
        lt.Remove(arr[i]);
        //lt.Remove(lt.Count-1);
        AllCombinationToGetSumK(arr, i + 1, k, lt);
    }

    public static int mergeSort(int[] arr, int l, int r)
    {
        int pairCount = 0;
        if (l < r)
        {
            int m = (l + r) / 2;
            pairCount += mergeSort(arr, l, m);
            pairCount += mergeSort(arr, m + 1, r);
            pairCount += merge(arr, l, m, r);
        }
        return pairCount;
    }

    private static int merge(int[] arr, int l, int m, int r)
    {
        int pairCount = 0;
        int[] temp = new int[r - l + 1];    // i am sorting it here but i and j value if fixed when the compare it, 
        // since i need to get the pair where (arr[i] > arr[j]) in a existing array. and merge sort can be use for it.
        int i = l; int j = m + 1; int k = 0;
        while (i <= m && j <= r)
        {
            if (arr[i] > arr[j])
            {
                pairCount += (r - j + 1);
                temp[k++] = arr[i++];
            }
            else
            {
                temp[k++] = arr[j++];
                //pairCount += m - i;
            }
        }

        while (i <= m)
        {
            temp[k++] = arr[i++];
        }

        while (j <= r)
        {
            temp[k++] = arr[j++];
        }

        for (int x = 0; x < temp.Length; x++)
        {
            arr[l + x] = temp[x];
        }
        return pairCount;
    }

    public static int maxProfitBuySellStock(int[] arr)
    {
        int mini = arr[0];
        int profit = 0;

        foreach (int prize in arr)
        {
            //mini = Math.Min(mini, prize);
            if (prize - mini > 0)
            {
                profit = Math.Max(prize - mini, profit);
            }
            else
            {
                mini = prize;
            }
        }
        return profit;
    }

    static int profit = 0;
    static int maxProfit = 0;
    public static int MaxProfitStockBuySellMultipleTime(int[] prize, int day, bool canBuy)
    {

        int profit = 0;
        for (int i = day; i < prize.Length; i++)
        {
            if (canBuy)
                profit = -prize[i] + MaxProfitStockBuySellMultipleTime(prize, i + 1, false);
            else
            {
                if (profit + prize[i] > 0)
                {
                    profit += prize[i] + MaxProfitStockBuySellMultipleTime(prize, i + 1, true);
                }
            }
            maxProfit = Math.Max(maxProfit, profit);
        }

        return profit;
    }

    static int maxLen = 0;
    public static int LongestIncrearingSequenceWithRepeating(string str, int l, int r, HashSet<int> set)
    {
        int maxLen = 0; string maxStr = "";
        for (int i = 0; i <= r; i++)
        {
            while (set.Contains(str[i]))
            {
                set.Remove(str[l]);
                l++;
            }

            set.Add(str[i]);
            maxLen = Math.Max(maxLen, i - l + 1);
            maxStr = maxStr.Length < maxLen ? str.Substring(l, maxLen) : maxStr;
        }
        System.Console.WriteLine("Max String : " + maxStr);
        return maxLen;
    }

    public static void TwoSumProblem(List<int> arr, int k)
    {
        List<string> lt = new List<string>();
        int i = 0; int j = arr.Count - 1;
        while (i < j)
        {
            if (arr[i] + arr[j] > k)
            {
                j--;
            }
            else if (arr[i] + arr[j] < k)
                i++;
            else
            {
                lt.Add($"({arr[i]}, {arr[j]})");
                i++; j--;
            }
        }
        System.Console.WriteLine($"Sum Equal to {k} : " + string.Join(", ", lt));
    }

    public static List<List<int>> ThreeSumProblem(int[] arr)
    {
        Array.Sort(arr);
        List<List<int>> llt = new List<List<int>>();
        for (int i = 0; i < arr.Length - 2; i++)
        {
            if (i == 0 || i > 0 && arr[i] != arr[i - 1])
            {
                int j = i + 1; int k = arr.Length - 1;
                while (j < k)
                {
                    if (arr[j] + arr[k] == 0 - arr[i])
                    {
                        llt.Add(new List<int> { arr[i], arr[j], arr[k] });

                        while (j < k && arr[j] == arr[j + 1])
                            j++;
                        while (j < k && arr[k] == arr[k - 1])
                            k--;

                        j++;
                        k--;
                    }
                    else if (arr[j] + arr[k] < 0 - arr[i])
                        j++;
                    else
                        k--;
                }
            }
        }
        foreach (List<int> lt in llt)
        {
            System.Console.WriteLine(string.Join(", ", lt));
        }
        return llt;
    }

    public static void RemoveDuplicateInSortedArr(int[] arr)
    {
        int i = 0; int j = 1;
        while (j < arr.Length)
        {
            if (arr[i] != arr[j])
            {
                arr[++i] = arr[j];
            }
            j++;
        }

        System.Console.WriteLine(string.Join(", ", arr));
    }

    public static void MaxConsecutiveOne(int[] arr)
    {
        int count = 0; int i = 0; int j = 1; int maxCount = 0;
        while (i < arr.Length && j < arr.Length)
        {
            j = i + 1;
            if (arr[i] == 1)
            {
                count = 1;
                while (j < arr.Length && arr[i] == arr[j])
                {
                    count++;
                    j++;
                }
                i = j + 1;
            }
            i++;
            maxCount = Math.Max(maxCount, count);
        }

        System.Console.WriteLine("Max Count of 1 : " + maxCount);
    }

    public static void GetLongestConsecutiveSequence(int[] arr)
    {
        SortedSet<int> set = [.. arr]; int count = 0; int maxCount = 0;
        foreach (int i in arr)
        {
            if (set.Contains(i - 1))
            {
                continue;
            }
            else
            {
                count = 0;
                int j = i;
                while (set.Contains(j))
                {
                    count++;
                    j = j + 1;
                }
                maxCount = Math.Max(count, maxCount);
            }
        }

        System.Console.WriteLine("Longest Consecutive Series : " + maxCount);
    }

    public static void LargestSubArrayWithSumZero(int[] arr)
    {
        int sum = 0; int maxCount = 0;
        Dictionary<int, int> sumAtindex = new Dictionary<int, int>();
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
            if (sum == 0)
                maxCount = i + 1;
            else
            {
                if (sumAtindex.ContainsKey(sum))
                {
                    int index = sumAtindex[sum];
                    maxCount = Math.Max(maxCount, i - index);
                }
                else
                    sumAtindex[sum] = i;
            }
        }

        System.Console.WriteLine("Max Sub-Array with Sum 0: " + maxCount);
    }

    public class Meeting
    {
        public int start;
        public int end;
        public int pos;
        public Meeting(int start, int end, int pos)
        {
            this.start = start;
            this.end = end;
            this.pos = pos;

        }
    }
    public static List<int> NoOfMeetings(int[] start, int[] end)
    {
        List<Meeting> meetings = new List<Meeting>();
        for (int i = 0; i < start.Length; i++)
        {
            meetings.Add(new Meeting(start[i], end[i], i + 1));
        }

        meetings = meetings.OrderBy(meeting => meeting.end).ThenBy(meetting => meetting.pos).ToList();
        List<int> meetingPos = new List<int>();
        Meeting meeting = meetings.First();
        meetingPos.Add(meeting.pos);
        int limit = meeting.end;
        for (int i = 1; i < start.Length; i++)
        {
            if (meetings[i].start > limit)
            {
                meetingPos.Add(meetings[i].pos);
                limit = meetings[i].end;
            }
        }

        System.Console.WriteLine("Meeting that can be held : " + string.Join(", ", meetingPos));
        return meetingPos;
    }

    public static int MaxPlateformForTrain(int[] start, int[] end)
    {
        int maxiPlateform = 1;
        List<int> departures = new List<int>();
        departures.Add(end[0]);
        bool requiredNewPaltedform = true;
        for (int i = 1; i < start.Length; i++)
        {
            requiredNewPaltedform = true;
            for (int j = 0; j < departures.Count; j++)
            {
                if (departures[j] < start[i] || departures.Count < maxiPlateform)
                {
                    departures.Remove(departures[j]);
                    departures.Add(end[i]);
                    requiredNewPaltedform = false;
                    break;
                }
            }

            if (requiredNewPaltedform)
            {
                departures.Add(end[i]);
                maxiPlateform = Math.Max(departures.Count, maxiPlateform);
            }
        }

        System.Console.WriteLine("No. of Plateform required : " + maxiPlateform);
        return maxiPlateform;
    }

    public static int MaxPlateformForTrain2(int[] start, int[] end)
    {
        int currentRunningPlateform = 1; int maxiPlateformUsed = 1;
        int j = 0;
        for (int i = 1; i < start.Length; i++)
        {
            while (j < i)
            {
                if (start[i] > end[j])
                {
                    j++;
                    if (currentRunningPlateform == 1)
                        break;
                    currentRunningPlateform--;
                }
                else
                {
                    currentRunningPlateform++;
                    break;
                }
            }

            maxiPlateformUsed = Math.Max(currentRunningPlateform, maxiPlateformUsed);
        }
        System.Console.WriteLine("Max PlateForm used : " + maxiPlateformUsed);
        return maxiPlateformUsed;
    }

    public static int TapRainWater(int[] heights)
    {
        int l = 0; int r = heights.Length - 1;
        int leftMax = 0; int rightmax = 0;
        int water = 0;
        while (l < r)
        {
            if (heights[l] <= heights[r])
            {
                if (heights[l] >= leftMax)
                    leftMax = heights[l];
                else
                    water += leftMax - heights[l];
                l++;
            }
            else
            {
                if (heights[r] >= rightmax)
                    rightmax = heights[r];
                else
                    water += rightmax - heights[r];

                r--;
            }
        }

        System.Console.WriteLine("Trap rain water : " + water);
        return water;
    }

    public static List<List<int>> FourSum(int[] arr, int target)
    {
        Array.Sort(arr);
        List<List<int>> llt = new List<List<int>>();
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = i + 1; j < arr.Length - 1; j++)
            {
                int left = j + 1; int right = arr.Length - 1;
                int newTarget = target - arr[i] - arr[j];
                while (left < right)
                {
                    int pointSum = arr[left] + arr[right];
                    if (newTarget < pointSum)
                    {
                        right--;
                    }
                    else if (newTarget > pointSum)
                    {
                        left++;
                    }
                    else
                    {
                        List<int> lt = new List<int>() { arr[i], arr[j], arr[left], arr[right] };
                        llt.Add(lt);
                        while (left < right && lt[2] == arr[left])
                            left++;

                        while (right > left && lt[3] == arr[right])
                            right--;
                    }
                }

                while (j + 1 < arr.Length && arr[j + 1] == arr[j])
                    j++;
            }

            while (i + 1 < arr.Length && arr[i + 1] == arr[i])
                i++;
        }

        llt.ForEach(lt => System.Console.WriteLine(string.Join(",", lt)));
        return llt;
    }

    public static int KnapSack(int[] values, int[] weights, int i, int weight) // use the greedy approch sort and take
    {
        if (weight == 0)
            return 0;
        if (i == values.Length)
            return 0;

        int notTake = KnapSack(values, weights, i + 1, weight);
        int take = 0;
        if (weight >= weights[i])
            take = KnapSack(values, weights, i + 1, weight - weights[i]) + values[i];
        else
        {
            double val = (double)weight / weights[i];
            val = val * values[i];
            take = (int)val;
        }

        return int.Max(take, notTake);
    }

    public static void SubSetSum(int[] arr, int i, List<int> lt, int sum, int[,] dp)
    {
        if (i == arr.Length)
        {
            lt.Add(sum);
            return;
        }

        SubSetSum(arr, i + 1, lt, sum + arr[i], dp);
        SubSetSum(arr, i + 1, lt, sum, dp);
    }

    public static void AllSubSet(int[] arr, int i, List<int> lt, List<List<int>> llt)
    {
        if (i == arr.Length)
        {
            llt.Add(lt.ToList());
            return;
        }
        lt.Add(arr[i]);
        AllSubSet(arr, i + 1, lt, llt);
        lt.Remove(arr[i]);
        //lt.Remove(lt.Count-1);
        AllSubSet(arr, i + 1, lt, llt);
    }

    public static void AllCombinations(int[] arr, int i, List<int> lt, List<List<int>> llt, bool[] isVisited)
    {
        if (lt.Count == arr.Length)
        {
            llt.Add(lt.ToList());
            return;
        }
        for (int ind = 0; ind < arr.Length; ind++)
        {
            if (!isVisited[ind])
            {
                lt.Add(arr[ind]);
                isVisited[ind] = true;
                AllCombinations(arr, ind + 1, lt, llt, isVisited);
                isVisited[ind] = false;
                lt.Remove(arr[ind]);
            }
        }
    }

    public static void AllCombinationsUsingSwap(int[] arr, int ind, List<List<int>> llt)
    {
        // Base Case: When the 'ind' reaches the end, we have a complete permutation
        if (ind == arr.Length)
        {
            llt.Add(arr.ToList()); // Capture the current state of the array
            return;
        }

        for (int i = ind; i < arr.Length; i++)
        {
            // 1. Swap the current index element with the 'i' element
            swap(ind, i, arr);

            // 2. Recurse to the next index using 'ind + 1'
            AllCombinationsUsingSwap(arr, ind + 1, llt);

            // 3. Backtrack: Swap them back to restore the array for the next loop iteration
            swap(ind, i, arr);
        }
    }
    public static void GetUniqueSubsets(int[] arr)
    {
        int index = 0;
        List<int> lt = new List<int>();
        Array.Sort(arr);
        List<List<int>> llt = new List<List<int>>();
        GetAllUniqueSubsets(arr, index, lt, llt);
        llt.ForEach(lt => System.Console.WriteLine(string.Join(", ", lt)));
    }

    private static void GetAllUniqueSubsets(int[] arr, int index, List<int> lt, List<List<int>> llt)
    {
        llt.Add(lt.ToList());
        for (int i = index; i < arr.Length; i++)
        {
            if (i != index && arr[i] == arr[i - 1])
                continue;
            lt.Add(arr[i]);
            GetAllUniqueSubsets(arr, i + 1, lt, llt);
            lt.Remove(arr[i]);
        }
    }

    public static void TargetSum(int[] arr, int i, List<int> lt, List<List<int>> llt, int target)
    {
        if (target == 0)
        {
            llt.Add(lt.ToList());
            return;
        }
        if (i == arr.Length)
            return;

        if (arr[i] <= target)
        {
            lt.Add(arr[i]);
            TargetSum(arr, i, lt, llt, target - arr[i]);
            lt.Remove(arr[i]);
        }
        TargetSum(arr, i + 1, lt, llt, target);
    }

    public static void UniqueTargetSum(int[] arr, int target, int ind, List<int> lt, List<List<int>> llt)
    {
        if (target == 0)
        {
            llt.Add(lt.ToList());
            return;
        }
        //Array.Sort(arr);
        // for(int i=0;i<arr.Length; i++)
        // {
        for (int j = ind; j < arr.Length; j++)
        {
            if (ind < j && arr[j] == arr[j - 1])
                continue;
            if (arr[j] <= target)
            {
                lt.Add(arr[j]);
                UniqueTargetSum(arr, target - arr[j], j + 1, lt, llt);
                lt.Remove(arr[j]);
            }
            else
                break;
        }
        //}
    }

    public static void PlaindromePartition(string str, int ind, List<string> lt, List<List<string>> llt)
    {
        if (ind == str.Length)
        {
            llt.Add(lt.ToList());
            return;
        }
        for (int i = ind; i < str.Length; i++)
        {
            int last = i + 1 - ind;
            string palin = str.Substring(ind, last);
            if (isPalindrome(str, ind, i))
            {
                lt.Add(palin);
                PlaindromePartition(str, i + 1, lt, llt);
                lt.Remove(palin);
            }
        }
    }

    public static List<int> GetkthPermutation(List<int> arr, int kthPermutatn, List<int> lt)
    {
        if (arr.Count == 0)
            return lt;

        int n = arr.Count;
        int noOfPermutation = Permulation(n);
        int rangeVal = noOfPermutation / n;
        int lieRange = kthPermutatn / rangeVal;  // considering Zera base indexing
        kthPermutatn = kthPermutatn % rangeVal;
        lt.Add(arr[lieRange]);
        arr.Remove(arr[lieRange]);
        return GetkthPermutation(arr, kthPermutatn, lt);
    }

    public static int Permulation(int n)
    {
        if (n == 0 || n == 1)
            return 1;
        return n * Permulation(n - 1);
    }

    public static int CanColorTheGraph(List<List<int>> graph, int colors)
    {
        int[] verticesColor = new int[graph.Count];
        return ColorElement(graph, colors, 0, verticesColor) == true ? 1 : 0;
    }

    private static bool ColorElement(List<List<int>> graph, int colors, int vertice, int[] verticesColor)
    {
        if (vertice == graph.Count)
            return true;

        for (int i = 1; i <= colors; i++)
        {
            if (SafeToColor(graph, i, verticesColor, vertice))
            {
                verticesColor[vertice] = i;
                if (ColorElement(graph, colors, vertice + 1, verticesColor))
                    return true;
                verticesColor[vertice] = 0;
            }
        }

        return false;
    }

    private static bool SafeToColor(List<List<int>> graph, int i, int[] verticesColor, int vertice)
    {
        foreach (int neighbour in graph[vertice])
        {
            if (verticesColor[neighbour] == i)
                return false;
        }

        return true;
    }

    public static void RatMazeProblem(int[][] maze, int i, int j, bool[,] isVisited, List<string> path, List<List<string>> paths, int n, int m, string direction)
    {
        if (i < 0 || j < 0 || j >= m || i >= n || maze[i][j] == 0 || isVisited[i, j])
            return;
        if (i == n - 1 && j == m - 1)
        {
            if (i != 0 || j != 0)
                path.Add(direction);
            paths.Add(path.ToList());
            if (i != 0 || j != 0)
            {
                path.RemoveAt(path.Count - 1);
            }
            return;
        }

        isVisited[i, j] = true;
        if (i != 0 || j != 0)
            path.Add(direction);
        RatMazeProblem(maze, i + 1, j, isVisited, path, paths, n, m, "D");
        RatMazeProblem(maze, i - 1, j, isVisited, path, paths, n, m, "U");
        RatMazeProblem(maze, i, j + 1, isVisited, path, paths, n, m, "R");
        RatMazeProblem(maze, i, j - 1, isVisited, path, paths, n, m, "L");

        if (i != 0 || j != 0)
            path.RemoveAt(path.Count - 1);
        isVisited[i, j] = false;
    }

    public static int NonDuplicateElement(int[] arr)
    {
        int i = 0; int j = 1;
        while (i < j && j < arr.Length)
        {
            if (arr[i] != arr[j])
            {
                System.Console.WriteLine("Non Duplicate No - " + arr[i]);
                return arr[i];
            }
            while (arr[i] == arr[j])
            {
                j++;
            }
            i = j; j = j + 1;
        }

        System.Console.WriteLine("Non Duplicate No - " + arr[i]);
        return arr[i];
    }

    public static bool Exist(char[][] board, string word)
    {

        if (board.Length == 0)
            return false;

        bool[,] isVisited = new bool[board.Length, board[0].Length];
        for (int i = 0; i < board.Length; i++)
        {
            for (int j = 0; j < board[0].Length; j++)
            {
                if (word[0] == board[i][j])
                {
                    if (NewMethod(board, word, isVisited, 0, i, j))
                        return true;
                }
            }
        }

        return false;
    }

    private static bool NewMethod(char[][] board, string word, bool[,] isVisited, int len, int n, int m)
    {
        if (m < 0 || n < 0 || m == board[0].Length || n == board.Length)
            return false;
        if (len == word.Length)
            return true;


        if (board[n][m] == word[len] && !isVisited[n, m])
        {
            isVisited[n, m] = true;
            bool up = NewMethod(board, word, isVisited, len + 1, n - 1, m);
            bool down = NewMethod(board, word, isVisited, len + 1, n + 1, m);
            bool right = NewMethod(board, word, isVisited, len + 1, n, m + 1);
            bool left = NewMethod(board, word, isVisited, len + 1, n, m - 1);

            if (up || down || right || left)
                return true;
            isVisited[n, m] = false;
        }
        return false;
    }

    public static int GetIndexInRoatedSortedArray(int[] arr, int target)
    {
        int low = 0; int high = arr.Length - 1;

        while (low <= high)
        {
            int mid = (low + high) / 2;
            if (arr[mid] == target)
                return mid;

            if (arr[low] <= target && target <= arr[mid - 1])
            {
                high = mid - 1;
            }
            else
            {
                low = mid + 1;
            }
        }

        return -1;
    }

    public static int MedianInArray(int[,] arr)
    {
        int l = 1; int h = 20;
        int n = arr.GetLength(0); int m = arr.GetLength(1);
        while (l <= h)
        {
            int mid = (l + h) / 2;
            int cnt = 0;
            for (int i = 0; i < n; i++)
            {
                cnt += GetCountGreaterThenMid(mid, i, arr);
            }

            if (cnt <= (n * m) / 2)
                l = mid + 1;
            else
                h = mid - 1;
        }
        System.Console.WriteLine("Median : " + l);
        return l;
    }

    private static int GetCountGreaterThenMid(int num, int row, int[,] arr)
    {
        int m = arr.GetLength(1) - 1;
        int l = 0; int h = m;
        while (l <= h)
        {
            int mid = (l + h) / 2;
            if (arr[row, mid] <= num)
                l = mid + 1;
            else
                h = mid - 1;
        }
        return l;
    }

    public static int MedianOfTwoSortedArray(int[] arr1, int[] arr2)
    {
        int medianInd = (arr1.Length + arr2.Length) / 2;
        int l = 0; int h = arr1.Length;
        int l1 = 0; int l2 = 0;
        int s1 = 0; int s2 = 0;
        while (l <= h)
        {
            int mid = (l + h) / 2;
            if (mid == 0)
            {
                l1 = int.MinValue;
                l2 = arr2[medianInd - 1];
            }
            else
            {
                l1 = arr1[mid - 1];
                l2 = arr2[medianInd - mid - 1];
            }

            if (mid == arr1.Length)
            {
                s1 = int.MaxValue;
                s2 = arr2[0];
            }
            else
            {
                s1 = arr1[mid];
                s2 = arr2[medianInd - mid];
            }

            if (l1 > s2)
                h = mid - 1;
            else if (l2 > s1)
                l = mid + 1;
            else
                break;
        }

        int median = Math.Max(l1, l2) + Math.Min(s1, s2);
        System.Console.WriteLine("Two Sorted Array median : " + median);
        return median / 2;
    }

    public static void PermutationWithLessSeat(int[] arr, List<int> lt, List<List<int>> llt, bool[] isVisited)
    {
        if (lt.Count == 3)
        {
            llt.Add(lt.ToList());
            return;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (!isVisited[i])
            {
                isVisited[i] = true;
                lt.Add(arr[i]);
                PermutationWithLessSeat(arr, lt, llt, isVisited);
                lt.RemoveAt(lt.Count() - 1);
                isVisited[i] = false;
            }
        }
    }

    public static bool Sudoko(int[,] sudoko, int n, int m)
    {
        if (n == sudoko.GetLength(0) && m == sudoko.GetLength(1))
            return true;

        for (int i = 0; i < sudoko.GetLength(0); i++)
        {
            for (int j = 0; j < sudoko.GetLength(1); j++)
            {
                if (sudoko[i, j] == 0)
                {
                    for (int num = 1; num <= 9; num++)
                    {
                        if (PossibleToPlace(num, i, j, sudoko))
                        {
                            sudoko[i, j] = num;
                            if (!Sudoko(sudoko, i, j))
                            {
                                sudoko[i, j] = 0; // bactracking
                            }
                            else
                                return true;
                        }
                    }

                    return false; // since it did not found any no. which will fit
                }
            }
        }
        return true;
    }

    private static bool PossibleToPlace(int num, int i, int j, int[,] sudoko)
    {
        for (int s = 0; s < sudoko.GetLength(0); s++)
        {
            if (sudoko[s, j] == num || sudoko[i, s] == num)
                return false;
        }

        // Check 3x3 Box (The missing critical check)
        int startRow = i - i % 3;
        int startCol = j - j % 3;

        for (int si = 0; si < 3; si++)
        {
            for (int sj = 0; sj < 3; sj++)
            {
                if (sudoko[startRow + si, startCol + sj] == num)
                {
                    return false;
                }
            }
        }
        return true;
    }

    public static int MinOfmaxPathDifference(int[,] hike, int di, int dj)
    {
        SortedDictionary<int, Tuple<int, int>> queue = new SortedDictionary<int, Tuple<int, int>>
        {
            { 0, Tuple.Create(0, 0) }
        };
        int[,] diff = new int[hike.GetLength(0), hike.GetLength(1)];

        for (int i = 0; i < diff.GetLength(0); i++)
        {
            for (int j = 0; j < diff.GetLength(1); j++)
            {
                diff[i, j] = int.MaxValue;
            }
        }
        diff[0, 0] = 0;
        int[] ia = { -1, 0, +1, 0 };
        int[] ja = { 0, +1, 0, -1 };

        while (queue.Count != 0)
        {
            KeyValuePair<int, Tuple<int, int>> ele = queue.First();
            if (ele.Value.Item1 == di && ele.Value.Item2 == dj)
                return ele.Key;
            queue.Remove(ele.Key);
            for (int i = 0; i < 4; i++)
            {
                int xi = ele.Value.Item1 + ia[i];
                int yi = ele.Value.Item2 + ja[i];
                if (xi < 0 || xi == hike.GetLength(0) || yi < 0 || yi == hike.GetLength(1))
                    continue;

                int affords = hike[xi, yi] - hike[ele.Value.Item1, ele.Value.Item2];
                int maxAffords = int.Max(affords, ele.Key);
                if (maxAffords < diff[xi, yi])
                {
                    diff[xi, yi] = maxAffords;
                    queue.Add(maxAffords, Tuple.Create(xi, yi));
                }
            }
        }

        return -1;
    }

    public static List<string> LetterCombinations(string digits)
    {
        List<string> lt = new List<string>();
        IDictionary<char, string> dic = new Dictionary<char, string>()
        { {'1', ""}, {'2', "abc"}, {'3', "def"}, {'4', "ghi"},
        {'5', "jkl"}, {'6', "mno"}, {'7', "pqrs"}, {'8', "tuv"}, {'9', "wxyz"}};

        GetAllComb(digits, dic, 0, lt, "");
        return lt;
    }

    public static void GetAllComb(string digits, IDictionary<char, string> dic, int ind, List<string> lt, string str)
    {
        if (ind == digits.Length)
        {
            lt.Add(str);
            return;
        }
        foreach (char c in dic[digits[ind]])
        {
            str += c;
            GetAllComb(digits, dic, ind + 1, lt, str);
            str = str.Substring(0, str.Length - 1);
        }
    }

    public static void GetAllSubset(int[] arr, List<List<int>> llt, List<int> lt, int ind)
    {
        llt.Add(lt.ToList());

        for (int i = ind; i < arr.Length; i++)
        {
            lt.Add(arr[i]);
            GetAllSubset(arr, llt, lt, i + 1);
            lt.RemoveAt(lt.Count - 1);
        }
    }

    public static void MergeSort(int[] arr, int s, int e)
    {
        if (s < e)
        {
            //int mid = (s+e)/2;
            int mid = s + (e - s) / 2;
            MergeSort(arr, s, mid);
            MergeSort(arr, mid + 1, e);
            Conquere(arr, s, mid, e);
        }
    }

    private static void Conquere(int[] arr, int s, int mid, int e)
    {
        List<int> copy = new List<int>();
        int i = s; int j = mid + 1;
        while (i <= mid && j <= e)
        {
            if (arr[i] < arr[j])
            {
                copy.Add(arr[i++]);
            }
            else
                copy.Add(arr[j++]);
        }

        while (i <= mid)
            copy.Add(arr[i++]);

        while (j <= e)
            copy.Add(arr[j++]);

        for (int c = 0; c < copy.Count; c++)
        {
            arr[s + c] = copy[c];
        }
    }

    public static void FindAllOccurence(string str)
    {
        Dictionary<char, int> dic = new Dictionary<char, int>();
        int[] arr = new int[26];
        str.Select(s => ++arr[s - 'a']).ToArray();
        System.Console.WriteLine(string.Join(" ,", arr));

        string newStr = "";
        for (int i = 0; i < 26; i++)
        {
            if (arr[i] > 0)
                newStr += (char)(i + 'a');
        }
        System.Console.WriteLine("New String : " + newStr);
    }

    public static int AllocatingBookWithMinPageDiff(int[] books, int students)
    {
        int low = int.MaxValue; int high = 0; int res = -1;
        foreach (int book in books)
        {
            if (book < low)
                low = book;
        }

        foreach (int book in books)
        {
            high += book;
        }

        while (low <= high)
        {
            int mid = low + (high - low) / 2;
            if (PossibleToAllocate(books, low, mid, students))
            {
                res = mid;
                high = mid - 1;
            }
            else
                low = mid + 1;
        }

        return res;
    }

    private static bool PossibleToAllocate(int[] books, int low, int mid, int students)
    {
        int allocatedStu = 1; int pages = 0;
        for (int i = 0; i < books.Length; i++)
        {
            if (books[i] > mid)
                return false;

            if (pages + books[i] > mid)
            {
                pages = 0;
                allocatedStu++;
                pages += books[i];
            }
            else
                pages += books[i];
        }

        if (allocatedStu > students)
            return false;

        if (allocatedStu == students)
            return true;
        return false;
    }

    public static int MinLargestDistancePlacingCow(int[] lane, int cow)
    {
        if (lane.Length == 0 || cow == 0)
            return -1;

        int minLargestDis = int.MinValue;

        int low = lane[0]; int high = lane[lane.Length - 1] - lane[0];;
        while (low <= high)
        {
            int mid = (low+high)/2;
            if (PossibleAtDistanceI(lane, cow, mid, 0, 1))
            {
                minLargestDis = Math.Max(minLargestDis, mid);
                low = mid+1;
            }
            else
                high = mid-1;
        }

        return minLargestDis;
    }

    private static bool PossibleAtDistanceI(int[] lane, int cow, int requiredDist, int curr, int desti)
    {
        if (desti == lane.Length || curr == lane.Length)
            return false;

        if (cow == -1 || cow == 0)
            return true;

        // for (int i = curr; i <= lane.Length - cow; i++)
        // {
            if (desti < lane.Length && lane[desti] - lane[curr] >= requiredDist)
            {
                if (PossibleAtDistanceI(lane, cow - 2, requiredDist, desti, desti + 1))
                    return true;
                else
                {
                    
                }
            }
            else
                PossibleAtDistanceI(lane, cow, requiredDist, curr, desti + 1);
        //}

        return false;
    }

    public static int MaxContinuousSumSubArray(int[] arr)
    {
        int curr = 0; int maxi = int.MinValue;
        foreach(int num in arr)
        {
            curr = Math.Max(num, curr + num);
            maxi = Math.Max(maxi, curr);
        }

        System.Console.WriteLine("Max Sum Array :"+ maxi);
        return maxi;
    }
}