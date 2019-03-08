using System;
using System.Timers;

namespace Tamagochi
{
    internal class MiniGame
    {
        private readonly Random rand = new Random();

        public int score;
        public int time;

        private int cursorX;
        private int cursorY;

        public Timer timer;

        public int Play()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            time = 10;
            timer.Start();
            Game.ConsoleUI.Clear("MiniGameInfo");
            for (var i = 0; i < 5; i++)
            {
                if (time == 0) break;
                PlayRound();
            }

            Game.ConsoleUI.WriteLine("MiniGameInfo", $"Score {score}");
            timer.Stop();

            return score;
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (time >= 0)
            {
                /*
                Console.SetCursorPosition(0, 10);                
                Console.WriteLine($"Time {time}");
                Console.SetCursorPosition(10, 11);                            
                */
                time -= 1;
            }
        }

        public void PlayRound()
        {
            var x = rand.Next(0, 10);
            var y = rand.Next(0, 10);
            Game.ConsoleUI.Write("MiniGameInfo", $"{x} + {y} = ");
            var answer = int.Parse(Game.ConsoleUI.ReadLine("MiniGameInfo"));
            if (answer == x + y) score++;
        }
    }
}