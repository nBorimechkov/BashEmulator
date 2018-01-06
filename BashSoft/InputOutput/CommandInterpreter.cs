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
        private IDatabase repository;

        public CommandInterpreter(IContentComparer judge, IDirectoryManager manager, IDatabase repository)
        {
            this.judge = judge;
            this.manager = manager;
            this.repository = repository;
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
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            } 
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {
            switch (command)
            {
                case "open":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.manager);
                case "mkdir":
                    return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.manager);
                case "deldir":
                    return new DeleteDirectoryCommand(input, data, this.judge, this.repository, this.manager);
                case "ls":
                    return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.manager);
                case "cmp":
                    return new CompareFilesCommand(input, data, this.judge, this.repository, this.manager);
                case "cdrel":
                    return new ChangeRelativePathCommand(input, data, this.judge, this.repository, this.manager);
                case "cdabs":
                    return new ChangeAbsolutePathCommand(input, data, this.judge, this.repository, this.manager);
                case "readdb":
                    return new ReadDatabaseCommand(input, data, this.judge, this.repository, this.manager);
                case "dropdb":
                    return new DropDatabaseCommand(input, data, this.judge, this.repository, this.manager);
                case "help":
                    return new GetHelpCommand(input, data, this.judge, this.repository, this.manager);
                case "show":
                    return new ShowCourseCommand(input, data, this.judge, this.repository, this.manager);
                case "filter":
                    return new PrintFilteredStudentsCommand(input, data, this.judge, this.repository, this.manager);
                case "order":
                    return new PrintOrderedStudentsCommand(input, data, this.judge, this.repository, this.manager);
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
