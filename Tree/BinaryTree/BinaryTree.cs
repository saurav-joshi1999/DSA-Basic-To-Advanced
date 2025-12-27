using System.Collections;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata.Ecma335;

public class BTree
{
    public int data;
    public BTree left;
    public BTree right;

    public BTree(int data)
    {
        this.data = data;
        this.right = null;
        this.right = null;
    }

    public BTree(int data, BTree left, BTree right)
    {
        this.data = data;
        this.left = left;
        this.right = right;
    }
}
public static class BinaryTreeClass
{
    public static BTree GetBinaryTree(int[] arr, int s, int e)
    {
        if (s > e) return null;

        int mid = (s + e) / 2;
        BTree root = new BTree(arr[mid]);
        root.left = GetBinaryTree(arr, s, mid - 1);
        root.right = GetBinaryTree(arr, mid + 1, e);
        return root;
    }

    public static void LevelOrderTraverse(BTree root)
    {
        Queue<BTree> q = new Queue<BTree>();
        List<List<int>> llt = new List<List<int>>();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            List<int> lt = new List<int>();
            int qSize = q.Count;
            for (int i = 0; i < qSize; i++)
            {
                BTree node = q.Dequeue();
                if (node.left != null)
                    q.Enqueue(node.left);
                if (node.right != null)
                    q.Enqueue(node.right);
                lt.Add(node.data);
            }
            llt.Add(lt);
        }

