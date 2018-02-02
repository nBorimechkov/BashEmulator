using BashSoft.Contracts;
using BashSoft.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BashSoft
{
    // Command patern, Receiver
    public class IOManager : IDirectoryManager
    {
        public void TraverseDirectory()
        {
            try
            {
                foreach (var directory in Directory.GetDirectories(SessionData.currentPath))
                {
                    int indexOfLastSlash = directory.LastIndexOf("\\");
                    string dirName = directory.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine(dirName);
                }
                OutputWriter.WriteEmptyLine();

                foreach (var file in Directory.GetFiles(SessionData.currentPath)) 
                {
                    int indexOfLastSlash = file.LastIndexOf("\\");
                    string fileName = file.Substring(indexOfLastSlash);
                    OutputWriter.WriteMessageOnNewLine(fileName);
                }
                OutputWriter.WriteEmptyLine();
            }
            catch (UnauthorizedAccessException ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        
        }

        public void ChangeCurrentDirectory(string path)
        {
            string currentPath = SessionData.currentPath;
            // one up
            if (path == "..")
            {
                int indexOfLastSlash = currentPath.LastIndexOf("\\");
                string newPath = currentPath.Substring(0, indexOfLastSlash);
                SessionData.currentPath = newPath;
            }

            // Absolute path
            else if (Path.IsPathRooted(path))
            {
                if (!Directory.Exists(path))
                {
                    throw new InvalidPathException();
                }
                SessionData.currentPath = path;
            }

            // Relative path
            else
            {
                currentPath += "\\" + path;
                if (!Directory.Exists(currentPath))
                {
                    throw new InvalidPathException("duhai");
                }
                SessionData.currentPath = currentPath;

            }
        }

        public void CreateDirectoryInCurrentFolder(string name)
        {
            string path = SessionData.GetCurrentDirectoryPath() + "\\" + name;
            try
            {
                Directory.CreateDirectory(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void CreateFileInCurrentFolder(string name)
        {
            string path = SessionData.GetCurrentDirectoryPath() + "\\" + name;
            try
            {
                File.Create(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void CopyFile(string fileName, string destinationPath)
        {
            string currentPath = SessionData.currentPath;
            string sourcePath = currentPath + "\\" + fileName;
            destinationPath = destinationPath + "\\" + fileName;
            try
            {
                File.Copy(sourcePath, destinationPath);
            }
            catch (Exception ex)
            {
                OutputWriter.DisplayException(ex.Message);
            }
        }

        public void Move(string toMove, string destinationPath)
        {
            string currentPath = SessionData.currentPath;
            string sourcePath = currentPath + "\\" + toMove;
            destinationPath = destinationPath + "\\" + toMove;
            try
            {
                Directory.Move(sourcePath, destinationPath);
            }
            catch (ArgumentException)
            {
                throw new InvalidFileNameException();
            }
        }

        public void Remove(string path)
        {
            if (Directory.Exists(path))
            {
                try
                {
                    Directory.Delete(path);

                }
                catch (Exception e)
                {
                    OutputWriter.DisplayException(e.Message);
                }
            }
            else if (File.Exists(path))
            {
                try
                {
                    File.Delete(path);

                }
                catch (Exception e)
                {
                    OutputWriter.DisplayException(e.Message);
                }
            }
        }
    }
}
