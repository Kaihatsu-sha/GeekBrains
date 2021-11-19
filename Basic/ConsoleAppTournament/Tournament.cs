using GameClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTournament
{
    internal class Tournament
    {
        private List<Character> Participants = new List<Character>();
        public void Start()
        {
            OutToConsole("Рассказчик", "Начинаем наш турнир!");
            CreatingParticipants();
            while (Participants.Count > 1)
            {
                (Character p1, Character p2) = Drawing();

                OutToConsole("Рассказчик", $"Смельчаки выходят: {p1.Name} и {p2.Name}");
                while (!p1.IsDead && !p2.IsDead)
                {
                    p1.Attack(p2);
                    p2.Attack(p1);
                    p1.NewRound();
                    p2.NewRound();
                }

                if (p1.IsDead)
                {
                    p2.Restore();
                    Participants.Add(p2);
                }
                else
                {
                    p1.Restore();
                    Participants.Add(p1);
                }
            }
            OutToConsole("Рассказчик", $"Победитель: {Participants[0].Name}");
            Console.ReadKey();
        }

        private void CreatingParticipants()
        {
            Participants.AddRange(new List<Character>{
                new Character("Сир Лора")
                { 
                    RightHand = new SingleHandedWeapons("Душитель",8,13,10,10) ,
                    LeftHand = new SingleHandedWeapons("Пожиратель плоти",8,13,10,10) ,
                    Chest = new LeatherArmor("Змеиная кожа", 30),
                    Notify = OutToConsole
                },
                new Character("Королевский палач")
                { 
                    RightHand = new TwoHandedWeapons("Топор палача",14,15,10,10) ,
                    Chest = new LightArmor("Роба палача", 10),
                    Notify = OutToConsole 
                },
                new Character("Укротитель зверей Нэсс")
                { 
                    RightHand = new TwoHandedWeapons("Пленитель",10,15,20,0) ,
                    Chest = new LeatherArmor("Покров зверя", 30),
                    Notify = OutToConsole 
                },
                new Character("Продавец мяса")
                {
                    RightHand = new SingleHandedWeapons("Разделитель",3,5,50,5) ,
                    LeftHand = new SingleHandedWeapons("Разрубатель",10,10,0,20) ,
                    Chest = new LightArmor("Фартук мясника", 10),
                    Notify = OutToConsole
                },
                new Character("Разбойник")
                {
                    RightHand = new SingleHandedWeapons("Кинжал",7,10,15,15) ,
                    LeftHand = new SingleHandedWeapons("Кинжал",7,10,15,15) ,
                    Chest = new LeatherArmor("Кожанная броня", 10),
                    Notify = OutToConsole
                },
                new Character("МариКрим Де Франс")
                {
                    RightHand = new TwoHandedWeapons("Воздаяние",15,25,0,0) ,
                    Chest = new HeavyArmor("Бастион", 50),
                    Notify = OutToConsole
                },
                new Character("Оходник Робин")
                {
                    RightHand = new TwoHandedWeapons("Пронзатель",18,18,0,10) ,
                    Chest = new LeatherArmor("Туника бойца", 25),
                    Notify = OutToConsole
                },
                new Character("Счастливчик Джо")
                {
                    RightHand = new SingleHandedWeapons("Смеющийся Джокер",1,99,99,-60) ,
                    LeftHand = new SingleHandedWeapons("Плачущий Джокер",5,5,0,99) ,
                    Chest = new LightArmor("Фрак", 5),
                    Notify = OutToConsole
                }
            });

        }

        private (Character p1, Character p2) Drawing()
        {
            int end = Participants.Count -1;

            int p1Index = new Random().Next(0, end);
            int p2Index = new Random().Next(0, end);

            if(Participants.Count == 2)
            {
                p1Index = 0;
                p2Index =1;
            }

            if (p1Index != p2Index)
            {
                (Character p1, Character p2) = (Participants[p1Index], Participants[p2Index]);

                Participants.Remove(p1);
                Participants.Remove(p2);

                return (p1, p2);
            }

            return Drawing();
        }

        public void OutToConsole(string name, string message)
        {
            Console.WriteLine($"[{name}] : {message}");
        }
    }
}
