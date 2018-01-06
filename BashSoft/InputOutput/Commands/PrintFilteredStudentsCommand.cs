using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.InputOutput.Commands;
using System;

namespace BashSoft
{
    internal class PrintFilteredStudentsCommand : Command
    {
        public PrintFilteredStudentsCommand(string input, string[] data, Tester judge, StudentRepository repository, IDirectoryManager manager) : base(input, data, judge, repository, manager)
        {
        }

        public override void Execute()
        {
            this.TryFilterAndTake(this.Data);
        }

        private void TryFilterAndTake(string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string filter = data[2];
                string takeCommand = data[3].ToLower();
                string studentsToTake = data[4].ToLower();

                TryParseParamatersForFilterAndTake(takeCommand, studentsToTake, courseName, filter);
            }
            else
            {
                throw new InvalidCommandException();
            }
        }

        private void TryParseParamatersForFilterAndTake(string takeCommand, string studentsToTake, string courseName, string filter)
        {
            if (takeCommand == "take")
            {
                if (studentsToTake == "all")
                {
                    this.Repository.FilterAndTake(courseName, filter);
                }
                else
                {
                    try
                    {
                        this.Repository.FilterAndTake(courseName, filter, int.Parse(studentsToTake));
                    }
                    catch (Exception)
                    {
                        throw new InvalidCommandException();
                    }
                }
            }
            else
            {
                throw new InvalidCommandException();
            }
        }
    }
}