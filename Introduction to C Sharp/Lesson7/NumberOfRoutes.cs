using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class NumberOfRoutes
    {
        public int CountingNumberOfRoutes(int numberOfRows = 5, int numberOfColumns = 5)
        {
            if (numberOfRows == 0 || numberOfColumns == 0)
            {
                throw new ArgumentException();
            }

            if (numberOfRows == 1 && numberOfColumns == 1)
            {
                return 0;
            }

            int[,] chessboard = new int[numberOfRows, numberOfColumns];

            for (int j = 0; j < numberOfRows; j++)
            {
                chessboard[0, j] = 1;
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                chessboard[i, 0] = 1;
            }

            for (int i = 1; i < numberOfRows; i++)
            {
                for (int j = 1; j < numberOfColumns; j++)
                {
                    chessboard[i, j] = chessboard[i, j - 1] + chessboard[i - 1, j];
                }
            }
            return chessboard[numberOfRows-1, numberOfColumns-1];
        }

        public int CountingNumberOfRoutesWithObstacles(int[,] mapOfObstacles,int numberOfRows = 5, int numberOfColumns = 5)
        {
            int[,] chessboard = new int[numberOfRows, numberOfColumns];

            for (int j = 0; j < numberOfColumns; j++)
            {
                chessboard[0, j] = 1;
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                chessboard[i, 0] = 1;
            }

            for (int i = 1; i < numberOfRows; i++)
            {
                for (int j = 1; j < numberOfColumns; j++)
                {
                    if (mapOfObstacles[i, j] != 0)
                    {
                        chessboard[i, j] = chessboard[i, j - 1] + chessboard[i - 1, j];
                    }
                    else
                    {
                        chessboard[i, j] = 0;
                    }
                }
            }

            return chessboard[numberOfRows - 1, numberOfColumns - 1];
        }
    }
}
