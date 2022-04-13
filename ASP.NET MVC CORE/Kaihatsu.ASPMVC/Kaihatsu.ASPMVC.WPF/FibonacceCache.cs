using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.WPF;

internal class FibonacceCache
{
    private readonly Dictionary<int, long> _cache = new Dictionary<int, long>();

    public FibonacceCache() 
    {
        _cache.Add(0, 0);
        _cache.Add(1, 1);
        _cache.Add(2, 1);
    }

    public bool TryGetValue(int key, out long value)
    {
        return _cache.TryGetValue(key, out value);
    }
    public void AddValue(int key, long value)
    {
        _cache.Add(key, value);
    }
}
