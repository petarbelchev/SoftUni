using System;

namespace _01._Implement_the_CustomList_Class
{
    public class MyList
    {
        private int[] items;
        private const int initialCapacity = 2;

        public MyList()
        {
            items = new int[initialCapacity];
        }

        public int Capacity { get { return items.Length; } }

        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                if (index < 0 && index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index < 0 && index >= Count)
                {
                    throw new ArgumentOutOfRangeException();
                }
                items[index] = value;
            }
        }

        private void Resize()
        {
            int[] resizedList = new int[items.Length * 2];
            for (int i = 0; i < Count; i++)
            {
                resizedList[i] = items[i];
            }
            items = resizedList;
        }

        private void Shrink()
        {
            int[] shrinkedList = new int[items.Length / 2];
            for (int i = 0; i < Count; i++)
            {
                shrinkedList[i] = items[i];
            }
            items = shrinkedList;
        }

        private void ShiftToLeft(int startIndex)
        {
            for (int i = startIndex; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[Count - 1] = 0;
        }

        private void ShiftToRight(int startIndex)
        {
            for (int i = Count; i > startIndex; i--)
            {
                items[i] = items[i - 1];
            }
            items[startIndex] = 0;
        }

        public void Add(int item)
        {
            if (Count == items.Length)
            {
                Resize();
            }

            items[Count] = item;
            Count++;
        }

        public int RemoveAt(int index)
        {
            if (index >= 0 && index < Count)
            {
                int removedItem = items[index];
                ShiftToLeft(index);
                Count--;

                if (Count <= items.Length / 4)
                {
                    Shrink();
                }

                return removedItem;
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }
        }

        public void Insert(int index, int item)
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (Count + 1 > items.Length)
            {
                Resize();
            }

            ShiftToRight(index);

            items[index] = item;
            Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (element == items[i])
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            if (firstIndex < 0 || firstIndex >= Count || secondIndex < 0 || secondIndex >= Count)
            {
                throw new ArgumentOutOfRangeException();
            }

            int firstItem = items[firstIndex];
            items[firstIndex] = items[secondIndex];
            items[secondIndex] = firstItem;
        }

        public int Find(Predicate<int> predicate)
        {
            for (int i = 0; i < Count; i++)
            {
                if (predicate(items[i]))
                    return items[i];
            }
            return default;
        }

        public void Reverse()
        {
            int[] reversedList = new int[items.Length];
            int index = 0;
            for (int i = Count - 1; i >= 0; i--)
            {
                reversedList[index++] = items[i];
            }
            items = reversedList;
        }
    }
}
