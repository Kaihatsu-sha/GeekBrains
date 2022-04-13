using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.CreationalPatterns;

// Фабричный метод + пул объектов
internal class FileLogger: ILogger
{
    private readonly string _path;
    // Пул объектов
    private static readonly ConcurrentDictionary<string, FileLogger> _pool = new();

    // Фабричный метод
    public static FileLogger Create(string path)
    {
        return _pool.GetOrAdd(path, path => new(path));
    }
    
    //public FileLogger(string path) => _path = path;
    private FileLogger(string path) => _path = path;

    [MethodImpl(MethodImplOptions.Synchronized)]// Блокировка потока на уровне вызова метода
    public void Log(string message)
    {
        File.AppendAllText(_path, $"[{DateTime.Now:yyyy-MM-ddTHH:mm:ss.ff}][File] {message}");
    }
}
