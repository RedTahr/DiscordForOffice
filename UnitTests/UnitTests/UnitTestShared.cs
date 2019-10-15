using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared;

namespace UnitTests
{
    [TestClass]
    public class UnitTestShared
    {
        [TestMethod]
        public void TestMethodGetVersion()
        {
            var version = Shared.Shared.getVersion();
            System.Diagnostics.Debug.WriteLine($"Version returned was {version}");
        }
    }
}
