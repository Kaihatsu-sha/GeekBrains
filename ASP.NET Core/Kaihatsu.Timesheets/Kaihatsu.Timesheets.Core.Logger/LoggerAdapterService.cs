using Kaihatsu.Timesheets.Core.Abstraction.Services;
using Microsoft.Extensions.Logging;
using System;

namespace Kaihatsu.Timesheets.Core.Logger
{
    public sealed class LoggerAdapterService<T> : ILoggerService<T>
    {
        private readonly ILogger<T> _logger;
        public LoggerAdapterService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<T>();
        }

        public void LogCritical(string message, params object?[] args)
        {
            if (_logger.IsEnabled(LogLevel.Critical))
            {
                _logger.LogCritical(message, args);
            }
        }

        public void LogDebug(string message, params object?[] args)
        {
            if (_logger.IsEnabled(LogLevel.Debug))
            {
                _logger.LogDebug(message, args);
            }
        }

        public void LogError(string message, params object[] args)
        {
            if (_logger.IsEnabled(LogLevel.Error))
            {
                _logger.LogError(message, args);
            }
        }

        public void LogInformation(string message, params object[] args)
        {
            if (_logger.IsEnabled(LogLevel.Information))
            {
                _logger.LogInformation(message, args);
            }
        }

        public void LogTrace(string message, params object[] args)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
            {
                _logger.LogTrace(message, args);
            }
        }

        public void LogWarning(string message, params object[] args)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(message, args);
            }
        }
    }
}
