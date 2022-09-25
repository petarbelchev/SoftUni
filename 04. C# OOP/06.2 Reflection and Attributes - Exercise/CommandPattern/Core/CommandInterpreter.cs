using CommandPattern.Core.Contracts;
using CommandPattern.Exceptions;
using System;
using System.Linq;
using System.Reflection;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] tokens = args.Split();
            string cmdName = tokens[0];
            string[] cmdArgs = tokens.Skip(1).ToArray();

            Assembly assembly = Assembly.GetCallingAssembly();

            Type cmdType = assembly
                .GetTypes()
                .Where(t => t.Name == $"{cmdName}Command" &&
                            t.GetInterfaces().Contains(typeof(ICommand)))
                .FirstOrDefault();

            if (cmdType == null)
                throw new InvalidCommandType($"The program don't support {cmdName} command");

            var cmdInstance = Activator.CreateInstance(cmdType);

            MethodInfo executeMethod = cmdType
                .GetMethods()
                .FirstOrDefault(m => m.Name == "Execute");

            string result = (string)executeMethod.Invoke(cmdInstance, new object[] { cmdArgs });

            return result;
        }
    }
}
