using CommandPattern.Core.Contracts;
using System;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter _commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            _commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            while (true)
            {
                string cmd = Console.ReadLine();

                Console.WriteLine(_commandInterpreter.Read(cmd));
            }
        }
    }
}
