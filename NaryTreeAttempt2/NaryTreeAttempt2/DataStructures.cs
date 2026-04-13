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
            public Node<T> prev;

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


            public void Add(T item)
            {
                Node<T> newNode = new Node<T>(item);
                if (head == null)
                {
                    head = newNode;
                    tail = newNode;
                }
                else
                {
                    tail.next = newNode;
                    newNode.prev = tail;
                    tail = newNode;                    
                }
            }

            public void RemoveLast()
            {
                if (head == null) { throw new InvalidOperationException("List is empty."); }
                if (head == tail)
                {
                    head = null;
                    tail = null;
                    return;
                }
                tail.prev.next = null;
                tail = tail.prev;
            }

            public void Remove(T item)
            {
                if (head == null) { return; }
                if (head == tail && EqualityComparer<T>.Default.Equals(head.Value, item))
                {
                    head = null;
                    tail = null;
                    return;
                }
                if (EqualityComparer<T>.Default.Equals(head.Value, item))
                {
                    head = head.next;
                    if (head != null)
                    {
                        head.prev = null;
                    }                 
                    return;
                }
                Node<T> current = head;
                while (current.next != null)
                {
                    if (EqualityComparer<T>.Default.Equals(current.next.Value, item))
                    {
                        if(current.next.next != null)
                        {
                            current.next.next.prev = current;
                        }
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

        public class Stack<T>
        {

            Node<T> Top;
            private int _count;

            public Stack()
            {
                Top = null;
            }


            public int Count
            {
                get
                {
                    return _count;
                }
                private set
                {
                    _count = value;
                }
            }


            public void Push(T item)
            {
                Node<T> newNode = new Node<T>(item);
                newNode.next = Top; // Top null olsa bile sorunsuz çalışır.
                Top = newNode;
                Count++;
            }

            public T Pop()
            {
                if (Top == null) { throw new InvalidOperationException("Stack is empty."); }
                T value = Top.Value;
                Top = Top.next;
                Count--;
                return value;
            }


            public T Peek()
            {
                if (Top == null) { throw new InvalidOperationException("Stack is empty."); }
                return Top.Value;
            }


            public bool IsEmpty()
            {
                return Top == null;
            }
        }

        public class Queue<T>
        {
            Node<T> head;
            Node<T> tail;
            private int _count;

            public Queue()
            {
                head = null;
                tail = null;
                _count = 0;
            }

            public int Count
            {
                get { return _count; }
                private set { _count = value; }
            }

            public void Enqueue(T item)
            {
                Node<T> newNode = new Node<T>(item);
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
                Count++;
            }

            public T Dequeue()
            {
                if (head == null) { throw new InvalidOperationException("Queue is empty."); }
                T value = head.Value;
                head = head.next;
                if (head == null)
                {
                    tail = null;
                }
                Count--;
                return value;
            }

            public T Peek()
            {
                if (head == null) { throw new InvalidOperationException("Queue is empty."); }
                return head.Value;
            }

            public bool IsEmpty()
            {
                return head == null;
            }
        }



    }
}
