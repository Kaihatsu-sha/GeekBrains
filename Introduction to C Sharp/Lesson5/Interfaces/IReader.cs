using System.Collections.Generic;

namespace Lesson5.Interfaces
{
    interface IReader<T>
    {
        List<T> Read();
    }
}
