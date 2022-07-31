using System;
using System.Collections.Generic;

namespace _01._Implement_the_CustomList_Class
{
    class StartUp
    {
        static void Main()
        {
            //var list = new List<int>();

            //list.Find()

            var myList = new MyList();
            
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);

            myList.RemoveAt(1);

            myList.Insert(1, 10);

            myList.Contains(3);

            myList.Swap(1, 2);

            myList[2] = 5;

            myList.RemoveAt(10);

            int result = myList.Find(item => item == 12);

            myList.Reverse();
        }
    }
}
