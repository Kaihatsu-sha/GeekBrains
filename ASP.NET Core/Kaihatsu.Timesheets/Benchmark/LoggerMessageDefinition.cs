//using BenchmarkDotNet.Loggers;
//using Microsoft.Extensions.Logging;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Benchmark
//{
//    public static class LoggerMessageDefinition
//    {
//        private static readonly Action<Microsoft.Extensions.Logging.ILogger, string, string, Exception?> ActionLoggerMessageDefinition =
//        LoggerMessage.Define<string, string>(LogLevel.Information, 0, "LoggerMessage {0} {1}");

//        public static void LogMessage(this Microsoft.Extensions.Logging.ILogger logger, string s1, string s2)
//        {
//            ActionLoggerMessageDefinition(logger, s1, s2, null);
//        }
//    }

//    public static partial class LoggerMessageDefinitionGen
//    {
//        [LoggerMessage(EventId = 0, Level = LogLevel.Information,
//        Message = "LoggerMessage {args}")]
//        public static partial void LogDefenition(this Microsoft.Extensions.Logging.ILogger logger, params object?[] args);   
//    }
//}
