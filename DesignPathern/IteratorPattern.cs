using System.Reflection.Metadata;

public interface ITerable<T>
{
   ITreator<T> GetIterator();
}

public interface ITreator<T>
{
    bool HasNext();

    T Next();
}

public class LinkedListIterator : ITreator<int>
{
    private LinkedList1 currentNode;

    public LinkedListIterator(LinkedList1 head)
    {
        currentNode = head;
    }

    public bool HasNext()
    {
       return currentNode != null;
    }

    public int Next()
    {
        int data = currentNode.data;
        currentNode = currentNode.next;
        return data;
    }
}

public class LinkedList1 : ITerable<int>
{
    public int data;
    public LinkedList1 next;
    public LinkedList1(int data, LinkedList1 next = null)
    {
        this.data = data;
        this.next = next;
    }

    public ITreator<int> GetIterator()
    {
       return new LinkedListIterator(this);
    }
}


public static class MethodClass
{
    public static void mainn()
    {
       LinkedList1 head = CreateLinkedList(new int[] {1,2,3,4,5});
       ITreator<int> listItarator = head.GetIterator();

        System.Console.WriteLine();
       while(listItarator.HasNext())
        {
            System.Console.Write(listItarator.Next()+ " ");
        }
    }
    public static LinkedList1 CreateLinkedList(int[] arr)
    {
        LinkedList1 dummy = new LinkedList1(0);
        LinkedList1 temp = dummy;
        foreach(int i in arr)
        {
            temp.next = new LinkedList1(i);
            temp = temp.next;
        }

        return dummy.next;
    }
}