using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.InputOutput.Commands;

namespace BashSoft
{
    internal class CompareFilesCommand : Command
    {
        public CompareFilesCommand(string input, string[] data, Tester judge, StudentRepository repository, IDirectoryManager manager) : base(input, data, judge, repository, manager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 3)
            {
                string firstPath = this.Data[1];
                string secondPath = this.Data[2];

                this.Judge.CompareContent(firstPath, secondPath);
            }
            else
            {
                throw new InvalidCommandException();
            }
        }
    }
}