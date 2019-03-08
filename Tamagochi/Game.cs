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

        public static ConsoleBox.ConsoleOutput ConsoleUI;

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
            ConsoleUIInit();
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
            ConsoleUI.WriteLine("MainInput", "Введи команду: ");
            //Console.SetCursorPosition(40, cursorPositionY);
            var command = ConsoleUI.ReadLine("MainInput");
            var parsed = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (parsed.Length < 1)
                return;
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
                default:
                    break;
            }
            cursorPositionY += 1;
            student.ShowInfo();
        }

        private static void ConsoleUIInit()
        {
            ConsoleUI = new ConsoleBox.ConsoleOutput();
            ConsoleUI.AddBox("MainInput", new ConsoleBox(40, 0, 30, 100));
            ConsoleUI.AddBox("StudentInfo", new ConsoleBox(0, 2, 30, 7));
            ConsoleUI.AddBox("MiniGameInfo", new ConsoleBox(0, 12, 30, 10));
            ConsoleUI.SwitchBox("MainInput");
        }
    }
}
