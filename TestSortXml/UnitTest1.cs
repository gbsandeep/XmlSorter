using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortXml.Sort;
using System.Xml;
using System.Xml.Linq;
using SortXml.Log;

namespace TestSortXml {
    [TestClass]
    public class TestSort {
        [TestMethod]
        public void SingleNode() {
            var sorter = new Sorter(new LogStub());
            var inputXml = "<a d=\"e\" b=\"c\"></a>";
            Assert.AreEqual("<a b=\"c\" d=\"e\"></a>", sorter.SortXml(inputXml));
        }

        [TestMethod]
        public void TwoLevel() {
            var sorter = new Sorter(new LogStub());
            var expected = XDocument.Parse("<n0_0 a0=\"c\" a1=\"e\"><n0_1 a0=\"f\" a1=\"e\" /><n0_2 a0=\"f\" a1=\"e\" /></n0_0>");
            var input = XDocument.Parse("<n0_0 a1=\"e\" a0=\"c\"><n0_2 a1=\"e\" a0=\"f\" /><n0_1 a1=\"e\" a0=\"f\" /></n0_0>");
            Assert.AreEqual(expected.ToString(), sorter.SortXml(input.ToString()));
        }
        
        [TestMethod]
        public void SingleNodeNoAttributes() {
            var sorter = new Sorter(new LogStub());
            var expected = XDocument.Parse("<n0_0/>");
            var input = XDocument.Parse("<n0_0/>");
            Assert.AreEqual(expected.ToString(), sorter.SortXml(input.ToString()));
        }

    }

    [TestClass]
    class TestInput {
        
    }

    class LogStub : ILog {
        public void Warn(string message) {
        }

        public void Error(Exception ex) {
        }

        public void Info(string message) {
        }

        public void Log(string message) {
        }

        public Level LogLevel {get; set;}
    }
}
