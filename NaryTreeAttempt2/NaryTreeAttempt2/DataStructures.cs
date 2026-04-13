using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NaryTreeAttempt2
{

    //Burayı public yaptım çünkü ilerde burayı kütüphane olarak kullanılabilir hale getirmek istedim
    public class DataStructures
    {
        public class Node<T>
        {
            private T _value;
            private List<Node<T>> childrens;
            public Node<T> next;

            public Node(T value)
            {
                Value = value;
                this.childrens = new List<Node<T>>();
            }

            public T Value
            {
                get
                {
                    return _value;
                }
                set
                {                    
                    _value = value;
                }
            }        
        }


        public class List<T>
        {
            Node<T> head;
            Node<T> tail;

            public List()
            {
                head = null;
                tail = null;
            }


            public void Add(Node<T> node)
            {
                Node<T> newNode = node;
                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.next = newNode;
                    tail = newNode;
                }
            }     

            public void RemoveLast()
            {
                if (head == null) { return; }
                if (head == tail)
                {
                    head = null;
                    tail = null;
                    return;
                }
                Node<T> current = head;
                while (current.next != tail)
                {
                    current = current.next;
                }
                current.next = null;
                tail = current;
            }

            public void Remove(Node<T> node)
            {
                if(head == null) { return; }
                if (head == node)
                {
                    head = null;
                    tail = null;
                    return;
                }
                Node<T> current = head;
                while (current.next != null)
                {
                    if (current.next == node)
                    {
                        current.next = current.next.next;
                        if (current.next == null)
                        {
                            tail = current;
                        }
                        return;
                    }
                    current = current.next;
                }
            }


            public void Print()
            {
                Node<T> current = head;
                Console.WriteLine("\nList elements:");
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.next;
                }
            }

        }
    }
}
