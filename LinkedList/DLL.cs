public class Node
    {
        public int data;
        public Node next;
        public Node pre;

        public Node(int data, Node pre = null, Node next = null)
        {
            this.data = data;
            this.pre = pre;
            this.next = next;
        }
    }

public class DoubleLL
{
    public static Node CreateDLL(int[] arr)
    {
        Node head = new Node(arr[0]);
        Node mover = head;
        for (int i = 1; i < arr.Length; i++)
        {
            Node temp = new Node(arr[i]);
            mover.next = temp;
            temp.pre = mover;
            mover = temp;
        }
        return head;
    }

    public static void WriteDLL(Node head)
    {
        Node mover = head;
        Console.WriteLine();
        while (mover != null)
        {
            Console.Write(" " + mover.data);
            mover = mover.next;
        }
    }

    public static Node DeleteAtIndex(Node head, int k)
    {
        Node mover = head;
        int count = 1;
        while (mover != null)
        {
            if (k == count)
            {
                mover.pre.next = mover.next;
                mover.next.pre = mover.pre;
                break;
            }
            mover = mover.next;
            count++;
        }

        return head;
    }

    public static Node InsertAtIndex(Node head, int k, int val)
    {
        Node mover = head;
        int count = 1;
        while (mover != null)
        {
            if (count == k)
            {
                Node temp = new Node(val);
                temp.pre = mover.pre;
                mover.pre.next = temp;

                temp.next = mover;
                mover.pre = temp;
                break;
            }
            count++;
            mover = mover.next;
        }
        return head;
    }

    public static Node ReverseDLL(Node head)
    {
        Node last = null;
        Node cuurrent = head;
        Node lastNode = GetLastNode(head, out int count);
        // int ct = 0;

        //     while (ct != count / 2)
        //     {
        //         int tempData = temp.data;
        //         temp.data = lastNode.data;
        //         lastNode.data = tempData;

        //         temp = temp.next;
        //         lastNode = lastNode.pre;
        //         ct++;
        //     }

        // return head;

        while (cuurrent != null)
        {
            last = cuurrent.pre;
            cuurrent.pre = cuurrent.next;
            cuurrent.next = last;

            cuurrent = cuurrent.pre;
        }

        return last.pre;

        // Node Middle = GetMiddleNode(head);
        // while (temp != Middle)
        // {
        //     int tempData = temp.data;
        //     temp.data = lastNode.data;
        //     lastNode.data = tempData;

        //     temp = temp.next;
        //     lastNode = lastNode.pre;
        // }
        // return head;
    }

    public static Node GetLastNode(Node head, out int count)
    {
        count = 1;
        Node temp = head;
        while (temp.next != null)
        {
            count++;
            temp = temp.next;
        }
        count++;
        return temp;
    }

    public static Node GetMiddleNode(Node head)
    {
        Node slow = head;
        Node fast = head;
        while (fast.next != null && fast.next.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;
        }

        return slow;
    }
}