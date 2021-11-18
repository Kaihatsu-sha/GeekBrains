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
                new Character("Сир Лора", "")
                { 
                    RightHand = new SingleHandedWeapons("","",8,13,10,10) ,
                    LeftHand = new SingleHandedWeapons("","",8,13,10,10) ,
                    Notify = OutToConsole},
                new Character("Королевский палач", ""){ RightHand = new TwoHandedWeapons("","",10,15,10,10) , Notify = OutToConsole },
                new Character("Степной волк", ""){ RightHand = new TwoHandedWeapons("","",10,15,10,10) , Notify = OutToConsole },
                new Character("Продавец мяса", ""){ RightHand = new TwoHandedWeapons("","",10,15,10,10) , Notify = OutToConsole },
                new Character("Разбойник", ""){ RightHand = new TwoHandedWeapons("","",10,15,10,10) , Notify = OutToConsole },
                new Character("МариКрим Де Франс", ""){ RightHand = new TwoHandedWeapons("","",10,15,10,10) , Notify = OutToConsole },
                new Character("Оходник Робин", ""){ RightHand = new TwoHandedWeapons("","",10,15,10,10) , Notify = OutToConsole },
                new Character("Счастливчик Джо", ""){ RightHand = new TwoHandedWeapons("","",10,15,10,10) , Notify = OutToConsole }
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
