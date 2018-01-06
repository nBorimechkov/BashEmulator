using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.InputOutput.Commands;

namespace BashSoft
{
    internal class ShowCourseCommand : Command
    {
        public ShowCourseCommand(string input, string[] data, Tester judge, StudentRepository repository, IDirectoryManager manager) : base(input, data, judge, repository, manager)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                string courseName = this.Data[1];
                Repository.GetAllStudentsFromCourse(courseName);
            }
            else if (this.Data.Length == 3)
            {
                string courseName = this.Data[1];
                string studentName = this.Data[2];
                Repository.GetStudentScoresFromCourse(courseName, studentName);
            }
            else
            {
                throw new InvalidCommandException();
            }
        }
    }
}