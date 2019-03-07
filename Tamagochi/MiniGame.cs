using System;
using System.Timers;

namespace Tamagochi
{
    internal class MiniGame
    {
        private readonly Random rand = new Random();

        public int score;
        public int time;
        public Timer timer;

        public int Play()
        {
            timer = new Timer(1000);
            timer.Elapsed += OnTimedEvent;
            time = 10;
            timer.Start();
            for (var i = 0; i < 5; i++)
            {
                if (time == 0) break;
                PlayRound();
                Console.Clear();
            }

            Console.WriteLine($"Score {score}");
            timer.Stop();

            return score;
        }

        public void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if (time >= 0)
            {
                Console.SetCursorPosition(10, 0);
                Console.WriteLine($"Time {time}");
                time -= 1;
            }
        }

        public void PlayRound()
        {
            var x = rand.Next(0, 10);
            var y = rand.Next(0, 10);
            Console.WriteLine($"{x} + {y} = ");
            var answer = int.Parse(Console.ReadLine());
            if (answer == x + y) score++;
        }
    }
}