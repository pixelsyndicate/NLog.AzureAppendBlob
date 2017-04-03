using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NLog;
using NLog.AzureAppendBlob;
using NLog.Web.Targets;

namespace AzureAppentBlob.UnitTests
{
    /// <summary>
    /// Summary description for UnitTest2
    /// </summary>
    [TestClass]
    public class UnitTest2
    {
        public UnitTest2()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;
        //When building a solution, .NET will not copy dependent assemblies unless they have been directly referenced in code. 
        //These 2 lines are currently only used to force .NET to copy NLog.Web and NLog.AzureAppendBlob to the main project's bin folder on a build
        private static NLog.AzureAppendBlob.AzureAppendBlobTarget dummyTarget;
        private static NLog.Web.Targets.AspNetTraceTarget webDummyTarget;


        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            dummyTarget = new AzureAppendBlobTarget();
            webDummyTarget = new AspNetTraceTarget();
        }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        [ClassCleanup()]
        public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void TestMethod1()
        {
            var testClass = new LogSomething();
            var testResult = testClass.HelloWorldLog();
            Assert.IsTrue(testResult == "Hello World");
        }

        [TestMethod]
        public void LogAll()
        {
            var _logger = LogManager.GetCurrentClassLogger();
            Assert.IsNotNull(_logger);
            _logger.Trace("Hello!");
            _logger.Debug("This is");
            _logger.Info("NLog using");
            _logger.Warn("Append blobs in");
            _logger.Error("Windows Azure");
            _logger.Fatal("Storage.");

            try
            {
                throw new NotSupportedException();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "This is an expected exception.");
            }
        }
    }
}
