using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using NLog.AzureAppendBlob;
using NLog.Web.Targets;

namespace AzureAppentBlob.UnitTests
{
    public class LogSomething
    {
        public LogSomething()
        {
            _logger = LogManager.GetCurrentClassLogger();
            dummyTarget = new AzureAppendBlobTarget();
            webDummyTarget = new AspNetTraceTarget();
        }
        private readonly Logger _logger;

        //When building a solution, .NET will not copy dependent assemblies unless they have been directly referenced in code. 
        //These 2 lines are currently only used to force .NET to copy NLog.Web and NLog.AzureAppendBlob to the main project's bin folder on a build
        private NLog.AzureAppendBlob.AzureAppendBlobTarget dummyTarget;
        private NLog.Web.Targets.AspNetTraceTarget webDummyTarget;


        public string HelloWorldLog()
        {
            string testString = "Hello World";
            _logger.Debug(testString);
            return testString;
        }

        public void LogAll()
        {
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
