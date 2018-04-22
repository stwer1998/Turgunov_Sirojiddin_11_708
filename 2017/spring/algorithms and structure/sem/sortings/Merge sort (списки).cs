using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSortList
{
    class Program
    {

        static void Partition(Node head, ref Node front, ref Node back)
        {
            Node fast;
            Node slow;

            if (head == null || head.Next == null)
            {
                front = head; // &a
                back = null; // &b
            }
            else
            {
                slow = head;
                fast = head.Next;
                while (fast != null)
                {
                    fast = fast.Next;
                    if (fast != null)
                    {
                        slow = slow.Next;
                        fast = fast.Next;
                    }
                }
                front = head; // a
                back = slow.Next; // b
                slow.Next = null;
            }
        }

        static Node MergeLists(Node a, Node b)
        {
            Node mergedList;
            if (a == null)
                return b;
            else if (b == null)
                return a;

            if (a.Value <= b.Value)
            {
                mergedList = a;
                mergedList.Next = MergeLists(a.Next, b);
            }
            else
            {
                mergedList = b;
                mergedList.Next = MergeLists(a, b.Next);
            }
            return mergedList;
        }

        public static void MergeSort(ref Node source)
        {
            var head = source;
            Node a = null;
            Node b = null;

            if (head == null || head.Next == null)
                return;

            Partition(head, ref a, ref b);

            MergeSort(ref a);
            MergeSort(ref b);

            source = MergeLists(a, b);
        }

        public static void Main()
        {
            MyLinkedList list = new MyLinkedList();

            list.Add(8);
            list.Add(2);
            list.Add(4);
            list.Add(-1);
            list.Add(6);

            Console.WriteLine(list);
            MergeSort(ref list.Root);
            Console.WriteLine(list);
        }
    }

    class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
    }

    class MyLinkedList
    {
        public Node Root;
        private Node Tail;

        public void Add(int value)
        {
            var node = new Node { Value = value };
            if (Root == null)
                Root = Tail = node;
            else
            {
                Tail.Next = node;
                Tail = node;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            var current = Root;
            while (current != null)
            {
                result.Append($"{current.Value} ");
                current = current.Next;
            }
            return result.ToString();
        }
    }
}