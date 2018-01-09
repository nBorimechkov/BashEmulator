using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Exceptions;
using BashSoft.Contracts;

namespace BashSoft.InputOutput.Commands
{
    class MakeDirectoryCommand : Command
    {
        public MakeDirectoryCommand(string input, string[] data, IContentComparer judge, IDirectoryManager manager) : base(input, data, judge, manager)
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

