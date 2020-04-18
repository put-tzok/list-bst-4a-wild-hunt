using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BST
{
    class Node
    {
        public int value;
        public Node left;
        public Node right;
    }

    class Tree
    {
        public Node Insert(ref Node root, int value)
        {
            if (root == null)
            {
                root = new Node();
                root.value = value;
            }
            else if (value < root.value)
            {
                root.left = Insert(ref root.left, value);
            }
            else if (value > root.value)
            {
                root.right = Insert(ref root.right, value);
            }
            return root;
        }
        public Node Search(Node root, int value)
        {
            if (root.value > value)
            {
                return Search(root.left, value);
            }
            else if (root.value < value)
            {
                return Search(root.right, value);
            }
            else if (root.value == value)
            {
                return root;
            }
            else
            {
                return root;
            }
        }
        public Node Maximum(Node root)
        {
            if (root.right != null)
            {
                return Maximum(root.right);
            }
            return root;
        }
        public void Delete(Node root, int value)
        {
            Node target = Search(root, value);
            if (target.left == null && target.right == null)
            {
                target = null;
            }
            else if (target.left != null && target.right == null)
            {
                target = target.left;
            }
            else if (target.left == null && target.right != null)
            {
                target = target.right;
            }
            else
            {
                Node max = Maximum(target.left);
                target.value = max.value;
                max = max.left;
            }
        }
        private int size = 0;
        public void SizeReset()
        {
            size = 0;
        }
        public int Size(Node root)
        {
            if (root == null)
            {
                return size;
            }
            else
            {
                Size(root.left);
                Size(root.right);
                size++;
                return size;
            }
        }
        public int[] ns = new int[] { 1000, 4000, 8000, 10000, 50000, 100000, 500000, 1000000, 5000000, 10000000 };
        public int[] FillIncreasing(int size)
        {
            int[] arr = new int[size];
            for (int i = 0; i < size; i++)
            {
                arr[i] = i;
            }
            return arr;
        }
        public void Shuffle(ref int[] arr, int size)
        {
            Random Rand = new Random();
            for (int i = size - 1; i > 0; i--)
            {
                int j = Rand.Next() % i;
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }
        public bool IsBST(Node root)
        {
            if (root == null)
            {
                return true;
            }
            if (root.left == null && root.right == null)
            {
                return true;
            }
            if (root.left == null && root.right != null)
            {
                return ((root.value < root.right.value) && IsBST(root.left));
            }
            if (root.left != null && root.right == null)
            {
                return ((root.value > root.left.value) && IsBST(root.left));
            }
            return (root.value > root.left.value)
                && (root.value < root.right.value)
                && IsBST(root.left) && IsBST(root.right);

        }
        public void InsertIncreasing(int[] arr, ref Node root, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Insert(ref root, arr[i]);
            }
        }
        public void InsertRandom(int[] arr, ref Node root, int size)
        {
            Shuffle(ref arr, size);
            for (int i = 0; i < size; i++)
            {
                Insert(ref root, arr[i]);
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Node root = null;
            Tree BST = new Tree();
            for (int i = 0; i < BST.ns.Length; i++)
            {
                DateTime dat1 = DateTime.Now;
                BST.InsertIncreasing(BST.FillIncreasing(BST.ns[i]), ref root, BST.ns.Length);
                DateTime dat2 = DateTime.Now;
                var span = dat2 - dat1;
                Debug.Assert(BST.IsBST(root));
                Console.WriteLine(span);
                int[] shuffle = BST.FillIncreasing(BST.ns[i]);
                BST.Shuffle(ref shuffle, BST.ns[i]);
                DateTime dat3 = DateTime.Now;
                for (int j = 0; j < shuffle.Length; j++)
                {
                    BST.Search(root, shuffle[j]);
                }
                DateTime dat4 = DateTime.Now;
                var span2 = dat4 - dat3;
                Console.WriteLine(span2);
            }
        }
    }
}
