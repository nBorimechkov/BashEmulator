using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.InputOutput.Commands;

namespace BashSoft
{
    internal class TraverseFoldersCommand : Command
    {
        public TraverseFoldersCommand(string input, string[] data, IContentComparer judge, IDirectoryManager manager) : base(input, data, judge, manager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 1)
            {
                this.Manager.TraverseDirectory();
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}