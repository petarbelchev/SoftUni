using System;
using System.Collections;
using System.Collections.Generic;

namespace Stack
{
    public class MyStack<T> : IEnumerable<T>
    {
        private const int initialCapacity = 4;

        public MyStack()
        {
            this.Items = new T[initialCapacity];
            this.Count = 0;
        }

        public T[] Items { get; private set; }

        public int Count { get; private set; }

        public int Capacity { get { return this.Items.Length; } }

        public void Push(params T[] items)
        {
            foreach (var item in items)
            {
                if (this.Count == this.Items.Length)
                {
                    Resize();
                }
                else
                {
                    ShiftRight();
                    this.Items[0] = item;
                    this.Count++;
                }
            }
        }

        private void ShiftRight()
        {
            if (this.Count == this.Items.Length)
            {
                Resize();
            }
            else
            {
                for (int i = this.Count - 1; i >= 0; i--)
                {
                    this.Items[i + 1] = this.Items[i];
                }
                this.Items[0] = default;
            }
        }

        public void Pop()
        {
            if (this.Count > 0)
            {
                ShiftLeft();
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        private void ShiftLeft()
        {
            for (int i = 0; i < this.Count - 1; i++)
            {
                this.Items[i] = this.Items[i + 1];
            }
            this.Items[this.Count - 1] = default;
            this.Count--;

            if (this.Count < this.Items.Length / 4)
            {
                Shrink();
            }
        }

        private void Resize()
        {
            T[] resizedArray = new T[this.Items.Length * 2];
            for (int i = 0; i < this.Count; i++)
            {
                resizedArray[i] = this.Items[i];
            }
            this.Items = resizedArray;
        }

        private void Shrink()
        {
            T[] shrinkedArray = new T[this.Items.Length / 2];
            for (int i = 0; i < this.Count; i++)
            {
                shrinkedArray[i] = this.Items[i];
            }
            this.Items = shrinkedArray;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.Items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
