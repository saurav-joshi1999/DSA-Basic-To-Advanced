using System.Security.Cryptography.X509Certificates;

public static class StringSubsequence
{
    public static void Mainn()
    {
        string str1 = "**ab*c?";
        string str2 = "abdefcd";
        int[,] dp = new int[str1.Length, str2.Length];
        //Console.WriteLine(" Max Len SubSeq. : " + LengthOfMaxiSubsequence(str1, str2, str1.Length - 1, str2.Length - 1, dp));
        //Console.WriteLine(" Max Len SubSeq. with tab : " + LengthOfMaxiSubsequenceTab(str1, str2, out dp));
        string[,] sdp = new string[str1.Length, str2.Length];
        //Console.WriteLine("Longest CS : " + LongestSubsequenceString(str1, str2, str1.Length - 1, str2.Length - 1, sdp));
        //Console.WriteLine("Longest CS Tab : " + StringOfMaxiSubsequenceTab(str1, str2));
        //Console.WriteLine("Longest SubString : " + LongestCommonSubString(str1, str2));
        //Console.WriteLine("Max Num. Del or Add : " + MinimumOperationDeletionOrAddition(str1, str2));
        //     Console.WriteLine(" Distinct SubSequence " + StringSubsequence.DistinctNumOfSubSequence
        //     (str1, str2, str1.Length, str2.Length));
        //     Console.WriteLine(" Distinct SubSequence Tab " + StringSubsequence.DistinctNumOfSubSequenceTab
        //     (str1, str2));
        //Console.WriteLine("Min Operation IRD : " + InsertReplaceDeleteToMatchS1ToS2(str1, str2, str1.Length, str2.Length));
        Console.WriteLine("Did Match : " + Match(str1, str2, str1.Length, str2.Length));
    }

    public static int LengthOfMaxiSubsequence(string str1, string str2, int s1, int s2, int[,] dp)
    {
        if (s1 < 0 || s2 < 0)
            return 0;

        if (dp[s1, s2] != 0)
            return dp[s1, s2];

        if (str1[s1] == str2[s2])
            return dp[s1, s2] = 1 + LengthOfMaxiSubsequence(str1, str2, s1 - 1, s2 - 1, dp);
        return dp[s1, s2] = Math.Max(LengthOfMaxiSubsequence(str1, str2, s1 - 1, s2, dp),
                            LengthOfMaxiSubsequence(str1, str2, s1, s2 - 1, dp));
    }

    public static int LengthOfMaxiSubsequenceTab(string str1, string str2, out int[,] dp)
    {
        int s1 = str1.Length, s2 = str2.Length;
        dp = new int[s1 + 1, s2 + 1]; // the actula value will be from 1-s2.length+1 => "saurav"
                                      //0"123456"  -> length 7 dp
        for (int i = 1; i <= s1; i++)
        {
            for (int j = 1; j <= s2; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                else
                    dp[i, j] = Math.Max(dp[i - 1, j], dp[i, j - 1]);
            }
        }
        return dp[s1, s2];
    }

    public static string StringOfMaxiSubsequenceTab(string str1, string str2)
    {
        LengthOfMaxiSubsequenceTab(str1, str2, out int[,] dp);
        int n = str1.Length; int m = str2.Length; string str = "";
        while (n > 0 && m > 0)
        {

            if (str1[n - 1] == str2[m - 1])
            {
                str = str1[n - 1] + str;
                n = n - 1;
                m = m - 1;
            }
            else if (dp[n, m - 1] >= dp[n - 1, m])
                m = m - 1;
            else
                n = n - 1;
        }
        return str;
    }

    public static string LongestSubsequenceString(string str1, string str2, int s1, int s2, string[,] dp)
    {
        if (s1 < 0 || s2 < 0)
            return "";

        if (dp[s1, s2] != null)
            return dp[s1, s2];

        if (str1[s1] == str2[s2])
            return dp[s1, s2] = LongestSubsequenceString(str1, str2, s1 - 1, s2 - 1, dp) + str1[s1];

        string sstr1 = LongestSubsequenceString(str1, str2, s1 - 1, s2, dp);
        string sstr2 = LongestSubsequenceString(str1, str2, s1, s2 - 1, dp);

        if (sstr1.Length > sstr2.Length)
            return sstr1;
        return sstr2;
    }