        foreach (List<int> l in llt)
        {
            Console.WriteLine();
            Console.Write(string.Join(" ", l));
        }
    }

    public static void PrintPreOrderQueue(BTree root)
    {
        if (root == null)
            return;

        Console.Write(" " + root.data);
        PrintPreOrderQueue(root.left);
        PrintPreOrderQueue(root.right);
    }

    public static void PostOrderTraverseUsingTwoStack(BTree root)
    {
        Stack<BTree> s1 = new Stack<BTree>();
        Stack<int> s2 = new Stack<int>();
        s1.Push(root);
        while (s1.Count != 0)
        {
            BTree node = s1.Pop();
            s2.Push(node.data);
            if (node.left != null)
                s1.Push(node.left);
            if (node.right != null)
                s1.Push(node.right);
        }
        Console.WriteLine();
        Console.Write(string.Join(" ", s2));
        Console.WriteLine(" - Post Order");
    }

    public static void ITraetivePreOrderTraversal(BTree root)
    {
        List<int> lt = new List<int>();
        Stack<BTree> s = new Stack<BTree>();
        s.Push(root);
        while (s.Count() != 0)
        {
            BTree node = s.Pop();
            lt.Add(node.data);
            if (node.right != null)
                s.Push(node.right);
            if (node.left != null)
                s.Push(node.left);
        }
        Console.Write(string.Join(" ", lt));
        Console.WriteLine(" - Pre Order");
    }

    public static void ITraetiveInOrderTraversal(BTree root)
    {
        List<int> lt = new List<int>();
        Stack<BTree> s = new Stack<BTree>();
        BTree node = root;
        while (true)
        {
            if (node != null)
            {
                s.Push(node);
                node = node.left;
            }
            else
            {
                if (s.Count == 0)
                    break;
                node = s.Pop();
                lt.Add(node.data);
                node = node.right;
            }
        }
        Console.WriteLine();
        Console.Write(string.Join(" ", lt));
        Console.WriteLine(" - In Order");
    }

    public static int DepthOfTree(BTree root)
    {
        if (root == null)
            return 0;

        int left = DepthOfTree(root.left);
        int right = DepthOfTree(root.right);
        return 1 + int.Max(left, right);
    }

    public static BTree CreateBinaryTree(int[] arr)
    {
        int n = arr.Length;
        int i = 1;
        BTree root = new BTree(arr[0]);
        Queue<BTree> q = new Queue<BTree>();
        q.Enqueue(root);
        while (i < n && q.Count != 0)
        {
            BTree node = q.Dequeue();
            if (i < n)
            {
                node.left = new BTree(arr[i++]);
                q.Enqueue(node.left);
            }

            if (i < n)
            {
                node.right = new BTree(arr[i++]);
                q.Enqueue(node.right);
            }
        }

        return root;
    }

    public static bool IsBalanceTree(BTree root)
    {
        int lheight = DepthOfTree(root.left);
        int rheight = DepthOfTree(root.right);

        if (Math.Abs(lheight - rheight) > 1)
            return false;

        bool left = IsBalanceTree(root.left);
        bool right = IsBalanceTree(root.right);
        if (left == false || right == false)
            return false;
        return true;
    }

    public static int OptimiseIsBalanceTree(BTree root)
    {
        if (root == null)
            return 0;

        int lefth = OptimiseIsBalanceTree(root.left);
        int righth = OptimiseIsBalanceTree(root.right);

        if (lefth == -1 || righth == -1)
            return -1; // return -1 no need to check the max of left, right since it is already not balanced tree

        if (Math.Abs(lefth - righth) > 1) return -1;  // will only come here if left and right is != -1 
                                                      // and in case difference if greated then no need to get the max, since this node is
                                                      // not balanced 
        return Math.Max(lefth, righth) + 1;
    }

    public static int maxDia = 0;
    public static int MaxDiameterofTree(BTree root)
    {

        if (root == null)
            return 0;

        int lh = MaxDiameterofTree(root.left);
        int rh = MaxDiameterofTree(root.right);

        maxDia = Math.Max(maxDia, lh + rh);

        return 1 + int.Max(lh, rh);
    }

    public static int maxi = -1000;
    public static int MaximumPathSum(BTree root)
    {
        if (root == null)
            return 0;

        int ls = Math.Max(MaximumPathSum(root.left), 0); // to avoid the -ve values
        int rs = Math.Max(MaximumPathSum(root.right), 0);
        int roots = root.data;
        maxi = Math.Max(maxi, roots + ls + rs);
        return roots + Math.Max(ls, rs);
    }

    public static bool SameTree(BTree root1, BTree root2)
    {
        // if (root1 == null && root2 != null || root1 != null && root2 == null)
        //     return false;

        // if (root1 == null && root2 == null)
        //     return true;

        // if (root1.data != root2.data)
        //     return false;

        if (root1 == null || root2 == null)
            return root1 == root2;

        if (root1.data != root2.data)
            return false;

        bool isLeftSame = SameTree(root1.left, root2.left);
        bool isRightSame = SameTree(root1.right, root2.right);
        if (!isLeftSame || !isRightSame)
            return false;
        return true;
    }

    public static void PrintSpiral(BTree root)
    {
        Queue<BTree> q = new Queue<BTree>();
        List<List<int>> llt = new List<List<int>>();
        q.Enqueue(root);
        int falg = 0;
        while (q.Count != 0)
        {
            int len = q.Count;
            List<int> lt = new List<int>();
            for (int i = 0; i < len; i++)
            {
                BTree node = q.Dequeue();
                lt.Add(node.data);
                if (node.left != null)
                    q.Enqueue(node.left);

                if (node.right != null)
                    q.Enqueue(node.right);
            }
            if (falg == 1)
                lt.Reverse();
            llt.Add(lt);
            falg = falg == 0 ? 1 : 0;
        }

        llt.ForEach(lt => Console.Write(" " + string.Join(" ", lt)));
    }

    public static void PrintBoundryElemtentInAntiClock(BTree root)
    {
        List<int> lt = new List<int>();
        if (root == null)
            return;
        lt.Add(root.data);
        GetLeftBoundryElementWithoutLeafNode(root.left, lt);
        GetLeftNodeFromLeftToRight(root, lt);
        Stack<int> st = new Stack<int>();
        GetRightBoundryElementWithoutLeafNode(root.right, st);
        lt.AddRange(st);
        Console.WriteLine(string.Join(" ,", lt));
    }
    private static void GetLeftBoundryElementWithoutLeafNode(BTree root, List<int> lt)
    {
        if (root.left != null)
        {
            lt.Add(root.data);
            GetLeftBoundryElementWithoutLeafNode(root.left, lt);
        }
        else if (root.right != null)
        {
            lt.Add(root.data);
            GetLeftBoundryElementWithoutLeafNode(root.right, lt);
        }
    }

    private static void GetLeftNodeFromLeftToRight(BTree root, List<int> lt)
    {
        if (root.left == null && root.right == null)
        {
            lt.Add(root.data);
        }

        if (root.left != null)
            GetLeftNodeFromLeftToRight(root.left, lt);

        if (root.right != null)
            GetLeftNodeFromLeftToRight(root.right, lt);
    }


    private static void GetRightBoundryElementWithoutLeafNode(BTree root, Stack<int> lt)
    {
        if (root.right != null)
        {
            lt.Push(root.data);
            GetRightBoundryElementWithoutLeafNode(root.right, lt);
        }
        else if (root.left != null)
        {
            lt.Push(root.data);
            GetRightBoundryElementWithoutLeafNode(root.left, lt);
        }
    }


    public static void GetVerticalNodes(BTree root)
    {
        SortedDictionary<int, Dictionary<int, List<int>>> keyValuePairs = new SortedDictionary<int, Dictionary<int, List<int>>>();
        Queue<VerticalRowClass> q = new Queue<VerticalRowClass>(); // can perform any traversal here, will go with LOT
        VerticalRowClass verticalRow = new VerticalRowClass(0, 0, root);
        q.Enqueue(verticalRow);
        while (q.Count != 0)
        {
            int len = q.Count;
            for (int i = 0; i < len; i++)
            {
                VerticalRowClass vr = q.Dequeue();
                if (keyValuePairs.ContainsKey(vr.vertical))
                {
                    Dictionary<int, List<int>> rowNodes = keyValuePairs[vr.vertical];
                    if (rowNodes.ContainsKey(vr.row))
                    {
                        List<int> nodes = rowNodes[vr.row];
                        nodes.Add(vr.node.data);
                    }
                    else
                    {
                        rowNodes[vr.row] = new List<int> { vr.node.data };
                    }
                }
                else
                {
                    keyValuePairs[vr.vertical] = new Dictionary<int, List<int>> { { vr.row, new List<int> { vr.node.data } } };
                }

                if (vr.node.left != null)
                    q.Enqueue(new VerticalRowClass(vr.vertical - 1, vr.row + 1, vr.node.left));
                if (vr.node.right != null)
                {
                    q.Enqueue(new VerticalRowClass(vr.vertical + 1, vr.row + 1, vr.node.right));
                }
            }
        }

        foreach (KeyValuePair<int, Dictionary<int, List<int>>> verticalRows in keyValuePairs)
        {
            Console.WriteLine("Vertical : " + verticalRows.Key);
            foreach (KeyValuePair<int, List<int>> rowNodes in verticalRows.Value)
            {
                rowNodes.Value.Sort();
                Console.WriteLine("Row : " + rowNodes.Key + ", Nodes Data " + string.Join(",", rowNodes.Value));
            }
        }
    }

    public static bool IsSymetrical(BTree root)
    {
        return IsSymetrical(root.left, root.right);
    }

    private static bool IsSymetrical(BTree root1, BTree root2)
    {
        if (root1 == null || root2 == null)
            return root1 == root2;

        if (root1.data == root2.data)
        {
            return IsSymetrical(root1.left, root2.left) && IsSymetrical(root1.right, root2.right);
        }

        return false;
    }

    public static bool RootToNodePath(BTree root, List<int> lt, int childData)
    {
        if (root == null)
            return false;

        lt.Add(root.data);
        if (root.data == childData)
        {
            return true;
        }

        if (!RootToNodePath(root.left, lt, childData) && !RootToNodePath(root.right, lt, childData))
        {
            lt.Remove(root.data);
            return false;
        }
        return true;
    }

    public static BTree LowestAncestor(BTree root, int b1, int b2)
    {
        if (root == null) //tis return for base case
            return null;

        if (root.data == b1 || root.data == b2)
            return root;

        BTree left = LowestAncestor(root.left, b1, b2);
        BTree right = LowestAncestor(root.right, b1, b2);
        if (left != null && right != null)  // this return for parent
            return root;

        if (left != null)
            return left;

        if (right != null)
            return right;
        return null;
    }

    public static int GetMaxWidth(BTree root)
    {
        int mW = 0; int first = 0; int last = 0;
        Queue<NodeWithIndex> q = new Queue<NodeWithIndex>();
        q.Enqueue(new NodeWithIndex(0, root));
        while (q.Count > 0)
        {
            int len = q.Count;
            for (int i = 0; i < len; i++)
            {
                NodeWithIndex nodeWithIndex = q.Dequeue();
                BTree node = nodeWithIndex.node;
                if (i == 0)
                {
                    first = nodeWithIndex.index;
                }

                last = nodeWithIndex.index;
                int index = nodeWithIndex.index;
                if (node.left != null)
                    q.Enqueue(new NodeWithIndex(2 * (index - first) + 1, node.left));

                if (node.right != null)
                    q.Enqueue(new NodeWithIndex(2 * (index - first) + 2, node.right));
            }

            mW = Math.Max(last - first + 1, mW);
        }

        return mW;
    }

    public static BTree ChildreenSumProperty(BTree root)
    {
        if (root == null)
            return null;

        BTree left = ChildreenSumProperty(root.left);
        BTree right = ChildreenSumProperty(root.right); ;

        int leftData = root.left != null ? root.left.data : 0;
        int rightData = root.right != null ? root.right.data : 0;

        if (root.data <= leftData + rightData)
            root.data = leftData + rightData;
        if (root.left != null && root.right != null)
        {
            // distribute the extra value to one child
            root.left.data = root.data - root.right.data;
        }
        else if (root.left != null)
        {
            root.left.data = root.data;
        }
        else if (root.right != null)
        {
            root.right.data = root.data;
        }
        return root;
    }

    public static BTree CreateBinaryTree(int[] inorder, int[] preorder)
    {
        Dictionary<int, int> map = new Dictionary<int, int>(); int ind = 0;
        foreach (int i in inorder)
        {
            map[i] = ind++;
        }

        return CreateBinaryTree(inorder, 0, inorder.Length - 1, preorder, map);
    }

    public static int ind = 0;
    private static BTree CreateBinaryTree(int[] inorder, int ins, int ine, int[] preorder, Dictionary<int, int> map)
    {
        if (ins > ine) return null;
        BTree root = new BTree(preorder[ind++]);
        int rootInd = map[root.data];

        root.left = CreateBinaryTree(inorder, ins, rootInd - 1, preorder, map);
        root.right = CreateBinaryTree(inorder, rootInd + 1, ine, preorder, map);
        return root;
    }

    public static BTree SerializedAndDeserializedBTree(BTree root)
    {
        string str = Serialized(root);
        return Deserialized(str);
    }

    private static BTree Deserialized(string str)
    {
        string[] arr = str.Split(","); int ind = 0;
        Queue<BTree> q = new Queue<BTree>();
        BTree root = new BTree(int.Parse(arr[0]));
        q.Enqueue(root);
        while (q.Count != 0)
        {
            BTree node = q.Dequeue();
            if (arr[++ind] != "#")
            {
                BTree leftNode = new BTree(int.Parse(arr[ind]));
                node.left = leftNode;
                q.Enqueue(leftNode);
            }
            else
                node.left = null;

            if (arr[++ind] != "#")
            {
                BTree rightNode = new BTree(int.Parse(arr[ind]));
                node.right = rightNode;
                q.Enqueue(rightNode);
            }
            else
                node.right = null;
        }

        return root;
    }

    private static string Serialized(BTree root)
    {
        string str = string.Empty;
        Queue<BTree> q = new Queue<BTree>();
        q.Enqueue(root);
        while (q.Count != 0)
        {
            int len = q.Count;
            for (int i = 0; i < len; i++)
            {
                BTree node = q.Dequeue();
                if (node == null)
                {
                    str += "#,";
                    continue;
                }
                str += node.data + ",";
                q.Enqueue(node.left);
                q.Enqueue(node.right);
            }
        }
        return str.Substring(0, str.Length - 1);
    }

    public static BTree pre = null;
    public static void BTtoLinkList(BTree root)
    {
        if (root == null)
            return;

        BTtoLinkList(root.right);
        BTtoLinkList(root.left);

        root.right = pre;
        root.left = null;

        pre = root;
    }

    public static void BTtoLinkListUsingStack(BTree root)
    {
        Stack<BTree> st = new Stack<BTree>();
        st.Push(root);
        while (st.Count != 0)
        {
            BTree node = st.Pop();
            if (node.right != null)
                st.Push(node.right);

            if (node.left != null)
                st.Push(node.left);
            if (st.Count != 0)
                node.right = st.Peek();
            node.left = null;
        }
    }

    public static BTree BTS(int[] arr, BTree root, int ar)
    {
        if (root == null)
            return new BTree(ar);

        if (root.data >= ar)
            root.left = BTS(arr, root.left, ar);

        if (root.data < ar)
            root.right = BTS(arr, root.right, ar);

        return root;
    }

    public static BTree BTSSearch(int val, BTree root)
    {
        if (root == null)
            return null;

        if (root.data > val)
            return BTSSearch(val, root.left);
        else if (root.data < val)
            return BTSSearch(val, root.right);
        else
            return root;
    }

    public static BTree CeilBTS(BTree root, int val, BTree ceil, int diff)
    {
        if (root == null)
            return ceil;

        if (root.data - val == 0)
            return root;

        if (root.data > val && diff > root.data - val)
        {
            diff = root.data - val;
            ceil = root;
        }
        if (root.data > val)
        {
            return CeilBTS(root.left, val, ceil, diff);
        }
        else
            return CeilBTS(root.right, val, ceil, diff);
    }

    public static BTree FloorBTS(BTree root, int val, BTree floor, int diff)
    {
        if (root == null)
            return floor;

        if (root.data - val == 0)
            return root;

        if (val - root.data > 0 && diff > val - root.data)
        {
            diff = val - root.data;
            floor = root;
        }
        //if (root.data < val)
        //{
        BTree leftDiff = FloorBTS(root.left, val, floor, diff);
        //}
        //else
        BTree rightDiff = FloorBTS(root.right, val, floor, diff);
        return val - leftDiff.data <= val - rightDiff.data ? leftDiff : rightDiff;
    }

    public static int FloorBTS(BTree root, int key)
    {
        int floor = -1;
        while (root != null)
        {
            if (root.data == key)
            {
                floor = root.data;
                return floor;
            }

            if (key > root.data)
            {
                floor = root.data;
                root = root.right;
            }
            else
                root = root.left;
        }

        return floor;
    }

    public static BTree InsertInBTS(BTree root, int val)
    {
        if (root == null)
            return new BTree(val);

        if (root.data >= val)
            root.left = InsertInBTS(root.left, val);
        else
            root.right = InsertInBTS(root.right, val);

        return root;
    }

    public static BTree InsertInBTS2(BTree root, int val)
    {
        BTree pre = root;
        while (root != null)
        {
            pre = root;
            if (root.data >= val)
            {
                root = root.left;
            }
            else
            {
                root = root.right;
            }
        }

        if (pre.data > val)
            pre.right = new BTree(val);
        else
            pre.left = new BTree(val);

        return root;
    }

    public static BTree DeleteNode(BTree root, int val)
    {
        if (root == null)
            return root; ;

        if (root.data > val)
        {
            root.left = DeleteNode(root.left, val);
        }
        else if (root.data < val)
        {
            root.right = DeleteNode(root.right, val);
        }
        else
        {
            if (root.left == null && root.right == null)
                return null;   // we are returing the null to previous itertion either root.left =null || root.right = null 

            if (root.left == null)
                return root.right; // we return the non null node to root.left or root.right

            if (root.right == null)
                return root.left;

            BTree successor = Successor(root.right);  // here we do not return any thing we will update the value of root.
            root.data = successor.data;
            root.right = DeleteNode(root.right, successor.data);
        }

        return root;
    }

    private static BTree Successor(BTree root)
    {
        while (root.left != null)
        {
            root = root.left;
        }
        return root;
    }

    public static BTree IsPresent(BTree root, int val)
    {
        if (root == null) return null;
        if (root.data > val)
            return IsPresent(root.left, val);
        else if (root.data < val)
            return IsPresent(root.right, val);
        return root;
    }

    public static int count1 = 0;
    public static BTree KthSmallestNode(BTree root, int kth)
    {
        if (root == null)
            return null;

        BTree rootLeft = KthSmallestNode(root.left, kth);
        if (rootLeft != null)
            return rootLeft;

        count1++;
        if (kth == count1)
            return root;

        return KthSmallestNode(root.right, kth);
    }

    public static bool isValidBT(BTree root, int min, int max)
    {
        bool leftNode = true;
        if (root.left != null)
            if (root.left.data > min && root.left.data <= root.data)
                leftNode = isValidBT(root.left, min, root.data);
            else
                leftNode = false;
        bool rightNode = true;
        if (root.right != null)
            if (root.right.data > root.data && root.right.data < max)
                rightNode = isValidBT(root.right, root.data, max);
            else
                rightNode = false;

        if (!rightNode || !leftNode)
            return false;

        return true;
    }

    public static bool isValidBT2(BTree root, int min, int max)
    {
        if (root == null)
            return true;

        if (root.data < min || root.data > max)
            return false;

        return isValidBT(root.left, min, root.data) && isValidBT(root.right, root.data + 1, max);
    }

    public static BTree LowestCommonAncestor(BTree root, int a, int b)
    {
        if (root == null)
            return null;

        if (root.data > a && root.data > b)
            LowestCommonAncestor(root.left, a, b);

        else if (root.data < a && root.data < b)
            LowestCommonAncestor(root.right, a, b);

        else if (root.data > a && root.data < b || root.data < a && root.data > b)
            return root;
        return root;
    }

    public static BTree CreatePreOrder(int[] arr, int ind, BTree root)
    {
        if (root == null)
            return new BTree(arr[ind++]);

        if (root.data > arr[ind])
            root.left = CreatePreOrder(arr, ind, root.left);
        else
            root.right = CreatePreOrder(arr, ind, root.right);

        return root;
    }

     static int  ind1 = 0;
    public static BTree CreatePreOrderUsingUpperBound(int[] arr)
    {

        return build(arr, int.MaxValue);
    }

    private static BTree build(int[] arr, int bound)
    {
        if (ind1 == arr.Length || arr[ind1] > bound) return null;
        BTree root = new BTree(arr[ind1++]);
        root.left = build(arr, root.data);
        root.right = build(arr, bound);
        return root;
    }

    public static List<int> GetInOrder(BTree root)
    {
        Stack<BTree> st = new Stack<BTree>();
        List<int> lt = new List<int>();
        BTree rootCopy = root;
        while (rootCopy != null)
        {
            st.Push(rootCopy);
            rootCopy = rootCopy.left;
        }

        while (st.Count != 0)
        {
            BTree node = st.Pop();
            lt.Add(node.data);
            if (node.right != null)
            {
                node = node.right;
                while (node != null)
                {
                    st.Push(node);
                    node = node.left;
                }
            }
        }

        System.Console.WriteLine("InOrder Tarverse : " + string.Join(", ", lt));
        return lt;
    }

    public static void TwoOrderSum(BTree bTree, int k)
    {
        BTree copy = bTree;
        List<string> sumList = new List<string>(); 
        Stack<BTree> next = new Stack<BTree>();
        while (copy != null)
        {
            next.Push(copy);
            copy = copy.left;
        }
        Stack<BTree> before = new Stack<BTree>();
        copy = bTree;
         while (copy != null)
        {
            before.Push(copy);
            copy = copy.right;
        }
        while (next.Count != 0 && before.Count != 0)
        {
            if (next.Peek().data > before.Peek().data)
                break;
            else if (next.Peek().data + before.Peek().data > k)
            {
                AddAllBeforeRight(before);
            }
            else if (next.Peek().data + before.Peek().data < k)
            {
                AddAllNextLeft(next);
            }
            else
            {
                sumList.Add($"({next.Peek().data}, {before.Peek().data})");
                //next.Pop(); before.Pop();
                AddAllNextLeft(next); AddAllBeforeRight(before);
            }
        }

        System.Console.WriteLine($"Node with Sum {k} : "+ string.Join(", ", sumList));
    }

    private static void AddAllNextLeft(Stack<BTree> next)
    {
        BTree nextNode = next.Pop();
        BTree nextNoderight = nextNode.right;
        while (nextNoderight != null)
        {
            next.Push(nextNoderight);
            nextNoderight = nextNoderight.left;
        }
    }

    private static void AddAllBeforeRight(Stack<BTree> before)
    {
        BTree beforeNode = before.Pop();
        BTree beforeNodeLeft = beforeNode.left;
        while (beforeNodeLeft != null)
        {
            before.Push(beforeNodeLeft);
            beforeNodeLeft = beforeNodeLeft.right;
        }
    }

    private static void RecoverBTS(BTree root)
    {
        BTree first = null;
        BTree middle = null;
        BTree last = null;
        BTree pre = new BTree(int.MinValue);
        InorderToRecover(root, first, middle, last, pre);
        if (first != null && last != null)
        {
            swap(first, last);
        }
        else
        { swap(first, middle); }
        BinaryTreeClass.ITraetiveInOrderTraversal(root);
    }

    private static void InorderToRecover(BTree root, BTree? first, BTree? middle, BTree? last, BTree pre)
    {
        if (root == null)
            return;
        InorderToRecover(root.left, first, middle, last,pre);
        if (pre != null && pre.data > root.data)
        {
            if (first != null)
            {
                first = pre;
                middle = root;
            }
            else
            {
                last = root;
            }
        }
        pre = root;
        InorderToRecover(root.right, first, middle, last, pre);
    }

    private static void swap(BTree node1, BTree node2)
    {
        BTree temp = node1;
        node1 = node2;
        node2 = temp;
    }

    public static int LargestBST(BTree root)
    {
        return LargestBSTSubtree(root).maxSize;
    }

    private static NodeValue LargestBSTSubtree(BTree root)
    {
        if (root == null)
            return new NodeValue(int.MaxValue, int.MinValue, 0);

        NodeValue leftVal = LargestBSTSubtree(root.left);
        NodeValue rightVal = LargestBSTSubtree(root.right);
        if (leftVal.maxSize <= root.data && root.data < rightVal.minVal)
        {
            return new NodeValue(Math.Min(leftVal.minVal, root.data),
            Math.Max(rightVal.maxVal, root.data), (1 + rightVal.maxSize + leftVal.maxSize));
        }
        else
            //return new NodeValue(int.MinValue, int.MaxValue, Math.Max(leftVal.maxSize, rightVal.maxSize));
             return new NodeValue(
            int.MinValue, // Force parent check to fail (parent's data > int.MinValue is usually true)
            int.MaxValue, // Force parent check to fail (parent's data < int.MaxValue is usually true)
            Math.Max(leftVal.maxSize, rightVal.maxSize) // Propagate the maximum size found in children
        );
    }

    public class NodeValue
    {
        public int maxSize;
        public int maxVal;
        public int minVal;

        public NodeValue(int minVal, int maxVal, int maxSize)
        {
            this.minVal = minVal;
            this.maxVal = maxVal;
            this.maxSize = maxSize;
        }
    }
}

    class VerticalRowClass
    {
        public int vertical;
        public int row;
        public BTree node;

    public VerticalRowClass(int vertical, int row, BTree node)
    {
        this.node = node;
        this.vertical = vertical;
        this.row = row;
    }
    
    }

    class NodeWithIndex
    {
        public int index;
        public BTree node;

        public NodeWithIndex(int index, BTree node)
        {
            this.node = node;
            this.index = index;
        }
    }