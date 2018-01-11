using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.InputOutput.Commands
{
    class CreateFileCommand : Command
    {
        public CreateFileCommand(string input, string[] data, IDirectoryManager manager) : base(input, data, manager)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string folderName = this.Data[1];
            this.Manager.CreateFileInCurrentFolder(folderName);
        }
    }
}
