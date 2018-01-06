using BashSoft.InputOutput.Commands;
using BashSoft.Exceptions;
using BashSoft.Contracts;

namespace BashSoft
{
    internal class ChangeAbsolutePathCommand : Command
    {
        public ChangeAbsolutePathCommand(string input, string[] data, Tester judge, StudentRepository repository, IDirectoryManager manager) : base(input, data, judge, repository, manager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string absPath = this.Data[1];
                this.Manager.ChangeCurrentDirectoryAbsolute(absPath);
            }
            else
            {
                throw new InvalidCommandException();
            }
        }
    }
}