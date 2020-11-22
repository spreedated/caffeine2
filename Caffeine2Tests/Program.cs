using NUnit.Framework;
using System;
using WindowsInput.Native;

namespace Caffeine2Tests
{
    [TestFixture]
    public class Program
    {
        [Test]
        public void Arguments()
        {

            Caffeine2.CLI_Args acc = new Caffeine2.CLI_Args();

            acc.ParseArgs(new string[] { });
            Assert.IsFalse(acc.Arguments.Startoff);
            Assert.IsNull(acc.Arguments.KeyToPress);
            Assert.IsNull(acc.Arguments.IntervalArgument);

            string[] args = new string[] { 
                "--startoff"
            };
            acc.ParseArgs(args);
            Assert.IsTrue(acc.Arguments.Startoff);
            Assert.IsNull(acc.Arguments.KeyToPress);
            Assert.IsNull(acc.Arguments.IntervalArgument);

            args = new string[] {
                "-s"
            };
            acc.ParseArgs(args);
            Assert.IsTrue(acc.Arguments.Startoff);
            Assert.IsNull(acc.Arguments.KeyToPress);
            Assert.IsNull(acc.Arguments.IntervalArgument);

            args = new string[] {
                "-k",
                "F24"
            };
            acc.ParseArgs(args);
            Assert.IsFalse(acc.Arguments.Startoff);
            Assert.AreEqual(VirtualKeyCode.F24,acc.Arguments.KeyToPress);
            Assert.IsNull(acc.Arguments.IntervalArgument);

            args = new string[] {
                "--key",
                "f15"
            };
            acc.ParseArgs(args);
            Assert.IsFalse(acc.Arguments.Startoff);
            Assert.AreEqual(VirtualKeyCode.F15, acc.Arguments.KeyToPress);
            Assert.IsNull(acc.Arguments.IntervalArgument);

            args = new string[] {
                "-i",
                "1526"
            };
            acc.ParseArgs(args);
            Assert.IsFalse(acc.Arguments.Startoff);
            Assert.IsNull(acc.Arguments.KeyToPress);
            Assert.AreEqual(new TimeSpan(0,25,26), acc.Arguments.Interval);

            args = new string[] {
                "--interval",
                "215"
            };
            acc.ParseArgs(args);
            Assert.IsFalse(acc.Arguments.Startoff);
            Assert.IsNull(acc.Arguments.KeyToPress);
            Assert.AreEqual(new TimeSpan(0, 3, 35), acc.Arguments.Interval);

            args = new string[] {
                "--interval",
                "215",
                "-s",
                "-k f2"
            };
            acc.ParseArgs(args);
            Assert.IsTrue(acc.Arguments.Startoff);
            Assert.AreEqual(VirtualKeyCode.F2, acc.Arguments.KeyToPress);
            Assert.AreEqual(new TimeSpan(0, 3, 35), acc.Arguments.Interval);

            args = new string[] {
                "-i dds"
            };
            acc.ParseArgs(args);
            Assert.IsFalse(acc.Arguments.Startoff);
            Assert.IsNull(acc.Arguments.KeyToPress);
            Assert.IsNull(acc.Arguments.IntervalArgument);
        }
    }
}
