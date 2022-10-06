using _153505_Kiselev_Lab2.Interfaces;
using System.Collections;

namespace _153505_Kiselev_Lab2.Collection
{
    class Node<T>
    {
        public Node(T data) => Data = data;
        public Node<T>? Next { get; set; } = null;
        public T Data { get; set; }

    }

    internal class MyCustomCollection<T> : ICustomCollection<T>, IEnumerable
    {
        public MyCustomCollection()
        {
            head = null;
            tail = null;
            current = null;
            count = 0;
        }

        private Node<T>? head;
        private Node<T>? tail;
        private Node<T>? current;

        private int count;

        public T this[int index]
        {
            get
            {
                int currentIndex = 0;
                var buffCurrent = head;

                while (currentIndex != index && buffCurrent != null)
                {
                    ++currentIndex;
                    buffCurrent = buffCurrent.Next;
                }

                if (currentIndex == index && buffCurrent.Data != null)
                {
                    return buffCurrent.Data;
                }

                throw new IndexOutOfRangeException();
            }
            set
            {
                int currentIndex = 0;
                var buffCurrent = head;

                while (currentIndex != index && buffCurrent != null)
                {
                    ++currentIndex;
                    buffCurrent = buffCurrent.Next;
                }

                if (currentIndex == index)
                {
                    buffCurrent.Data = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public int Count { get => count; }

        public void Add(T item)
        {
            var newNode = new Node<T>(item);

            if (head == null)
            {
                head = newNode;
                tail = newNode;
                current = newNode;
                ++count;
            }
            else
            {
                tail.Next = newNode;
                tail = tail.Next;
                ++count;
            }
        }

        public T Current()
        {
            if (current != null)
            {
                return current.Data;
            }

            throw new NullReferenceException();
        }

        public void Next()
        {
            if (current.Next != null)
            {
                current = current.Next;
            }
            else
            {
                Reset();
            }
        }

        public void Remove(T item)
        {
            if (head != null)
            {
                var buffCurrent = head;
                var buffNext = buffCurrent.Next;

                if (head.Data.Equals(item))
                {
                    head = buffNext;
                    --count;

                    Reset();

                    if (count == 0)
                    {
                        current = null;
                        tail = null;
                    }

                    return;
                }

                while (buffNext != null)
                {
                    if (buffNext.Data.Equals(item))
                    {
                        buffCurrent.Next = buffNext.Next;
                        --count;

                        if (count == 0)
                        {
                            current = null;
                            tail = null;
                        }
                        else if (buffNext.Next == null)
                        {
                            tail = buffCurrent;
                        }

                        Reset();

                        return;
                    }
                    else
                    {
                        buffCurrent = buffNext;
                        buffNext = buffCurrent.Next;
                    }
                }
            }

            throw new _153505_Kiselev_Lab2.Entities.MyException("Element to be removed is missing!");
        }

        public T RemoveCurrent()
        {
            if (current != null)
            {
                var buff = current.Data;
                Remove(buff);

                return buff;
            }

            throw new NullReferenceException();
        }

        public void Reset()
        {
            current = head;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var buff = head;

            while (buff != null)
            {
                yield return buff.Data;

                buff = buff.Next;
            }
        }
    }
}
