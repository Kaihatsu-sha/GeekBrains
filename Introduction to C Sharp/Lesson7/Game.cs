using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson7
{
    public class Game
    {
        readonly int _sizeX;
        readonly int _sizeY;
        readonly int _winCount;
        readonly char _chipEmpty;
        readonly char _chipX;
        readonly char _chipO;
        char[,] _playingField;
        int _stepsCount;

        public Game(int sizeX = 3, int sizeY = 3, int winCount = 3)
        {
            //провека на достижимость победы.
            _sizeX = sizeX;
            _sizeY = sizeY;
            _winCount = winCount;
            _chipEmpty = ' ';
            _chipX = 'X';
            _chipO = 'O';
            _playingField = new char[_sizeX, _sizeY];
            _stepsCount = (_winCount * 2) - 1;

            InitializePlayingField();
        }

        public void PrintPlayingField(Action<string> action)
        {
            for (int i = 0; i < _sizeX; i++)
            {
                action?.Invoke("|");
                for (int j = 0; j < _sizeY; j++)
                {
                    action?.Invoke($"{_playingField[i, j]} |");
                }
                action?.Invoke(Environment.NewLine);
            }
        }

        public bool SetPlayerChip(int x, int y, char chip)
        {
            if (CheckingField(x, y))
            {
                _playingField[x, y] = chip;
                _stepsCount--;
                return true;
            }

            return false;
        }

        public bool CheckingNextStep()
        {
            if (_stepsCount == 0)
            {
                return false;
            }

            return true;
        }

        public bool CheckingWin(int x, int y, char chip)
        {
            if (_stepsCount > 0)
            {
                return false;
            }

            if (CheckingElements(x, y, chip, 1, 0) || CheckingElements(x, y, chip, -1, 0))//Столбцы
            {
                return true;
            }

            if (CheckingElements(x, y, chip, 0, 1) || CheckingElements(x, y, chip, 0, -1))//Строки
            {
                return true;
            }

            if (CheckingElements(x, y, chip, 1, 1) || CheckingElements(x, y, chip, -1, -1))//45
            {
                return true;
            }

            if (CheckingElements(x, y, chip, 1, -1) || CheckingElements(x, y, chip, -1, 1))//135
            {
                return true;
            }

            //if (CheckingHorizontal(x, y, chip) || CheckingVertical(x, y, chip) || CheckingDiagonal(x, y, chip))
            //{
            //    return true;
            //}

            return false;
        }


        private bool CheckingHorizontal(int x, int y, char chip)
        {
            if (y == 0)//Основание
            {
                return CheckingHorizontalElements(x, y, chip);
            }
            if (y == _sizeY - 1)//Вершина
            {
                return CheckingHorizontalElements(x, y, chip, -1);
            }
            if (y + _winCount <= _sizeY)//.<-
            {
                int i = 0;
                i = y + _winCount;
                if (i == _sizeY)
                {
                    i--;
                }
                return CheckingHorizontalElements(x, i, chip, -1);
            }
            else//->. 
            {
                int i = 0;
                i = y - _winCount + 1;
                if (i < 0)
                {
                    i = 0;
                }

                return CheckingHorizontalElements(x, i, chip);
            }
        }

        private bool CheckingHorizontalElements(int x, int startIndex, char chip, int direction = 1)
        {
            int winCount = 0;
            int iteration = _winCount * 2;
            do
            {
                if (_playingField[x, startIndex].Equals(chip))
                {
                    winCount++;
                }
                startIndex = startIndex + (1 * direction);
                iteration--;

            } while (winCount != _winCount && iteration != 0 && startIndex >= 0 && startIndex < _sizeY);

            if (winCount == _winCount)
            {
                return true;
            }

            return false;
        }

        private bool CheckingElements(int x, int y, char chip, int i, int j)
        {
            int winCount = 0;

            while (_playingField[x, y].Equals(chip))
            {
                winCount++;
                x += i;
                y += j;

                if (winCount == _winCount)
                {
                    break;
                }

                if (x >= _sizeX || y >= _sizeY)
                {
                    break;
                }

                if (x < 0 || y < 0)
                {
                    break;
                }
            };

            if (winCount == _winCount)
            {
                return true;
            }

            return false;
        }
        private bool CheckingVertical(int x, int y, char chip)
        {
            if (x == 0)//Основание
            {
                return CheckingVerticalElements(x, y, chip);
            }
            if (x == _sizeX - 1)//Вершина
            {
                return CheckingVerticalElements(x, y, chip, -1);
            }
            if (x + _winCount <= _sizeX)//.<-
            {
                int i = 0;
                i = x + _winCount;
                if (i == _sizeX)
                {
                    i--;
                }
                return CheckingVerticalElements(i, y, chip, -1);
            }
            else//->.
            {
                int i = 0;
                i = x - _winCount + 1;
                if (i < 0)
                {
                    i = 0;
                }

                return CheckingVerticalElements(i, y, chip);
            }
        }

        private bool CheckingVerticalElements(int startIndex, int y, char chip, int direction = 1)
        {
            int winCount = 0;
            int iteration = _winCount * 2;
            do
            {
                if (_playingField[startIndex, y].Equals(chip))
                {
                    winCount++;
                }
                startIndex = startIndex + (1 * direction);
                iteration--;

            } while (winCount != _winCount && iteration != 0 && startIndex >= 0 && startIndex < _sizeX);

            if (winCount == _winCount)
            {
                return true;
            }

            return false;
        }

        private bool CheckingDiagonal(int x, int y, char chip)
        {
            int i = x;
            int directionI = 1;
            if (x == 0)
            {
                i = 0;
            }
            else if (x == (_sizeX - 1))
            {
                i = _sizeX - 1;
                directionI = -1;
            }

            int j = y;
            int directionJ = 1;
            if (y == 0)
            {
                j = 0;
                return CheckingDiagonalElements(i, j, chip, directionI, directionJ);
            }
            else if (y == (_sizeY - 1))
            {
                j = _sizeY - 1;
                directionJ = -1;
                return CheckingDiagonalElements(i, j, chip, directionI, directionJ);
            }

            if ((_sizeX - x) >= _winCount)//
            {

            }
            //if (y + _winCount <= _sizeY)//Вправо
            //{
            //    if (i + _winCount <= _sizeX)//Вниз
            //    {
            //        j = _sizeY - 1;
            //        i = _sizeX - 1;
            //        return CheckingDiagonalElements(i, j, chip, 1, 1);
            //    }
            //    else//Вверх
            //    {

            //    }
            //}
            //else//Влево
            //{
            //    if (i + _winCount <= _sizeX)//Вниз
            //    {

            //    }
            //    else//Вверх
            //    {

            //    }
            //}

            return CheckingDiagonalElements(i, j, chip, directionI, directionJ);
        }

        //private (int, int) GetStartIndex(int x, int y)
        //{
        //    if (x == 0 || y == 0 || x == (_sizeX - 1) || y == (_sizeY - 1))
        //    {
        //        return (x, y);
        //    }


        //}

        private bool CheckingDiagonalElements(int startI, int startJ, char chip, int directionI, int directionJ)
        {
            int winCount = 0;
            int iteration = _winCount * 2;
            do
            {
                if (_playingField[startI, startJ].Equals(chip))
                {
                    winCount++;
                }
                startI = startI + (1 * directionI);
                startJ = startJ + (1 * directionJ);
                iteration--;

            } while (winCount != _winCount && iteration != 0
                    && startI >= 0 && startI < _sizeX
                    && startJ >= 0 && startJ < _sizeY);

            if (winCount == _winCount)
            {
                return true;
            }

            return false;
        }

        private void InitializePlayingField()
        {
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    _playingField[i, j] = _chipEmpty;
                }
            }
        }

        private bool CheckingField(int x, int y)
        {
            if (x > _sizeX - 1 || y > _sizeY - 1)
            {
                return false;
            }

            if (x < 0 || y < 0)
            {
                return false;
            }
            return _playingField[x, y].Equals(_chipEmpty);
        }
    }
}