    public static int LongestCommonSubString(string str1, string str2)
    {
        int s1 = str1.Length; int s2 = str2.Length;
        int[,] dp = new int[s1 + 1, s2 + 1];
        int ans = 0;
        for (int i = 1; i <= s1; i++)
        {
            for (int j = 1; j <= s2; j++)
            {
                if (str1[i - 1] == str2[j - 1])
                {
                    dp[i, j] = 1 + dp[i - 1, j - 1];
                }
                else
                {
                    dp[i, j] = 0;
                }
            }
        }
        return ans;
    }

    public static int MinimumOperationDeletionOrAddition(string str1, string str2)
    {
        int len = LengthOfMaxiSubsequenceTab(str1, str2, out int[,] dp);
        return str1.Length + str2.Length - 2 * len;
    }

    public static string MiniLenSuperSubsequence(string str1, string str2)
    {
        int len = LengthOfMaxiSubsequenceTab(str1, str2, out int[,] dp);
        int n = str1.Length; int m = str2.Length; string ans = "";
        Console.WriteLine($"Min Len :  {(n + m) - len}");
        while (n > 0 && m > 0)
        {
            if (str1[n - 1] == str2[m - 1])
            {
                ans = str1[n - 1] + ans;
                n = n - 1;
                m = m - 1;
            }
            else if (dp[n, m - 1] > dp[n - 1, m])
            {
                ans = str2[m - 1] + ans;
                m = m - 1;
            }
            else if (dp[n, m - 1] == dp[n - 1, m])
            {
                ans = str1[n - 1] + ans;
                ans = str2[m - 1] + ans;
                m = m - 1;
                n = n - 1;
            }
            else
            {
                ans = str1[n - 1] + ans;
                n = n - 1;
            }
        }

        return ans;
    }

    public static int DistinctNumOfSubSequence(string s1, string s2, int n, int m)
    {
        if (n == 0 && m > 0)
            return 0;

        if (m == 0)
            return 1;

        if (s1[n - 1] == s2[m - 1])
        {
            return DistinctNumOfSubSequence(s1, s2, n - 1, m - 1) + DistinctNumOfSubSequence(s1, s2, n - 1, m);
        }
        else
            return DistinctNumOfSubSequence(s1, s2, n - 1, m);
    }

    public static int DistinctNumOfSubSequenceTab(string s1, string s2)
    {
        int n = s1.Length + 1; int m = s2.Length + 1;
        int[,] dp = new int[n, m];

        for (int i = 0; i < n; i++)
        {
            dp[i, 0] = 1;
        }

        for (int i = 1; i < n; i++)
        {
            for (int j = 1; j < m; j++)
            {
                if (s1[i - 1] == s2[j - 1])
                    dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                else
                    dp[i, j] = dp[i - 1, j];
            }
        }

        return dp[s1.Length, s2.Length];
    }

    public static int InsertReplaceDeleteToMatchS1ToS2(string s1, string s2, int n, int m)
    {
        if (n == 0)
            return m;

        if (m == 0)
            return n;

        if (s1[n - 1] == s2[m - 1])
        {
            return InsertReplaceDeleteToMatchS1ToS2(s1, s2, n - 1, m - 1);
        }
        else
        {
            int deleteAndMove = 1 + InsertReplaceDeleteToMatchS1ToS2(s1, s2, n - 1, m);
            int replace = 1 + InsertReplaceDeleteToMatchS1ToS2(s1, s2, n - 1, m - 1);
            int insertRemain = 1 + InsertReplaceDeleteToMatchS1ToS2(s1, s2, n, m - 1);
            return Math.Min(Math.Min(deleteAndMove, replace), insertRemain);
        }
    }

    public static bool Match(string str1, string str2, int n, int m)
    {
        if (m == 0)
        {
            if (n == 0)
                return true;

            if (!str1.Substring(0, n).Any(char.IsLetter))
                return true;
            else
                return false;
        }

        if (str1[n-1] == str2[m-1] || str1[n-1] == '?')
        {
            return Match(str1, str2, n - 1, m - 1);
        }
        else if (str1[n-1] == '*')
        {
            return Match(str1, str2, n - 1, m) || Match(str1, str2, n, m - 1);
        }

        return false;
    }
}