using System;

namespace CustomDoublyLinkedList
{
    public class StartUp
    {
        static void Main()
        {
            var doublyLinkedList = new DoublyLinkedList<int>();

            doublyLinkedList.AddFirst(5);
            doublyLinkedList.AddFirst(3);
            doublyLinkedList.AddLast(1);
            doublyLinkedList.AddFirst(7);
            doublyLinkedList.AddLast(8);
            doublyLinkedList.RemoveLast();
            doublyLinkedList.RemoveFirst();

            doublyLinkedList.ForEach(el => Console.WriteLine(el));

            int[] arr = doublyLinkedList.ToArray();
        }
    }
}
