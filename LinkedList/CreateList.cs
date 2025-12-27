using System.Net.Http.Headers;

public class SLNode
{
    public int data;
    public SLNode next;

    public SLNode bottom;

    public SLNode(int data, SLNode SLNode = null, SLNode bottom = null)
    {
        this.data = data;
        next = SLNode;
        this.bottom = bottom;
    }
}

public static class LinkedList
{

    public  static void mainn()
    {
        SLNode head = GetList(new int[] {1,2,3,4,5});
        RotateListByFromBack(head, 8);   
    }

    public static SLNode GetList(int[] arr)
    {
        SLNode head = new SLNode(arr[0]);
        SLNode mover = head;
        for (int i = 1; i < arr.Length; i++)
        {
            SLNode temp = new SLNode(arr[i]);
            mover.next = temp;
            mover = mover.next;
        }

        return head;
    }

    public static void PrintLinkedList(SLNode head)
    {
        SLNode temp = head;
        Console.WriteLine();
        while (temp != null)
        {
            Console.Write(" " + temp.data);
            temp = temp.next;
        }
    }

    public static void SeparateOddEvenNode(SLNode head, out SLNode head1, out SLNode head2)
    {
        SLNode mover = head.next.next;
        head1 = head;
        head2 = head.next;
        head1.next = null;
        head2.next = null;
        SLNode mover1 = head1;
        SLNode mover2 = head2;
        int count = 0;
        while (mover != null)
        {
            if (count % 2 == 0)
            {
                mover1.next = mover;
                mover = mover.next;
                mover1 = mover1.next;
                mover1.next = null;
            }
            else
            {
                mover2.next = mover;
                mover = mover.next;
                mover2 = mover2.next;
                mover2.next = null;
            }
            count++;
        }
    }

    public static SLNode SeparateEventOddInSameList(SLNode head)
    {
        SLNode odd = head;
        SLNode even = head.next;
        SLNode evenTemp = even;

        while (odd.next != null && even.next != null)
        {
            odd.next = odd.next.next;
            even.next = even.next.next;

            odd = odd.next;
            even = even.next;
        }

        odd.next = evenTemp;
        return head;
    }

    public static SLNode ReverseList(SLNode head)
    {
        SLNode pre = null;
        SLNode temp = head;
        SLNode next = head.next;
        while (temp != null)
        {
            next = temp.next;
            temp.next = pre;
            pre = temp;
            temp = next;
        }

        return pre;
    }

    public static SLNode ReverseListInKGroup(SLNode head)
    {
        SLNode temp = head;
        SLNode kthNode = null;
        SLNode preNode = null;
        SLNode nextNode = null;
        while (temp != null)
        {
            kthNode = GetktNode(temp);
            if (kthNode == null)
            {
                if (preNode != null)
                    preNode.next = temp;
                break;
            }
            else
            {
                nextNode = kthNode.next;
                kthNode.next = null;
                ReverseList(temp);

                if (temp == head)
                {
                    head = kthNode;
                }
                else
                {
                    preNode.next = kthNode;
                }
                preNode = temp;
                temp = nextNode;
            }
        }

        return head;
    }

    private static SLNode? GetktNode(SLNode temp)
    {
        int count = 1;
        while (temp != null && count < 3)
        {
            count++;
            temp = temp.next;
        }

        if (count == 3) return temp;
        return null;
    }

    public static SLNode ReverseLinkedList(SLNode head)
    {
        SLNode pre = null; SLNode curr = head;
        while (curr != null)
        {
            SLNode next = curr.next;
            curr.next = pre;
            pre = curr;
            curr = next;
        }
        return pre;
    }

    public static SLNode MergeSortedList(SLNode head1, SLNode head2)
    {
        SLNode newHead = head1.data < head2.data ? head1 : head2; SLNode pre1 = null;
        while (head1 != null && head2 != null)
        {
            if (head1.data < head2.data)
            {
                pre1 = head1;
                head1 = head1.next;
            }
            else
            {
                SLNode temp2 = head2.next;
                if (pre1 != null)
                    pre1.next = head2;
                head2.next = head1;
                pre1 = head2;
                head2 = temp2;
            }
        }

        // if (head1 != null)
        //     head2.next = head1;
        // else if (head2 != null)
        //     head1.next = head2;
        return newHead;
    }

