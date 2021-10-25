using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class LCS
    {
        public int GetLength(string lineA, string lineB)
        {
            if (lineA.Length == 0 || lineB.Length == 0)
            {
                return 0;
            }
            if (lineA[0] == lineB[0])
            {
                return 1 + GetLength(lineA.Substring(1), lineB.Substring(1));
            }
            else
            {
               return Math.Max(GetLength(lineA, lineB.Substring(1)), GetLength(lineA.Substring(1), lineB));
            }
        }
    }
}
