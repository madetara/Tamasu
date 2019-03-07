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

        public static int cursorPositionY = 0;

        private static void OnTimeEvent(object source, ElapsedEventArgs e)
        {
            days++;
            student.Suffer(1);
            student.ShowInfo();
        }

        static Game()
        {
            Instructions.GetInstructions();
            Console.WriteLine("Введите имя: ");
            student = new Student(Console.ReadLine());
            Console.Clear();
            mainTimer = new Timer(1000);
            mainTimer.Elapsed += OnTimeEvent;
            GameStart();
        }

        public static void GameStart()
        {
            mainTimer.Start();
            Console.SetCursorPosition(40, 0);
            student.ShowInfo();
            MainCycle();
        }

        private static void MainCycle()
        {
            while (true)
            {
                ReadCommand();
                Thread.Sleep(5000);                
            }
        }

        private static void ReadCommand()
        {            
            Console.WriteLine("Введи команду: ");
            cursorPositionY += 1;
            Console.SetCursorPosition(40, cursorPositionY);
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
            cursorPositionY += 1;
            student.ShowInfo();
        }
    }
}