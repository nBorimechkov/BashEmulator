using BashSoft.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.InputOutput.Commands
{
    class DropDatabaseCommand : Command
    {
        public DropDatabaseCommand(string input, string[] data, Tester judge, StudentRepository repository, IDirectoryManager manager) : base(input, data, judge, repository, manager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                OutputWriter.DisplayException(ExceptionMessages.InvalidCommand);
                return;
            }
            this.Repository.UnloadData();
            OutputWriter.WriteMessageOnNewLine("Database dropped");
        }
    }
}
