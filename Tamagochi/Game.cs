using System;
using System.Threading;
using System.Timers;
using Tamagochi.Core;
using Tamagochi.UI;

using Timer = System.Timers.Timer;

namespace Tamagochi
{
    public static class Game
    {
        private static int days;

        public static Timer mainTimer;

        private static readonly Student student;

        private static bool isMiniGameOn;

        private static bool isSessionOn;

        static Game()
        {
            Instructions.GetInstructions();
            Console.WriteLine("Введите имя: ");
            student = new Student(Console.ReadLine());
            mainTimer = new Timer(10000);
            mainTimer.Elapsed += OnTimeEvent;
            GameStart();
        }

        private static void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            days++;
            student.Suffer(1);
        }

        public static void GameStart()
        {
            mainTimer.Start();
            MainCycle();
        }

        private static void MainCycle()
        {
            while (true)
            {
                ReadCommand();
                Thread.Sleep(5000);
                student.ShowInfo();
            }
        }

        private static void ReadCommand()
        {
            Console.WriteLine("Введи команду: ");
            var command = Console.ReadLine();
            var parsed = command.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            switch (parsed[0])
            {
                case "eat":
                    student.Feed(Menu.meals[parsed[1]]);
                    break;
                case "do":
                    student.Disport(Menu.amusements[parsed[1]]);
                    break;
                case "learn":
                    student.Learn();
                    break;
            }
        }
    }
}