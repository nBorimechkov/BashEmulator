using BashSoft.Contracts;
using BashSoft.Exceptions;
using BashSoft.InputOutput.Commands;
using System;

namespace BashSoft
{
    internal class PrintOrderedStudentsCommand : Command
    {
        public PrintOrderedStudentsCommand(string input, string[] data, Tester judge, StudentRepository repository, IDirectoryManager manager) : base(input, data, judge, repository, manager)
        {
        }

        public override void Execute()
        {
            TryOrderAndTake(this.Data);
        }

        private void TryOrderAndTake(string[] data)
        {
            if (data.Length == 5)
            {
                string courseName = data[1];
                string criteria = data[2];
                string takeCommand = data[3].ToLower();
                string studentsToTake = data[4].ToLower();

                TryParseParamatersForOrderAndTake(takeCommand, studentsToTake, courseName, criteria);
            }
            else
            {
                throw new InvalidCommandException();
            }

        }

        private void TryParseParamatersForOrderAndTake(string takeCommand, string studentsToTake, string courseName, string criteria)
        {
            if (takeCommand == "take")
            {
                if (studentsToTake == "all")
                {
                    this.Repository.OrderAndTake(courseName, criteria);
                }
                else
                {
                    try
                    {
                        this.Repository.OrderAndTake(courseName, criteria, int.Parse(studentsToTake));
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