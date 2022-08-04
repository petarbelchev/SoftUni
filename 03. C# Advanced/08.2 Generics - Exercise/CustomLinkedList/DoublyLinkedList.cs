using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList<T>
    {
        private LinkedList<T> head;

        private LinkedList<T> tail;

        public int Count { get; private set; }

        private class LinkedList<T>
        {
            public LinkedList(T value)
            {
                Value = value;
            }

            public T Value { get; set; }

            public LinkedList<T> NextNode { get; set; }

            public LinkedList<T> PreviousNode { get; set; }
        }

        public void AddFirst(T element)
        {
            if (Count == 0)
            {
                var newLinkedList = new LinkedList<T>(element);
                head = tail = newLinkedList;
            }
            else
            {
                var newHead = new LinkedList<T>(element);
                newHead.NextNode = head;
                head.PreviousNode = newHead;
                head = newHead;
            }
            Count++;
        }

        public void AddLast(T element)
        {
            if (Count == 0)
            {
                var newLinkedList = new LinkedList<T>(element);
                head = tail = newLinkedList;
            }
            else
            {
                var newTail = new LinkedList<T>(element);
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }
            Count++;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            LinkedList<T> newHead = head.NextNode;
            T removedValue = head.Value;

            if (Count == 1)
            {
                Count = 0;
                head = tail = null;
            }
            else
            {
                newHead.PreviousNode = null;

                if (head.NextNode.NextNode == null)
                {
                    head = tail = newHead;
                }
                else
                {
                    newHead.NextNode = head.NextNode.NextNode;
                    head = newHead;
                }
                Count--;
            }

            return removedValue;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            LinkedList<T> newTail = tail.PreviousNode;
            T removedValue = tail.Value;

            if (Count == 1)
            {
                Count = 0;
                head = tail = null;
            }
            else
            {
                newTail.NextNode = null;

                if (tail.PreviousNode.PreviousNode == null)
                {
                    head = tail = newTail;
                }
                else
                {
                    newTail.PreviousNode = tail.PreviousNode.PreviousNode;
                    tail = newTail;
                }
                Count--;
            }

            return removedValue;
        }

        public void ForEach(Action<T> action)
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            LinkedList<T> currEl = head;

            while (currEl != null)
            {
                action(currEl.Value);
                currEl = currEl.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            LinkedList<T> currEl = head;
            int index = 0;

            while (currEl != null)
            {
                array[index++] = currEl.Value;
                currEl = currEl.NextNode;
            }

            return array;
        }
    }
}
