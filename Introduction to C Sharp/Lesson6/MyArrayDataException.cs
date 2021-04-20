using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson6
{
    [Serializable]
    class MyArrayDataException : Exception
    {
        public MyArrayDataException(string message): base (message)
        {
        }
    }
}
