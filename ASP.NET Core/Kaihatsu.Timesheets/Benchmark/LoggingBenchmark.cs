using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using Microsoft.Extensions.Logging;

namespace Benchmark
{
    [MemoryDiagnoser, ShortRunJob]
    public class LoggingBenchmark
    {
        public string Logging = "Loggint this string {0} {1}";
        public string args1 = "null";
        public string args2 = "simple";

        private readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(configure =>
            { configure.SetMinimumLevel(LogLevel.Information); });

        private readonly ILogger<LoggingBenchmark> _logger;
        private readonly ILoggerAdapter<LoggingBenchmark> _loggerAdapter;

        public LoggingBenchmark()
        {
            _logger = _loggerFactory.CreateLogger<LoggingBenchmark>();
            _loggerAdapter = new AdapterLogger<LoggingBenchmark>(_logger);
        }

        [Benchmark(Description = "BaseLogging")]
        public void BaseLogging()
        {
            _logger.LogInformation(Logging, args1, args2);
        }

        [Benchmark(Description = "LogLevelIsEnabled")]
        public void LogLevelIsEnabled()
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogInformation(Logging, args1, args2);
            }
        }

        [Benchmark(Description = "CallAdapterLogger")]
        public void AdapterLogger()
        {
            _loggerAdapter.Logging(Logging, args1, args2);
        }

        [Benchmark(Description = "CallAdapterLoggerStatic")]
        public void AdapterLoggerStatic()
        {
            AdapterLoggerStatic<LoggingBenchmark>.SetLogger(_logger);
            AdapterLoggerStatic<LoggingBenchmark>.Logging(Logging, args1, args2);
            //_loggerAdapter.Logging(Logging, args1, args2);
        }

        [Benchmark(Description = "MessageDefinition")]
        public void MessageDefinition()
        {
           _logger.LogMessage(args1, args2);
        }

        [Benchmark(Description = "MessageDefinitionGen")]
        public void MessageDefinitionGen()
        {
            _logger.LogDefenition(args1, args2);
        }
    }

    public class UnitTest1
    {
        public void TestMethod1()
        {
            BenchmarkRunner.Run<LoggingBenchmark>();
        }
    }
}
