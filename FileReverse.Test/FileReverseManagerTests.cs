using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReverse.Test
{
    [TestClass]
    public class FileReverseManagerTests
    {
        private readonly string _inputFilePath;
        private readonly string _outputFilePath;

        public FileReverseManagerTests()
        {
            _inputFilePath = $"{Directory.GetCurrentDirectory()}\\input.txt";
            _outputFilePath = $"{Directory.GetCurrentDirectory()}\\output.txt";
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void InputAndOutputFilesAreNullNegative()
        {
            FileReverseManager.ReverseContent(null, null);
        }

        [TestMethod]
        public void InputAndOutputFilesAreEmptyNegative()
        {
            Assert.ThrowsException<ArgumentNullException>(() => FileReverseManager.ReverseContent("", "     "), "File paths must be set");
        }

        [TestMethod]
        [ExpectedException(typeof(DirectoryNotFoundException))]
        public void InputFileCannotBeFoundNegative()
        {
            FileReverseManager.ReverseContent(@"F:\Users\Public\TestFolder\pathDontExistInputTest.txt", _outputFilePath);
        }

        [TestMethod]
        public void EmptyInputFileGeneratesEmptyOutput()
        {
            FileReverseManager.ReverseContent($"{Directory.GetCurrentDirectory()}\\emptyInput.txt", _outputFilePath);
            Assert.IsTrue(File.Exists(_outputFilePath));

            var lines = File.ReadAllLines(_outputFilePath);
            Assert.AreEqual(lines.Length, 0);
        }

        [TestMethod]
        public void LastLineOfInputReversedAndCorrectlyPositioned()
        {
            FileReverseManager.ReverseContent(_inputFilePath, _outputFilePath);
            var outputLines = File.ReadAllLines(_outputFilePath);

            Assert.AreEqual(outputLines[0], "xyz");
        }

        [TestMethod]
        public void SecondLastLineOfInputReversedAndCorrectlyPositioned()
        {
            FileReverseManager.ReverseContent(_inputFilePath, _outputFilePath);
            var outputLines = File.ReadAllLines(_outputFilePath);

            Assert.AreEqual(outputLines[1], "ihg");
        }

        [TestMethod]
        public void FirstLiseOfInputReversedAndPlacedToBeLastInOutput()
        {
            FileReverseManager.ReverseContent(_inputFilePath, _outputFilePath);
            var outputLines = File.ReadAllLines(_outputFilePath);

            Assert.AreEqual(outputLines[3], "cba");
        }
    }
}
