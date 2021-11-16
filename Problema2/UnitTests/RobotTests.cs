using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Tests
{
    [TestClass()]
    public class RobotTests
    {
        [TestMethod()]
        public void GetLastLoopTest_FirstInput()
        {
            Robot robot = new();

            Assert.AreEqual("RRDDDLLUUU", robot.GetLastLoop("RRRRDDDLLUUUUUUURRDDDDR"));
        }
        
        [TestMethod()]
        public void GetLastLoopTest_EmptyInput()
        {
            Robot robot = new();

            Assert.AreEqual("No Loop", robot.GetLastLoop(""));
        }
        
        [TestMethod()]
        public void GetLastLoopTest_NullInput()
        {
            Robot robot = new();

            Assert.AreEqual("No Loop", robot.GetLastLoop(null));
        }
    }
}