    public static SLNode MergeSortedList2(SLNode head1, SLNode head2)
    {
        SLNode l1 = head1.data <= head2.data ? head1 : head2; SLNode newHead = l1;
        SLNode l2 = head1.data > head2.data ? head1 : head2;
        SLNode temp = null;
        while (l1 != null && l2 != null)
        {
            if (l1.data <= l2.data)
            {
                temp = l1;
                l1 = l1.next;
            }
            else
            {
                temp.next = l2;
                SLNode tt = l2;
                l2 = l1;
                l1 = tt;
                temp = null;
            }
        }

        temp.next = l2;
        return newHead;
    }

    public static SLNode ReverseListInK(SLNode node, int k)
    {
        int count = 0;
        SLNode temp = node;
        SLNode dummyNode = new SLNode(0, node);
        SLNode pre = dummyNode;
        SLNode curr = node;
        SLNode next = curr.next;
        while (temp != null)
        {
            count++;
            temp = temp.next;
        }
        int overAllCount = 0;
        int innerCount = 0;
        while (overAllCount < count / k)
        {
            innerCount = 0;
            while (innerCount < k - 1)
            {
                curr.next = next.next;
                next.next = pre.next;
                pre.next = next;
                next = curr.next;
                innerCount++;
            }
            pre = curr;
            curr = pre.next;
            next = curr.next;
            overAllCount++;
        }

        LinkedList.PrintLinkedList(dummyNode.next);
        return dummyNode.next;
    }

    public static bool IsPalindrome(SLNode head)
    {
        SLNode slow = head; SLNode fast = head;
        while (fast.next != null && fast.next.next != null)
        {
            fast = fast.next.next;
            slow = slow.next;
        }

        SLNode reserveHead = ReverseLinkedList(slow.next);
        slow.next = reserveHead;

        fast = slow.next;
        slow = head;
        while (fast != null && slow != null)
        {
            if (fast.data != slow.data)
                return false;

            fast = fast.next;
            slow = slow.next;
        }
        return true;
    }

    public static SLNode CreateBottomAndNextList(List<List<int>> dicWithNextAndItsCommon)
    {
        SLNode dummy = new SLNode(0);
        SLNode temp = dummy;
        foreach (List<int> list in dicWithNextAndItsCommon)
        {
            SLNode head = GetBeforeList(list.ToArray());
            temp.next = head;
            temp = temp.next;
        }

        return dummy.next;
    }

    private static SLNode GetBeforeList(int[] list)
    {
        SLNode dummy = new SLNode(0);
        SLNode temp = dummy;
        foreach (int i in list)
        {
            SLNode node = new SLNode(i);
            temp.bottom = node;
            temp = temp.bottom;
        }

         return dummy.bottom;
    }

    public static SLNode MergeBottomAndNextLists(SLNode head)
    {
        if (head == null || head.next == null)
            return head;

        head.next = MergeBottomAndNextLists(head.next);
        return MergeTwoBottomList(head, head.next);
    }

    private static SLNode MergeTwoBottomList(SLNode head1, SLNode head2)
    {
        SLNode dummy = new SLNode(0);
        SLNode temp = dummy;

        while (head1 != null && head2 != null)
        {
            if (head1.data < head2.data)
            {
                temp.bottom = head1;
                temp = temp.bottom;
                head1 = head1.bottom;
            }
            else
            {
                temp.bottom = head2;
                temp = temp.bottom;
                head2 = head2.bottom;
            }
        }

        if (head1 != null)
            temp.bottom = head1;
        else
            temp.bottom = head2;

        dummy.bottom.next = null;  // do want to maintin the next list.
        return dummy.bottom;
    }

    public static void PrintBottom(SLNode head)
    {
        System.Console.WriteLine();
        while (head != null)
        {
            System.Console.Write($"{head.data}, ");
            head = head.bottom;
        }
    }

    public static SLNode RotateListByFromBack(SLNode node, int k)
    {
        int len = 0; SLNode temp = node;
        while(temp != null)
        {
            len ++;
            temp = temp.next;
        }

        int mod = k%len;
        if (mod == 0) return node;
        bool takeLeft = len - k < k ? true : false;
        SLNode head = node;
        //if (takeLeft)
        {
            //k = len - k;
            head = node; SLNode curr = node; SLNode pre = null;
            while(k != 0)
            {
                while(curr.next != null)
                {
                    pre = curr;
                    curr = curr.next;
                }

                pre.next = null;
                curr.next = head;
                head = curr; pre = null;
                k--;
            }
        }

        PrintLinkedList(head);
        return head;
    }
}