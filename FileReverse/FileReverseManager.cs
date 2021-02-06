using System;
using System.Collections.Generic;
using System.Text;

namespace FileReverse
{
    public static class FileReverseManager
    {
        public static bool ReverseContent(string inputFilePath, string outputFilePath)
        {
            if (string.IsNullOrWhiteSpace(inputFilePath) || string.IsNullOrWhiteSpace(outputFilePath))
            {
                throw new ArgumentNullException("File paths must be set");
            }

            var lines = System.IO.File.ReadAllLines(inputFilePath);
            System.IO.File.WriteAllLines(outputFilePath, lines);

            return false;
        }
    }
}
