using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft.InputOutput.Commands
{
    class RemoveCommand : Command
    {
        public RemoveCommand(string input, string[] data, IDirectoryManager manager) : base(input, data, manager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            string fileDirName = this.Data[1];
            string path = SessionData.currentPath + "\\" + fileDirName;
            this.Manager.Remove(path);
        }
    }
}
