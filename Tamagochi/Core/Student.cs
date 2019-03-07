using System;
using Tamagochi.Core.Consumables;
using Tamagochi.Core.Entrails;

namespace Tamagochi.Core
{
    public class Student
    {
        private readonly Brain brain;
        private int course;
        private readonly string name;
        private readonly Soul soul;
        private readonly Stomach stomach;

        public Student(string name)
        {
            this.name = name;
            stomach = new Stomach();
            soul = new Soul();
            brain = new Brain();
        }

        public void Suffer(int point)
        {
            GetStupid(point);
            GetHungry(point);
            GetBored(point);
        }

        private void GetStupid(int point)
        {
            brain.intellect += point;
        }

        private void GetHungry(int point)
        {
            stomach.fulness += point;
        }

        private void GetBored(int point)
        {
            soul.happiness += point;
        }

        public void Die()
        {
            stomach.fulness = -1000000;
        }

        public bool IsAlive()
        {
            return soul.happiness > 0
                   && brain.intellect > 0
                   && stomach.fulness > 0;
        }

        public void Feed(Meal meal)
        {
            stomach.fulness += meal.fullnessMod;
            soul.happiness += meal.hapinnesMod;
            brain.intellect += meal.intellectMod;
        }

        public void Disport(Amusement amusement)
        {
            stomach.fulness += amusement.fullnessMod;
            soul.happiness += amusement.hapinnesMod;
            brain.intellect += amusement.intellectMod;
        }

        public void Learn()
        {
            var game = new MiniGame();
            Game.mainTimer.Enabled = false;
            var score = game.Play();
            brain.intellect += score;
        }

        public void ShowInfo()
        {
            const int XCord = 0;
            
            Console.SetCursorPosition(XCord, 0);
            Console.Write("Состояние студента " + name + ":");
            Console.SetCursorPosition(XCord, 1);
            Console.Write("Сытость: " + stomach.fulness);
            Console.SetCursorPosition(XCord, 2);
            Console.Write("Интеллект: " + brain.intellect);
            Console.SetCursorPosition(XCord, 3);
            Console.Write("Счастье: " + soul.happiness);
            Console.SetCursorPosition(XCord, 4);
            Console.Write("Живой: " + (IsAlive() ? "да" : "нет"));
            Console.SetCursorPosition(40, Game.cursorPositionY);
        }
    }
}
