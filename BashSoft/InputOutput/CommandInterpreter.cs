using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.InputOutput.Commands;
using BashSoft.Exceptions;
using BashSoft.Contracts;

namespace BashSoft
{
    class CommandInterpreter : IInterpreter
    {
        
        private IDirectoryManager manager;

        public CommandInterpreter(IDirectoryManager manager)
        {
            this.manager = manager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split(' ');
            string commandName = data[0];

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (InvalidCommandException ex)
            {
                OutputWriter.DisplayException(InvalidCommandException.InvalidCommand + ex.Message);
            } 
        }

        // Command pattern, Client
        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.manager);
                case "rm":
                    return new RemoveCommand(input, data, this.manager);
                case "mv":
                    return new MoveCommand(input, data, this.manager);
                case "cp":
                    return new CopyFileCommand(input, data, this.manager);
                case "mkdir":
                    return new CreateDirectoryCommand(input, data, this.manager);
                case "mkfile":
                    return new CreateFileCommand(input, data, this.manager);
                case "ls":
                    return new TraverseDirectoryCommand(input, data, this.manager);
                case "cd":
                    return new ChangeDirectoryCommand(input, data, this.manager);
                case "help":
                    return new GetHelpCommand(input, data, this.manager);
                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}
