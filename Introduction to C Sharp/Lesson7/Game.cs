using System;

namespace Lesson7
{
    public class Game
    {
        readonly int _sizeX;
        readonly int _sizeY;
        readonly int _winCount;
        readonly char _chipEmpty;
        char[,] _playingField;
        int _stepsCount;

        public Game(int sizeX = 3, int sizeY = 3, int winCount = 3)
        {
            //провека на достижимость победы.
            _sizeX = sizeX;
            _sizeY = sizeY;
            _winCount = winCount;
            _chipEmpty = ' ';
            _playingField = new char[_sizeX, _sizeY];
            _stepsCount = (_winCount * 2) - 1;

            InitializePlayingField();
        }

        public int WinCount { get { return _winCount; } }

        public char ChipEmpty { get { return _chipEmpty; } }

        public int SizeX { get { return _sizeX; } }

        public int SizeY { get { return _sizeY; } }

        public char[,] PlayingField { get { return _playingField; } }

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
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    if (_playingField[i, j].Equals(_chipEmpty))
                    {
                        return true;
                    }
                }
            }           

            return false;
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
