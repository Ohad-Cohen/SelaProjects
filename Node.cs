using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxes3
{
    public class Node<T> where T: IComparable
    {
        //public override string ToString()
        //{
        //    return data.ToString();
        //}
        private T data;
        public T Data
        {
            get { return data; }
            set { data = value; }
        }


        private Node<T> rightNode;
        public Node<T> RightNode
        {
            get { return rightNode; }
            set { rightNode = value; }
        }

        private Node<T> leftNode;
        public Node<T> LeftNode
        {
            get { return leftNode; }
            set { leftNode = value; }
        }
        //constructor
        public Node (T value)
        {
            data = value;
        }
        public Node<T> Find(T value)
        {
            Node<T> CurrentNode.;

            while (CurrentNode != null)
            {
                if (value.CompareTo(CurrentNode.data) == 0)
                {
                    return CurrentNode;
                }
                else if (value.CompareTo(CurrentNode.data) == 1)
                {
                    CurrentNode = CurrentNode.rightNode;
                }
                else
                {
                    CurrentNode = CurrentNode.leftNode;
                }
            }
            //Node<T> not found
            return null;
        }
        //recursive
        public void Insert(T value)
        {
            if (value.CompareTo(data) == 0 || value.CompareTo(data) == 1)
            {
                if (rightNode == null)
                {
                    rightNode = new Node<T>(value);
                }
                else
                {//if right is not null
                    rightNode.Insert(value);
                }
            }
            else
            {
                //if value is less than data
                if (leftNode == null)
                {
                    leftNode = new Node<T>(value);
                }
                else
                {
                    leftNode.Insert(value);
                }
            }
        }
        public void InOrder()
        {
            //go  left 
            if (leftNode != null)
                leftNode.InOrder();
            //print root node 
            Console.Write(data + " ");
            
            //go right
            if (rightNode != null)
                rightNode.InOrder();
        }
        public void PreOrder()
        {
            //print root node 
            Console.Write(data + " ");

            //go left
            if (leftNode != null)
                leftNode.PreOrder();

            //go right
            if (rightNode != null)
                rightNode.PreOrder();
        }
        public void Postorder()
        {
            //go left
            if (leftNode != null)
                leftNode.Postorder();

            //go right
            if (rightNode != null)
                rightNode.Postorder();

            //print root node 
            Console.Write(data + " ");
        }
    }
}

