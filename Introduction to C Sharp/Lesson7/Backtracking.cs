using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class Backtracking
    {
        readonly int _sizeX;
        readonly int _sizeY;
        private int[,] chessboard;
        public Backtracking(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            chessboard = new int[sizeX, sizeY];
        }

        public bool SearchSolutioin(int n)
        {
            if (!CheckBoard())
            {
                return false;
            }

            if (n == 9)
            {
                return true;
            }

            for (int row = 0; row < _sizeX; row++)
            {
                for (int col = 0; col < _sizeY; col++)
                {
                    if (chessboard[row, col] == 0)
                    {
                        chessboard[row, col] = n;

                        if (!SearchSolutioin(n + 1))
                        {
                            return false;
                        }
                        chessboard[row, col] = 0;
                    }
                }
            }

            return false;
        }

        private bool CheckBoard()
        {
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    if (chessboard[i, j] != 0)
                    {
                        if (!CheckQueen(i, j))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }

        private bool CheckQueen(int x, int y)
        {
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    if (chessboard[i, j] != 0)
                    {
                        if (!(i == x && j == y))
                        {
                            if ((i - x) == 0 || (j - y) == 0)
                            {
                                return false;
                            }

                            if (Math.Abs(i - x) == Math.Abs(j - y))
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            return true;
        }
    }
}
