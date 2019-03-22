using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp22
{
    class BinaryTree
    {
        private Node root;
        private int count;

        public BinaryTree()
        {
            root = null;
            count = 0;
        }
        public bool isEmpty()
        {
            return root == null;
        }

        public void insert(string sname, int d)
        {
            if (isEmpty())
            {
                root = new Node(sname, d);
            }
            else
            {
                root.insertData(ref root, sname, d);
            }

            count++;
        }

        public bool search(int s)
        {
            return root.search(root, s);
        }

        public bool isLeaf()
        {
            if (!isEmpty())
                return root.isLeaf(ref root);

            return true;
        }

        public void display()
        {
            if (!isEmpty())
                root.display(root);
        }
    }
    class Node
    {
        private int number;
        private string name;
        public Node rightLeaf;
        public Node leftLeaf;

        public Node(string sname, int value)
        {
            name = sname;
            number = value;
            rightLeaf = null;
            leftLeaf = null;
        }

        public bool isLeaf(ref Node node)
        {
            return (node.rightLeaf == null && node.leftLeaf == null);

        }

        public void insertData(ref Node node, string sname, int data)
        {
            if (node == null)
            {
                node = new Node(sname, data);
            }
            else if (node.number < data)
            {
                insertData(ref node.rightLeaf, sname, data);
            }

            else if (node.number > data)
            {
                insertData(ref node.leftLeaf, sname, data);
            }
        }

        public bool search(Node node, int s)
        {
            if (node == null)
                return false;

            if (node.number == s)
            {
                return true;
            }
            else if (node.number < s)
            {
                return search(node.rightLeaf, s);
            }
            else if (node.number > s)
            {
                return search(node.leftLeaf, s);
            }

            return false;
        }

        public void display(Node n)
        {
            if (n == null)
                return;

            display(n.leftLeaf);
            Console.Write(" " + n.name + " " + n.number );
            display(n.rightLeaf);
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree b = new BinaryTree();

            b.insert("vanya", 1);
            b.insert("maria", 6);
            b.insert("ksenia", 8);
            b.insert("mark", 4);
            b.insert("karl", 5);
            b.insert("liza", 3);

            b.display();

            Console.ReadLine();
        }
    }
}
