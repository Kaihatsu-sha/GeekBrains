using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Microsoft.Extensions.Logging;
using System;

namespace Kaihatsu.Timesheets.Core.Logger
{
    public sealed class LoggerService<T> : ILoggerService<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerService(ILogger<T> logger) 
        { 
            _logger = logger;
        }

        public void LogTrace(string message)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace(message);
            }
        }

        public void LogTrace<T0>(string message, T0 arg0)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace(message, arg0);
            }
        }
    }
}
