using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Exceptions;
using BashSoft.Contracts;

namespace BashSoft.InputOutput.Commands
{
    class CreateDirectoryCommand : Command
    {
        public CreateDirectoryCommand(string input, string[] data, IDirectoryManager manager) : base(input, data, manager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string folderName = this.Data[1];
            this.Manager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}

