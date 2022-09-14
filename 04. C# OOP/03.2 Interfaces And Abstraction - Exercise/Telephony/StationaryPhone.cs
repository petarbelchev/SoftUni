namespace Telephony
{
    using System;

    public class StationaryPhone : ICanCall
    {
        public void Call(string number)
        {
            Console.WriteLine($"Dialing... {number}");
        }
    }
}
