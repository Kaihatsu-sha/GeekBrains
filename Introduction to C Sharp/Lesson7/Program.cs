using System;

namespace Lesson7
{
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();

            Console.ReadKey();
        }

        static void StartGame()
        {
            Game game = new Game(winCount: 3);
            AI pc = new AI(game);

            //PlayerVsPlayer(game);
            PlayerVsPC(game, pc);
        }

        static void PlayerVsPlayer(Game game)
        {
            Action<string> consoleWrite = delegate (string value) { Console.Write(value); };
            (string firstPlayer, string secondsPlayer) = CreateNewPlayers();

            do
            {
                (int x, int y) position;
                do
                {
                    Console.Clear();
                    game.PrintPlayingField(consoleWrite);
                    position = PlayerMove(firstPlayer);
                }
                while (!game.SetPlayerChip(position.x, position.y, 'X'));

                if (game.CheckingWin(position.x, position.y, 'X'))
                {
                    game.PrintPlayingField(consoleWrite);
                    Console.WriteLine($"Игрок: {firstPlayer} ВЫИГРАЛ!!!");
                    break;
                }

                do
                {
                    Console.Clear();
                    game.PrintPlayingField(consoleWrite);
                    position = PlayerMove(secondsPlayer);
                }
                while (!game.SetPlayerChip(position.x, position.y, 'O'));

                if (game.CheckingWin(position.x, position.y, 'O'))
                {
                    game.PrintPlayingField(consoleWrite);
                    Console.WriteLine($"Игрок: {secondsPlayer} ВЫИГРАЛ!!!");
                    break;
                }


            } while (game.CheckingNextStep());
        }

        static void PlayerVsPC(Game game, AI pc)
        {

            Action<string> consoleWrite = delegate (string value) { Console.Write(value); };

            Console.WriteLine("Добро пожаловать в игру Крестики Нолики!\nДля начала игры введите имя игрока.");
            Console.Write("Игрок за 'Х': ");
            string firstPlayer = Console.ReadLine();

            do
            {
                (int x, int y) position;
                do
                {
                    Console.Clear();
                    game.PrintPlayingField(consoleWrite);
                    position = PlayerMove(firstPlayer);
                }
                while (!game.SetPlayerChip(position.x, position.y, 'X'));

                if (game.CheckingWin(position.x, position.y, 'X'))
                {
                    game.PrintPlayingField(consoleWrite);
                    Console.WriteLine($"Игрок: {firstPlayer} ВЫИГРАЛ!!!");
                    break;
                }
                
                if (!game.CheckingNextStep())
                {
                    game.PrintPlayingField(consoleWrite);
                    Console.WriteLine($"НИЧЬЯ");
                    break;
                }

                do
                {
                    Console.Clear();
                    game.PrintPlayingField(consoleWrite);
                    Console.WriteLine($"Сейчас ход: {pc.Name}");
                    //position = pc.NextMove();//Случайные ходы
                    position = pc.NextMove(position.x, position.y, 'X');
                }
                while (!game.SetPlayerChip(position.x, position.y, 'O'));

                if (game.CheckingWin(position.x, position.y, 'O'))
                {
                    game.PrintPlayingField(consoleWrite);
                    Console.WriteLine($"Игрок: {pc.Name} ВЫИГРАЛ!!!");
                    break;
                }

                if (!game.CheckingNextStep())
                {
                    game.PrintPlayingField(consoleWrite);
                    Console.WriteLine($"НИЧЬЯ");
                    break;
                }

            } while (true);
        }

        static (string, string) CreateNewPlayers()
        {
            Console.WriteLine("Добро пожаловать в игру Крестики Нолики!\nДля начала игры введите имена игроков.");
            Console.Write("Игрок за 'Х': ");
            string firstPlayer = Console.ReadLine();

            Console.Write("Игрок за 'O': ");
            string secondsPlayer = Console.ReadLine();

            return (firstPlayer, secondsPlayer);
        }

        static (int x, int y) PlayerMove(string player)
        {
            int x;
            int y;

            Console.WriteLine($"Сейчас ход: {player}");
            do
            {
                Console.Write($"Введите номер строки: ");
            } while (!int.TryParse(Console.ReadLine(), out x));
            // Console.WriteLine(Environment.NewLine);

            do
            {
                Console.Write($"Введите номер столбца: ");
            } while (!int.TryParse(Console.ReadLine(), out y));
            //Console.WriteLine(Environment.NewLine);

            return (x - 1, y - 1);
        }
    }
}
