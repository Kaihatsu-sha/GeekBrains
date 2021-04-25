using System;
using System.Collections.Generic;

namespace Lesson7
{
    public class AI
    {
        readonly Game _game;
        readonly Random _random;
        string _name;

        public AI(Game game, string name = "T-80")
        {
            _game = game;
            _random = new Random();
            _name = name;
        }

        public (int, int) NextMove()
        {
            return (_random.Next(0, _game.SizeX), _random.Next(0, _game.SizeY));
        }

        public (int, int) NextMove(int x, int y, char chip)
        {
            List<Priority> priorities = new List<Priority>();
            (int, int) rezult = (0, 0);

            if (_game.WinCount >= 3)
            {
                priorities.Add(new Priority(CheckingElements(x, y, chip, 1, 0), 1, 0));//Столбцы
                priorities.Add(new Priority(CheckingElements(x, y, chip, -1, 0), -1, 0));

                priorities.Add(new Priority(CheckingElements(x, y, chip, 0, 1), 0, 1));//Строки
                priorities.Add(new Priority(CheckingElements(x, y, chip, 0, -1), 0, -1));

                priorities.Add(new Priority(CheckingElements(x, y, chip, 1, 1), 1, 1));//45
                priorities.Add(new Priority(CheckingElements(x, y, chip, -1, -1), -1, -1));

                priorities.Add(new Priority(CheckingElements(x, y, chip, 1, -1), 1, -1));//135
                priorities.Add(new Priority(CheckingElements(x, y, chip, -1, 1), -1, 1));

                int value = 0;
                foreach (Priority item in priorities)
                {
                    if (item.Value > value)
                    {
                        if (CheckingField(x + item.I, y + item.J))
                        {
                            rezult = (x + item.I, y + item.J);
                            value = item.Value;
                        }
                        else if (CheckingField(x + (item.I * -1), y + (item.J * -1)))
                        {
                            rezult = (x + (item.I * -1), y + (item.J * -1));
                            value = item.Value;
                        }
                    }
                }

                return rezult;
            }
            else
            {
                return NextMove();
            }
        }

        public string Name { get { return _name; } }

        private int CheckingElements(int x, int y, char chip, int i, int j)
        {
            int winCount = 0;

            while (_game.PlayingField[x, y].Equals(chip))
            {
                winCount++;
                x += i;
                y += j;

                if (winCount == _game.WinCount)
                {
                    break;
                }

                if (x >= _game.SizeX || y >= _game.SizeY)
                {
                    break;
                }

                if (x < 0 || y < 0)
                {
                    break;
                }
            };
            return winCount;
        }

        private bool CheckingField(int x, int y)
        {
            if (x > _game.SizeX - 1 || y > _game.SizeY - 1)
            {
                return false;
            }

            if (x < 0 || y < 0)
            {
                return false;
            }
            return _game.PlayingField[x, y].Equals(_game.ChipEmpty);
        }
    }

    class Priority
    {
        public Priority(int value, int i, int j)
        {
            Value = value;
            I = i;
            J = j;
        }

        public int Value { get; }

        public int I { get; }

        public int J { get; }
    }
}
