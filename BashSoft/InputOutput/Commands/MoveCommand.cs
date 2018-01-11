using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BashSoft.Contracts;
using BashSoft.Exceptions;

namespace BashSoft.InputOutput.Commands
{
    class MoveCommand : Command
    {
        public MoveCommand(string input, string[] data, IDirectoryManager manager) : base(input, data, manager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            string toMove = this.Data[1];
            string destPath = this.Data[2];
            this.Manager.Move(toMove, destPath);
        }
    }
}
