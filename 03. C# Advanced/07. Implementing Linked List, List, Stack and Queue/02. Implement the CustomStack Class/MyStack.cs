using System;

namespace _02._Implement_the_CustomStack_Class
{
    public class MyStack
    {
        private int[] items;
        private const int initialCapacity = 4;

        public MyStack()
        {
            items = new int[initialCapacity];
        }

        public int Count { get; private set; }

        private void Resize()
        {
            var resizedStack = new int[items.Length * 2];

            for (int i = 0; i < Count; i++)
            {
                resizedStack[i] = items[i];
            }

            items = resizedStack;
        }

        public void Push(int item)
        {
            ShiftToRight();
            items[0] = item;
            Count++;
        }

        public void Pop()
        {
            ShiftToLeft();
            Count--;
        }

        public int Peek()
        {
            if (Count == 0)
                throw new InvalidOperationException("Stack empty!");
            else
                return items[0];
        }

        private void ShiftToRight()
        {
            if (Count + 1 > items.Length)
            {
                Resize();
            }

            for (int i = Count; i > 0; i--)
            {
                items[i] = items[i - 1];
            }
        }

        private void ShiftToLeft()
        {
            for (int i = 0; i < Count - 1; i++)
            {
                items[i] = items[i + 1];
            }
            items[Count - 1] = default;

            if (Count <= items.Length / 4)
            {
                Shrink();
            }
        }

        private void Shrink()
        {
            var shrinkedStack = new int[items.Length / 2];

            for (int i = 0; i < Count; i++)
            {
                shrinkedStack[i] = items[i];
            }

            items = shrinkedStack;
        }

        public void ForEach(Action<object> action)
        {
            for (int i = 0; i < Count; i++)
            {
                action(items[i]);
            }
        }
    }
}
