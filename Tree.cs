using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes3
{
    public class Tree<T> where T : IComparable
    {
        private Node<T> root;
        public Node<T> Root
        {
            get { return root; }
            set { root = value; }
        }
        public Tree(T data)
        {
            Root = new Node<T>(data);
        }
        public Tree(){}
        public Node<T> Find(T data)
        {
            //if root not null we call find method on the root
            if (root != null)
            {
                // call node method Find
                return root.Find(data);
            }
            else
            {//if root is null
                return null;
            }
        }

        public void Insert(T data)
        {
            //insert if root is not null
            if (root != null)
            {
                root.Insert(data);
            }
            else
            {//if root is null set new node
                root = new Node<T>(data);
            }
        }

        public void Remove(int data)
        {
            //set current and parent to root,
            //so we can remove and use parents reference
            Node<T> current = root;
            Node<T> parent = root;
            bool isLeftChild = false; //which child is removed

            //check if tree is empty
            if (current == null)
            {
                return;
            }

            //Finding the Node    
            while (current != null && current.Data.CompareTo(data) != 0)
            {
                //set current to new parent
                parent = current;

                //if data is less, look left 
                if (data.CompareTo(current.Data) < 0)
                {
                    current = current.LeftNode;
                    isLeftChild = true;
                }
                else
                {
                    current = current.RightNode;
                    isLeftChild = false;
                }
            }
            //if not found
            if (current == null)
            {
                return;
            }
            //case 1 (leaf node):
            if (current.RightNode == null && current.LeftNode == null)
            {
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    //which child should be deleted
                    if (isLeftChild)
                    {
                        //remove left child
                        parent.LeftNode = null;
                    }
                    else
                    {   //remove right child
                        parent.RightNode = null;
                    }
                }
            }
            //case 2 (current has one child):
            else if (current.RightNode == null)
            {
                //if is root 
                if (current == root)
                {
                    root = current.LeftNode;
                }
                else
                {
                    if (isLeftChild)
                    {
                        //set left node of parent to current nodes left child
                        parent.LeftNode = current.LeftNode;
                    }
                    else
                    {   //set right parents node to current nodes left child
                        parent.RightNode = current.LeftNode;
                    }
                }
            }
            else if (current.LeftNode == null) //only has right child
            {
                //if is root 
                if (current == root)
                {
                    root = current.RightNode;
                }
                else
                {
                    if (isLeftChild)
                    {   //set left parent node to current node right child
                        parent.LeftNode = current.RightNode;
                    }
                    else
                    {   //set right parent node to current nodes right child
                        parent.RightNode = current.RightNode;
                    }
                }
            }
            //case 3 (node has two children):
            else
            {
                //find successor (least greater node)
                Node<T> successor = GetSuccessor(current);
                //if is root - successor = new root
                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {//set parents left node as successor
                    parent.LeftNode = successor;
                }
                else
                {//set the parents right as successor
                    parent.RightNode = successor;
                }
            }
        }
        private Node<T> GetSuccessor(Node<T> node)
        {
            Node<T> parentOfSuccessor = node;
            Node<T> successor = node;
            Node<T> current = node.RightNode;

            //go right and down every left node
            while (current != null)
            {
                parentOfSuccessor = successor;
                successor = current;
                current = current.LeftNode;// go lef
            }
            //if succesor is not simply the right node
            if (successor != node.RightNode)
            {
                //set left parent of succesor node to right node of successor
                parentOfSuccessor.LeftNode = successor.RightNode;
                //attach right of node being deleted to successors right node
                successor.RightNode = node.RightNode;
            }
            //attach left of node being deleted to successors left node
            successor.LeftNode = node.LeftNode;

            return successor;
        }
        //InOrder
        //Go Left, then to root, then right recursively
        public void InOrder()
        {
            if (root != null)
                root.InOrder();
        }

        //Preorder
        //Go to Root, then left, then right recursively
        public void Preorder()
        {
            if (root != null)
                root.PreOrder();
        }

        //Postorder
        //Go Left, then right, then to root recursively
        public void Postorder()
        {
            if (root != null)
                root.Postorder();
        }
    }
}

