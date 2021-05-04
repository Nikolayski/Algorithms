using System;

namespace ConsoleApp1
{
 public  class Node
    {
        private int data;
        public Node(int data)
        {
            this.data = data;
        }
        public Node Left { get; set; }
        public Node Right { get; set; }

        public int Data
        {
            get
            {
                return this.data;
            }
           
        }
        public void Insert(int value)
        {
            if(value <= this.data)
            {
                if(this.Left==null)
                {
                    this.Left = new Node(value);
                }
                else
                {
                    this.Left.Insert(value);
                }
            }
            else
            {
                if(this.Right == null)
                {
                    this.Right = new Node(value);
                }
                else
                {
                    this.Right.Insert(value);
                }
            }
        }

        public bool Contains(int value)
        {
            if(value == this.Data)
            {
                return true;
            }
            else if(value < this.Data)
            {
                if(this.Left==null)
                {
                    return false;
                }
                return this.Left.Contains(value);
            }
            else
            {
                if(this.Right==null)
                {
                    return false;
                }
                return this.Right.Contains(value);
            }
        }

        public void PrintInOrder()
        {
            if(this.Left!=null)
            {
                this.Left.PrintInOrder();
            }

            Console.WriteLine(this.Data);

            if(this.Right != null)
            {
                this.Right.PrintInOrder();
            }
        }
    }
}




