using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaihatsu.ASPMVC.WPF;

internal static class Fibonacce
{
    private readonly static FibonacceCache _сache = new FibonacceCache();

    public static long GetNumber(int number)
    {
        if(number < 0)
        {
            throw new ArgumentOutOfRangeException("position");
        }

        long value = 0;
        if (_сache.TryGetValue(number, out value))
        {
            return value;
        }

        value = GetNumber(number - 1) + GetNumber(number - 2);
        _сache.AddValue(number, value);

        return value;
    }
}
