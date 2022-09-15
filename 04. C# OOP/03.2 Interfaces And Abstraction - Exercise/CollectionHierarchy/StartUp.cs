using CollectionHierarchy.Classes;
using CollectionHierarchy.Interfaces;
using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var addCollection = new AddCollection();
            var addRemoveCollection = new AddRemoveCollection();
            var myList = new MyList();

            string[] itemsToAdd = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            int numOfRemoves = int.Parse(Console.ReadLine());

            AddToCollection(addCollection, itemsToAdd);
            AddToCollection(addRemoveCollection, itemsToAdd);
            AddToCollection(myList, itemsToAdd);

            RemoveFromCollection(addRemoveCollection, numOfRemoves);
            RemoveFromCollection(myList, numOfRemoves);
        }

        private static void AddToCollection(IAdd collection, string[] itemsToAdd)
        {
            foreach (var item in itemsToAdd)
            {
                Console.Write($"{collection.Add(item)} ");
            }

            Console.WriteLine();
        }

        private static void RemoveFromCollection(IRemove collection, int countForRemove)
        {
            for (int i = 0; i < countForRemove; i++)
            {
                Console.Write($"{collection.Remove()} ");
            }

            Console.WriteLine();
        }
    }
}
