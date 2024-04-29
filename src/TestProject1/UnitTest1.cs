using System.Reflection.PortableExecutable;
using static System.Net.Mime.MediaTypeNames;

namespace TestProject1
{
    [TestClass]
    public class UnitTest1
    {
        private static void TestRead(string[][] correctData, string[][] data)
        {
            Assert.AreEqual(correctData.Length, data?.Length);
            foreach (var line in correctData.Index())
                Assert.IsTrue(Enumerable.SequenceEqual(line.Item, data?.ElementAt(line.Index)!));
        }

        private static void TestRead(string[] correctHeader, string[][] correctData, string[] header, string[][] data)
        {
            Assert.IsTrue(Enumerable.SequenceEqual(correctHeader, header));
            TestRead(correctData, data);
        }



        [TestMethod]
        public void TestMethod1()
        {
            var csvString = "a,b,c\n1,2,3\n4,5,6\n";

            var correctHeader = new[] { "a", "b", "c" };
            var correctData = new[] { new[] { "1", "2", "3" }, new[] { "4", "5", "6" } };

            var (header, data) = CsvParser.CsvReader.ReadHeaderAndData(csvString);

            TestRead(correctHeader, correctData, header, data);
        }

        [TestMethod]
        public void TestMethod2()
        {
            var csvString = "a,b,\"c\"\"d\"\n'1''0',2,3\n4,5,\"6\n7\"\n";

            var correctHeader = new[] { "a", "b", "c\"d" };
            var correctData = new[] { new[] { "1'0", "2", "3" }, new[] { "4", "5", "6\n7" } };

            var (header, data) = CsvParser.CsvReader.ReadHeaderAndData(csvString);

            TestRead(correctHeader, correctData, header, data);
        }

        [TestMethod]
        public void TestWriteMethod1()
        {
            var correctString = "a,b,c\n1,2,3\n4,5,6\n";

            var header = new[] { "a", "b", "c" };
            var data = new[] { new[] { "1", "2", "3" }, new[] { "4", "5", "6" } };

            var csvString = CsvParser.CsvWriter.Write(header, data);

            Assert.AreEqual(correctString, csvString);
        }

        [TestMethod]
        public void TestWriteMethod2()
        {
            var correctString = "a,b,\"c\"\"d\"\n\"1'0'\",2,3\n4,5,\"6\n7\"\n";

            var header = new[] { "a", "b", "c\"d" };
            var data = new[] { new[] { "1'0'", "2", "3" }, new[] { "4", "5", "6\n7" } };

            var csvString = CsvParser.CsvWriter.Write(header, data);

            Assert.AreEqual(correctString, csvString);
        }
    }
}
