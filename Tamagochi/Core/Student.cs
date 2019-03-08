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
            var t_cl = Console.CursorLeft;
            var t_ct = Console.CursorTop;

            Game.ConsoleUI.Clear("StudentInfo");
            //Game.ConsoleUI.SwitchBox("StudentInfo");

            Game.ConsoleUI.WriteLine("StudentInfo", "Состояние студента " + name + ":");
            Game.ConsoleUI.WriteLine("StudentInfo", "Сытость: " + stomach.fulness);
            Game.ConsoleUI.WriteLine("StudentInfo", "Интеллект: " + brain.intellect);
            Game.ConsoleUI.WriteLine("StudentInfo", "Счастье: " + soul.happiness);
            Game.ConsoleUI.WriteLine("StudentInfo", "Живой: " + (IsAlive() ? "да" : "нет"));

            //Console.SetCursorPosition(40, Game.cursorPositionY);
            //Console.SetCursorPosition(t_cl, t_ct);
        }
    }
}