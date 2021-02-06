using System;
using System.Collections.Generic;
using System.Text;

namespace FileReverse
{
    public static class FileReverseManager
    {
        public static void ReverseContent(string inputFilePath, string outputFilePath)
        {
            if (string.IsNullOrWhiteSpace(inputFilePath) || string.IsNullOrWhiteSpace(outputFilePath))
            {
                throw new ArgumentNullException("File paths must be set");
            }

            var lines = System.IO.File.ReadAllLines(inputFilePath);
            var outputLines = new List<string>();
            var stringBuilder = new StringBuilder();

            for (int i = lines.Length - 1; i >= 0; i--)
            {
                stringBuilder.Clear();
                for (int j = lines[i].Length - 1; j >= 0; j--)
                {
                    stringBuilder.Append(lines[i][j]);
                }
                outputLines.Add(stringBuilder.ToString());
            }

            System.IO.File.WriteAllLines(outputFilePath, outputLines);
        }
    }
}
