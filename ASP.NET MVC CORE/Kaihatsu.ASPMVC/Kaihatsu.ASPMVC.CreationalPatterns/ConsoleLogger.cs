using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.CreationalPatterns;

// Одиночка + леницая инициализация
internal class ConsoleLogger: ILogger
{
    private static ConsoleLogger? _logger;
    private static readonly object _syncRoot = new object();
    // Создается экземпляр(выделяется память) при первом обращении к классу(вызывается статическое поле).
    // При рефлексии и typeof(ConsoleLogger)
    //public static ConsoleLogger Logger { get; } = new();
    // Ленивая инициализация
    //public static ConsoleLogger Logger => _logger ??= new();
    // TODO : Возвращать класс или интерфейс?
    public static ILogger Logger => _logger ??= new();
    
    // Ленивая загрузка
    private static Lazy<ConsoleLogger> _lazy = new Lazy<ConsoleLogger>(() => new(), false);
    public static ConsoleLogger LoggerLazy => _lazy.Value;

    // Многопоточная реализация
    public static ILogger LoggerThread    
    {
        get
        {
            if (_logger is not null)
                return _logger;

            lock (_syncRoot)
            {
                if (_logger is not null)
                    return _logger;

                _logger = new();
                return _logger;
            }

        }
    }

    private ConsoleLogger()
    {

    }

    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now:yyyy-MM-ddTHH:mm:ss.ff}][Console] {message}");
    }
}
