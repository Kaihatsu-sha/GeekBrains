using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Benchmark
{
    public class AdapterLogger<T> : ILoggerAdapter<T>
    {
        private readonly ILogger<T> _logger;
        public AdapterLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        public void Logging(string s1, params object?[] args)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(s1, args);
            }
        }
    }

    public static class AdapterLoggerStatic<T>// : ILoggerAdapter<T>
    {
        private static ILogger<T> _logger;
        public static void SetLogger(ILogger<T> logger)
        {
            _logger = logger;
        }

        public static void Logging(string s1, params object?[] args)
        {
            if (_logger.IsEnabled(LogLevel.Warning))
            {
                _logger.LogWarning(s1, args);
            }
        }
    }

    public interface ILoggerAdapter<T>
    {
        void Logging(string s1, params object?[] args);
    }
}
