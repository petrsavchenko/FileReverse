using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileReverse.Test
{
    [TestClass]
    public class FileReverseManagerTests
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InputAndOutputFilesAreSet()
        {
            FileReverseManager.ReverseContent(null, null);
        }
    }
}
