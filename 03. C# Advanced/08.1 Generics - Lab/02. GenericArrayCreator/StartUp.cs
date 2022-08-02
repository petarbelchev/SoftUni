using System;

namespace GenericArrayCreator
{
    internal class StartUp
    {
        static void Main()
        {
            string[] people = ArrayCreator.Create(5, "Petar");
            int[] number = ArrayCreator.Create(10, 4);
        }
    }
}
