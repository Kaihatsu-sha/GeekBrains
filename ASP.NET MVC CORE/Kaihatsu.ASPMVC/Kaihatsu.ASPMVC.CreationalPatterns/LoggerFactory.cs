using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.CreationalPatterns;

/// Фабрика
internal class LoggerFactory : ILoggerFactory
{
    public enum LoggerType
    {
        Console,
        File
    }

    public LoggerType Type { get; set; }

    //public ILogger Create()
    //{
    //    switch (Type)
    //    {
    //        default: throw new InvalidEnumArgumentException(nameof(Type),(int)Type , typeof(LoggerType));
    //        case LoggerType.Console: return ConsoleLogger.LoggerLazy;
    //        case LoggerType.File: return FileLogger.Create("LoggerFactory.txt");
    //    }
    //}

    //public ILogger Create()
    //{
    //    return Type switch
    //    {
    //        LoggerType.Console => ConsoleLogger.Logger,
    //        LoggerType.File => FileLogger.Create("FileLogger.txt"),
    //        _ => throw new InvalidEnumArgumentException(nameof(Type), (int)Type, typeof(LoggerType))
    //    };
    //}

    public ILogger Create() => Type switch
    {
        LoggerType.Console => ConsoleLogger.Logger,
        LoggerType.File => FileLogger.Create("FileLogger.txt"),
        _ => throw new InvalidEnumArgumentException(nameof(Type), (int)Type, typeof(LoggerType))
    };
}
