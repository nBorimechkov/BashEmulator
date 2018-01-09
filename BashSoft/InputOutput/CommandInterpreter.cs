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
        private IContentComparer judge;
        private IDirectoryManager manager;

        public CommandInterpreter(IContentComparer judge, IDirectoryManager manager)
        {
            this.judge = judge;
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
                OutputWriter.DisplayException($"The command {ex.Message} is invalid.");
            } 
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new OpenFileCommand(input, data, this.judge, this.manager);
                case "rm":
                    return new DeleteCommand(input, data, this.judge, this.manager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.manager);
                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.manager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.manager);
                case "cd":
                    return new ChangePathCommand(input, data, this.judge, this.manager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.manager);
                case "show":
                //case "decorder":
                //    tryfdsfds(input, data);
                //    break;
                //case "download":
                //    tryfdsfds(input, data);
                //    break;
                //case "downloadasync":
                //    tryfdsfds(input, data);
                //    break;
                default:
                    throw new InvalidCommandException(input);
            }
        }
    }
}
