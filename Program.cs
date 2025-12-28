using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;

internal class Program
{
    private static void Main(string[] args)
    {

        //Console.WriteLine(DpFibonacci(7, dp));
        //Console.WriteLine(Fibonacii(6));

        //selectionSort();
        // int[] arr = new int[] { 46, 23, 56, 78, 56, 2, 45, 33, 22 };
        // //NonLinearSort.QuickSort(arr, 0, arr.Length - 1);
        // //Console.WriteLine(string.Join(", ", arr));
        // // Console.WriteLine(ClimbingStair(arr, arr.Length - 1));
        // int[] nums = { 1, 2, 5, 2, 3 };
        // Solution sl = new Solution();
        // //Console.WriteLine(string.Join(", ",sl.TargetIndices(nums, 2)));
        // sl.SortSentence("is2 sentence4 This1 a3");

        // int[] dp1 = Enumerable.Repeat(-1, 9).ToArray();
        // dp1[0] = 0;
        // Console.WriteLine("With 1 and 2 Jumps" + ClimbingStair(arr, arr.Length - 1));

        // int[] dp2 = Enumerable.Repeat(-1, 9).ToArray();
        // dp2[0] = 0;
        // Console.WriteLine("With K Jumps " + ClimbingStairMemoisationWithKJump(arr, arr.Length - 1, dp2, 2));

        // int[] dp3 = Enumerable.Repeat(-1, 9).ToArray();
        // dp3[0] = 0;
        // Console.WriteLine("With K Jumps Tabulation" + ClimbingStairsWithTabularionWithKJump(arr, arr.Length - 1, dp3, 2));

        // int[] arr1 = { 0, 0, 1, 1, 1, 2, 2, 3, 3, 4 };
        // int size = ArrayProblem.RemoveDuplicates(arr1);
        // Console.WriteLine(string.Join(", ", arr1));

        // int[][] arr = new int[][]
        //     {
        //         new int[] { 1, 2, 3 },
        //         new int[] { 8, 9, 4 },
        //         new int[] { 7, 6, 5 }
        //     };

        // MatrixZero.MarkRowAndColZero(arr, 3, 3);
        // foreach (var row in arr)
        // {
        //     Console.WriteLine(string.Join(" ", row));
        // }

        //Spiral.SpiralOrder(arr);
        // int[] max = { 23, 45, 67, 100, 34, 1, 22 };
        // int[] dp3 = new int[max.Length];
        // Console.WriteLine(MaximunSum.GetMaximumSum(max, max.Length - 1, dp3));
        // int[] dp4 = new int[max.Length];
        // Console.WriteLine("With Tabulation : "+MaximunSum.GetMaximumSumTabulation(max, max.Length - 1, dp4));
        // int[] dp5 = new int[max.Length];
        // Console.WriteLine("With Tabulation : "+MaximunSum.GetMaximumSumTabulationWithoutDp(max, max.Length - 1, dp4));

        // int[][] pointArr = { new int[] { 1, 2, 3 }, new int[] { 5, 6, 7 }, new int[] { 8, 9, 10 } };
        // Max2DScore.GetMaxSPoints(arr, 3);

        //RobberMaxMoney.GetMaxMoney();
        //MaxPath.Mainn();
        //Search.mainn();
        // LinkedList.PrintLinkedList(LinkedList.GetList(new int[] { 2,3,4,5,6}));
        // Node head = DoubleLL.CreateDLL(new int[] { 2, 3, 4, 5, 6 });
        // DoubleLL.WriteDLL(head);
        // DoubleLL.InsertAtIndex(head, 3, 44);
        // DoubleLL.WriteDLL(head);
        // DoubleLL.DeleteAtIndex(head, 3);
        // DoubleLL.WriteDLL(head);
        // Node newHead = DoubleLL.ReverseDLL(head);
        // DoubleLL.WriteDLL(newHead);

        //SLNode sll = LinkedList.GetList(new[] { 1, 2, 3, 4, 5, 6, 7, 8 });
        //LinkedList.PrintLinkedList(sll);
        // SLNode sll1 =  LinkedList.ReverseList(sll);
        // LinkedList.PrintLinkedList(sll1);
        // SLNode sll1 = LinkedList.SeparateEventOddInSameList(sll);
        //  LinkedList.PrintLinkedList(sll1);
        // SLNode head1 = null; SLNode head2 = null;
        // LinkedList.SeparateOddEvenNode(sll, out head1, out head2);
        // LinkedList.PrintLinkedList(head1);
        // LinkedList.PrintLinkedList(head2);
        //SLNode newHead = LinkedList.ReverseListInKGroup(sll);
        //LinkedList.PrintLinkedList(newHead);
        //MaxPath.Mainn();

        // GetMinSum.WriteMethods();

        // ShiftArray.mainn();
        //TwoPeopleJump.mainn();
        //TargetSubsequence.mainn();

        // List<int> lt = new List<int> { 4,0,3,1,2,2 };
        // GetTargetSum.getIndexLists(lt, 4);

        //TargetSubsequence.mainn();
        //ArrayQuestion.mainn();

        int[] arr1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        BTree root = BinaryTreeClass.GetBinaryTree(arr1, 0, arr1.Length - 1);
        //     BTree.PrintPreOrderQueue(root);
        //     //BTree.LevelOrderTraverse(root);
        //     BTree.PostOrderTraverseUsingTwoStack(root);
        //     BTree.ITraetivePreOrderTraversal(root);
        //     BTree.ITraetiveInOrderTraversal(root);
        //     Console.WriteLine("Depth of tree " + BTree.DepthOfTree(root));
        // BTree root = BTree.CreateBinaryTree(arr);
        // BTree.PrintPreOrderQueue(root);
        // Console.WriteLine("Depth of tree " +BTree.DepthOfTree(root));
        //TargetSubsequence.mainn();
        //Knapsnap.mainn();

        // int[] arr2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        // BTree root2 = BinaryTreeClass.GetBinaryTree(arr2, 0, arr2.Length - 1);
        // Console.WriteLine("Max Width : " +BinaryTreeClass.GetMaxWidth(root2));
        //Console.WriteLine("Is Same Tree : " +BTree.SameTree(root, root2));
        // BTree.PrintSpiral(root);

        //NumOfMinCoinsRequired.mainn();
        //BTree.MaxDiameterofTree(root);
        //Console.WriteLine(" Max Diameter in Tree " + BTree.maxDia);
        //NumOfMinCoinsRequired.mainn();
        //BTree.MaximumPathSum(root);
        //Console.WriteLine("Maxi Path Sum : " +BTree.maxi);
        //TargetSubsequence.mainn();
        //Knapsnap.mainn();

        //StringSubsequence.Mainn();
        // BTree.PrintBoundryElemtentInAntiClock(root2);
        //BinaryTreeClass.GetVerticalNodes(root2);
        //StringSubsequence.Mainn();
        //List<int> lt = new List<int>();
        //BinaryTreeClass.RootToNodePath(root2, lt, 4);
        //Console.WriteLine("Root to Child Path : " + string.Join(", ",lt));
        // BTree ancestor = BinaryTreeClass.LowestAncestor(root2, 2, 4);
        // if (ancestor != null)
        //     Console.WriteLine("Lowest Common Ancestor : " + ancestor.data);
        //string str = StringSubsequence.MiniLenSuperSubsequence("brute", "groot");
        //Console.WriteLine("Lowest Super Subsequence : "+ str);
        //StringSubsequence.Mainn();
        //BysAndSellStock.Mainn();

        //BTree newDataRoot = BinaryTreeClass.ChildreenSumProperty(root);
        //BinaryTreeClass.LevelOrderTraverse(newDataRoot);

        //SubSequence.Mainn();
        int[] iOrder = { 9, 3, 15, 20, 7 };
        int[] prrOrder = { 3, 9, 20, 15, 7 };
        BTree root3 = BinaryTreeClass.CreateBinaryTree(iOrder, prrOrder);
        //BinaryTreeClass.PrintPreOrderQueue(root3);
        //BinaryTreeClass.PostOrderTraverseUsingTwoStack(root3);
        //BinaryTreeClass.PrintPreOrderQueue(BinaryTreeClass.SerializedAndDeserializedBTree(root3));
        BinaryTreeClass.BTtoLinkList(root3);
        //BinaryTreeClass.ITraetiveInOrderTraversal(root3);
        BinaryTreeClass.BTtoLinkListUsingStack(root);
        //BinaryTreeClass.ITraetiveInOrderTraversal(root);

        //SubSequence.Mainn();
        int[] BTA = { 10, 5, 2, 3, 6, 7, 15, 4, 8,1, 0 };
        BTree BSTRoot = null;
        foreach (int i in BTA)
        {
            BSTRoot = BinaryTreeClass.BTS(BTA, BSTRoot, i);
        }
        //BinaryTreeClass.PrintPreOrderQueue(BSTRoot);
        // BinaryTreeClass.ITraetiveInOrderTraversal(BSTRoot);
        // BTree ceil = BinaryTreeClass.CeilBTS(BSTRoot, 14, null, 1000);
        // Console.WriteLine("Ceil : " + ceil.data);

        // BTree floor = BinaryTreeClass.FloorBTS(BSTRoot, 14, null, 1000);
        // Console.WriteLine("Floor : " + floor.data);

        //  int floor2 = BinaryTreeClass.FloorBTS(BSTRoot, 14);
        // Console.WriteLine("Floor2 : " + floor2);
        // BinaryTreeClass.InsertInBTS(BSTRoot, 4);
        //BinaryTreeClass.InsertInBTS2(BSTRoot, 4);
        // BinaryTreeClass.PrintPreOrderQueue(BSTRoot);
        // BinaryTreeClass.InsertInBTS2(BSTRoot, 6);
        // BinaryTreeClass.PrintPreOrderQueue(BSTRoot);

        //BinaryTreeClass.DeleteNode(BSTRoot, 15, null);
        //Console.WriteLine("Present : "+ BinaryTreeClass.IsPresent(BSTRoot, 22)?.data);
        //BinaryTreeClass.ITraetiveInOrderTraversal(BSTRoot);
        //BinaryTreeClass.DeleteNode(BSTRoot, 10);
        //BinaryTreeClass.PrintPreOrderQueue(BSTRoot);
        //BinaryTreeClass.ITraetiveInOrderTraversal(BSTRoot);
        //System.Console.WriteLine("Kth Smallest : "+BinaryTreeClass.KthSmallestNode(BSTRoot, 4).data); 
        //System.Console.WriteLine("Is Valid BT : "+BinaryTreeClass.isValidBT(BSTRoot, int.MinValue, int.MaxValue));
        //BTree ancestor = BinaryTreeClass.LowestAncestor(BSTRoot, 13, 22);
        //System.Console.WriteLine("Lowest Common Ancestor : " + ancestor.data);
        // BinaryTreeClass.TwoOrderSum(BSTRoot, 9);
        // List<int> lt = BinaryTreeClass.GetInOrder(BSTRoot);
        //System.Console.WriteLine(BinaryTreeClass.LargestBST(BSTRoot));
        
        // CombineQuestion.TwoSumProblem(lt, 9);
        
        
        //MatrixGraph.mainn();
        //Sort.mainn();
        //AdjacentListGraph.mainn();

        //PARTITION
        // Partition.Mainn();

        //Tree
        // int[] arr = { 8, 5, 1, 7, 10, 12 };
        // BTree root2 = null;
        // for (int i = 0; i < arr.Length; i++)
        // {
        //     root2 = BinaryTreeClass.CreatePreOrder(arr, i, root2);
        // }

        // BinaryTreeClass.ITraetiveInOrderTraversal(root2);
        // BinaryTreeClass.ITraetiveInOrderTraversal(BinaryTreeClass.CreatePreOrderUsingUpperBound(arr));

        ///Rectangel Area
        //ArrayQuestion.mainn2();

        //complete
        CombineQuestion.mainn();

        //Single LinkedList 
         int[] slArr = {1,2,3,4,4,2,1}; int[] slArr2 = {1,3,4,6,9 };
        SLNode head1 = LinkedList.GetList(slArr);
        // SLNode head2 = LinkedList.GetList(slArr2);
        // //SLNode newNode = LinkedList.ReverseLinkedList(head);
        // SLNode newNode = LinkedList.MergeSortedList2(head1, head2);
        // LinkedList.PrintLinkedList(newNode);
        //LinkedList.ReverseListInK(head1, 3);
        //System.Console.WriteLine(LinkedList.IsPalindrome(head1));
        // List<List<int>> llt = new List<List<int>> { new List<int> {5,7,8,30 }, new List<int> { 10,20},
        //                                             new List<int> {19,22,50 }, new List<int> {28,35,40,45 } };
        // SLNode headWithnextAndbottom = LinkedList.CreateBottomAndNextList(llt);
        // SLNode head2 = LinkedList.MergeBottomAndNextLists(headWithnextAndbottom);
        // LinkedList.PrintLinkedList(head2);
        // LinkedList.PrintBottom(head2);
        //LinkedList.mainn();

        // Design Control Class
        //MethodClass.mainn();
        //client.mainn();

        // GRAPH 
        //AdjacentListGraph.mainn();
        //BinaryTreeClass.PrintPreOrderQueue(BSTRoot);
        //System.Console.WriteLine();
        BTree invertRoot = AdjacentListGraph.ReverseBT(BSTRoot);
        //BinaryTreeClass.PrintPreOrderQueue(invertRoot);
    }
}