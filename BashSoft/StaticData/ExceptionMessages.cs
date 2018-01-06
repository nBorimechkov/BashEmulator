using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    public static class ExceptionMessages
    {
        public const string DataAlreadyInitialised = "Data is already initialized";
        public const string DataNotInitialised = "Data is not initialized";
        
        public const string NonexistentStudent = "The user name for the student you are trying to get does not exist!";
        
        public const string UnauthorizedAccess = "The folder/file you are trying to get access needs a higher level of rights than you currently have.";
        public const string ComparisonOfFilesWithDifferentSizes = "Files not of equal size, certan mismatch";
        
        public const string UnableToGoHigherInPartitionHierarchy = "You have reached the root of the file hierarchy.";
        public const string UnableToParseNumber = "The sequence you've written is not a valid number.";
        public const string InvalidCommand = "The command you entered is invalid.";
        public const string InvalidStudentFilter = "The given filter is not one of the following: excellent/average/poor";
        public const string InvalidComparisonQuery = "The comparison query you want, does not exist in the context of the current program!";

        public const string StudentNotEnrolled = "Student is not enrolled in that course.";
        public const string InvalidNumberOfScores = "Invalid number of scores on task";
        public const string InvalidScore = "Score must be between 0 and 100";
        
    }
}
