using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NEC_CodeTest
{
    class BinaryTree
    {
        public class Node
        {
            public int value;
            public Node left, right, next;
            public Node(int _val, Node _left, Node _right)
            {
                value = _val;
                left = _left;
                right = _right;
                next = null;
            }
        }
        public Node ConnectTree(Node root)
        {
            Node pre = root;
            Node nextPre = null;
            Node prev = null;
            while (pre != null)
            {
                while (pre != null)
                {
                    if (pre.left != null)
                    {
                        if (prev != null)
                        {
                            prev.next = pre.left;
                        }
                        else
                        {
                            nextPre = pre.left;
                        }
                        prev = pre.left;
                    }
                    if (pre.right != null)
                    {
                        if (prev != null)
                        {
                            prev.next = pre.right;
                        }
                        else
                        {
                            nextPre = pre.right;
                        }
                        prev = pre.right;
                    }
                    pre = pre.next;
                }
                pre = nextPre;
                nextPre = null;
                prev = null;
            }
            return root;
        }
        public static void printTree(Node root)
        {
            Console.Write("[");
            if (root == null)
            {
                return;
            }
            Queue<Node> queue = new Queue<Node>();
            Node curr;
            var initailNum = 1;
            queue.Enqueue(root);
            queue.Enqueue(null);
            while (queue.Count > 1)
            {
                curr = queue.Peek();
                queue.Dequeue();
                if (curr == null)
                {
                    queue.Enqueue(null);
                }
                else
                {
                    if (curr.left != null)
                    {
                        queue.Enqueue(curr.left);
                    }
                    if (curr.right != null)
                    {
                        queue.Enqueue(curr.right);
                    }
                    if (curr.value == 0)
                    {
                        Console.Write("null");
                        Console.Write(", ");
                    }
                    else
                    {
                        if(initailNum == 1)
                        {
                            Console.Write(curr.value);                           
                        }
                        else
                        {
                            Console.Write(", " + curr.value);
                        }                                        
                        Console.Write(", ");
                        if (curr.next == null)
                        {
                            Console.Write("#");
                        }
                        initailNum = 0;
                    }
                }
            }
            Console.Write("]");
            Console.Write("\n");
            Console.ReadLine();
        }
        static void Main()
        {
            BinaryTree obj = new BinaryTree();
            Node root;
            Node nodeFour = new Node(4, null, null);
            Node nodeFive = new Node(5, null, null);
            Node nodeSeven = new Node(7, null, null);
            Node nodeThree = new Node(3, null, nodeSeven);
            Node nodeTwo = new Node(2, nodeFour, nodeFive);
            Node nodeOne = new Node(1, nodeTwo, nodeThree);
            root = nodeOne;
            root = obj.ConnectTree(root);
            printTree(root);
        }
    }
}
