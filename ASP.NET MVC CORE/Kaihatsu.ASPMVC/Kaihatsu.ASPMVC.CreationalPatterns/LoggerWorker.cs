using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.CreationalPatterns;

internal class LoggerWorker
{

    public LoggerWorker(ILoggerFactory loggerFactory, IEnumerable<string> messages)
    {
        ILogger logger = loggerFactory.Create();
        //messages.ToList().ForEach(messag => logger.Log(messag));
        messages.ForEach(messag => logger.Log(messag));
    }
}

public static class EnumerableExtension
{
    public static void ForEach<T>(this IEnumerable<T> enumeration, Action<T> action)
    {
        foreach (T item in enumeration)
        {
            action?.Invoke(item);
        }
    }
}