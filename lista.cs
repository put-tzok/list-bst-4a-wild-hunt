using System;
using System.Diagnostics;

namespace List
{
    class Node
    {
        public int value;
        public Node next;
        public Node(int value, Node head)
        {
            this.value = value;
            this.next = head;
        }
    }
    class List
    {
        public Node head = null;
        public Node Insert(int value)
        {
            head = new Node(value, head);
            return head;
        }
        public Node Search(int value)
        {
            Node iter = head;
            while (iter != null && iter.value != value)
            {
                iter = iter.next;
            }
            return iter;
        }
        public void Delete(int value)
        {
            if (head.value == value)
            {
                head = head.next;
            }
            else
            {
                Node prev = head;
                Node iter = head.next;
                while (iter != null && iter.value != value)
                {
                    prev = iter;
                    iter = iter.next;
                }
                if (iter != null)
                {
                    prev.next = iter.next;
                }
            }
        }
        public int Size()
        {
            int size = 0;
            Node iter = head;
            while (iter != null)
            {
                size++;
                iter = iter.next;
            }
            return size;
        }
        public int[] ns = new int[] { 5, 10, 50, 100, 500, 1000, 5000, 10000, 50000, 100000 };
        //public int[] ns = new int[] { 1000, 4000, 8000, 10000, 50000, 100000, 500000, 1000000, 5000000, 10000000 };
        public int[] FillIncreasing(int size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = i;
            }
            return arr;
        }
        public void Shuffle(ref int[] arr)
        {
            Random Rand = new Random();
            for (int i = arr.Length - 1; i > 0; i--)
            {
                int j = Rand.Next() % i;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List LST = new List();
            bool[] no_yes = new bool[] { false, true };
            for (int i = 0; i < no_yes.Length; i++)
            {
                bool eneble_shuffle = no_yes[i];

                for (int j = 0; j < LST.ns.Length; j++)
                {
                    var arr = LST.FillIncreasing(LST.ns[j]);
                    if (eneble_shuffle)
                    {
                        LST.Shuffle(ref arr);
                    }
                    DateTime insertion_start = DateTime.Now;
                    for (int k = 0; k < arr.Length; k++)
                    {
                        Node iter = LST.Insert(arr[k]);
                        Debug.Assert(iter != null);
                        Debug.Assert(iter.value == arr[k]);
                    }
                    DateTime insertion_stop = DateTime.Now;
                    var insertion_time = insertion_stop - insertion_start;

                    LST.Shuffle(ref arr);

                    DateTime search_start = DateTime.Now;
                    for (int k = 0; k < arr.Length; k++)
                    {
                        Node iter = LST.Search(arr[k]);
                        Debug.Assert(iter != null);
                        Debug.Assert(iter.value == arr[k]);
                    }
                    DateTime search_stop = DateTime.Now;
                    var search_time = search_stop - search_start;

                    LST.Shuffle(ref arr);

                    for (int k = 0, l = arr.Length; k < arr.Length; k++, l--)
                    {
                        Debug.Assert(LST.Size() == l);
                        LST.Delete(arr[k]);
                    }
                    Debug.Assert(LST.Size() == 0);
                    Debug.Assert(LST.head == null);

                    Console.WriteLine("{0}, {1}, {2}, {3}", arr.Length, no_yes[i], insertion_time, search_time);
                }
            }
        }
    }
}

