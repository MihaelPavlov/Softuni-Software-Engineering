using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CommandPattern.Core
{
    class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] inputArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string commandName = (inputArgs[0]+"Command").ToLower();
            string[] executeCommand = inputArgs.Skip(1).ToArray();


            //getType
            Type commandType = Assembly.GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(n => n.Name.ToLower() == commandName);
            if (commandType==null)
            {
                throw new ArgumentException("Invalid command type!");
            }

            //instance
            ICommand instanceType = Activator.CreateInstance(commandType) as ICommand;

            if (instanceType==null)
            {
                throw new ArgumentException("Invalid command type!");
            }
            //execute
            string result = instanceType.Execute(executeCommand);

            ICommand command = null;

            return result;
        }
    }
}
