using System;

namespace CustomDoublyLinkedList
{
    public class DoublyLinkedList
    {
        private LinkedList head;

        private LinkedList tail;

        public int Count { get; private set; }

        private class LinkedList
        {
            public LinkedList(int value)
            {
                Value = value;
            }

            public int Value { get; set; }

            public LinkedList NextNode { get; set; }

            public LinkedList PreviousNode { get; set; }
        }

        public void AddFirst(int element)
        {
            if (Count == 0)
            {
                var newLinkedList = new LinkedList(element);
                head = tail = newLinkedList;
            }
            else
            {
                var newHead = new LinkedList(element);
                newHead.NextNode = head;
                head.PreviousNode = newHead;
                head = newHead;
            }
            Count++;
        }

        public void AddLast(int element)
        {
            if (Count == 0)
            {
                var newLinkedList = new LinkedList(element);
                head = tail = newLinkedList;
            }
            else
            {
                var newTail = new LinkedList(element);
                newTail.PreviousNode = tail;
                tail.NextNode = newTail;
                tail = newTail;
            }
            Count++;
        }

        public int RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty!");
            }

            LinkedList newHead = head.NextNode;
            int removedValue = head.Value;

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

        public int RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            LinkedList newTail = tail.PreviousNode;
            int removedValue = tail.Value;

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

        public void ForEach(Action<int> action)
        {
            if (Count == 0)
            {
                throw new InvalidOperationException("The list is empty");
            }

            LinkedList currEl = head;

            while (currEl != null)
            {
                action(currEl.Value);
                currEl = currEl.NextNode;
            }
        }

        public int[] ToArray()
        {
            int[] array = new int[Count];
            LinkedList currEl = head;
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
