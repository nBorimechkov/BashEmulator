using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.InputOutput.Commands;

namespace BashSoft
{
    internal class TraverseDirectoryCommand : Command
    {
        public TraverseDirectoryCommand(string input, string[] data, IDirectoryManager manager) : base(input, data, manager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 1)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.Manager.TraverseDirectory();
            
        }
    }
}