using System;
using System.Collections.Generic;
using System.Text;

namespace Tamagochi.UI
{
    public class ConsoleBox
    {
        public int pivotLeft { get; private set; }
        public int pivotTop { get; private set; }

        public int width { get; private set; }
        public int height { get; private set; }

        public int pivotRight { get { return pivotLeft + width; } }
        public int pivotBottom { get { return pivotTop + height; } }

        public int cursorLeft { get; private set; }
        public int cursorTop { get; private set; }

        public ConsoleBox(int pL, int pT, int w, int h)
        {
            pivotLeft = pL; width = w;
            pivotTop = pT; height = h;

            cursorLeft = pL;
            cursorTop = pT;
        }

        public void NewLine()
        {
            Console.SetCursorPosition(pivotLeft, cursorTop + 1);
        }

        public void Write(string str)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            var freeSpace = pivotRight - cursorLeft;
            if (str.Length < freeSpace)
                Console.Write(str);
            else
            {
                Console.Write(str.Substring(0, freeSpace)); NewLine();
                Console.Write(str.Substring(freeSpace)); // Не учитывает, если строку нужно ещё раз делить, но мне пока лень            
            }

            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;
        }

        public string ReadLine()
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            var result = Console.ReadLine();
            cursorLeft = pivotLeft;
            cursorTop++;
            Console.SetCursorPosition(cursorLeft, cursorTop);

            return result;
        }

        public void WriteLine(string str)
        {
            Console.SetCursorPosition(cursorLeft, cursorTop);
            var freeSpace = pivotRight - cursorLeft;
            if (str.Length < freeSpace)
                Console.Write(str);
            else
            {
                Console.Write(str.Substring(0, freeSpace)); NewLine();
                Console.Write(str.Substring(freeSpace)); // Не учитывает, если строку нужно ещё раз делить, но мне пока лень            
            }

            NewLine();

            cursorLeft = Console.CursorLeft;
            cursorTop = Console.CursorTop;
        }

        public void Clear()
        {
            //SO FREAKING PLACEHOLDER
            Console.SetCursorPosition(pivotLeft, pivotTop);
            for (int i = pivotLeft; i < pivotRight; i++)
                for (int j = pivotTop; j < pivotBottom; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            cursorLeft = pivotLeft;
            cursorTop = pivotTop;
        }

        public void Move(int pL, int pT) =>
            Console.MoveBufferArea(pivotLeft, pivotTop, width, height, pL, pT);

        public class ConsoleOutput
        {
            public Dictionary<string, ConsoleBox> boxes; //public is temp
            private ConsoleBox curBox;

            public ConsoleOutput()
            {
                boxes = new Dictionary<string, ConsoleBox>();
                curBox = null;
            }

            public void AddBox(string name, ConsoleBox box) =>
                boxes.Add(name, box);

            public void SwitchBox(ConsoleBox box)
            {
                UpdateCursorPosition();
                curBox = box;
            }

            public void SwitchBox(string str)
            {
                UpdateCursorPosition();
                curBox = boxes[str];
                Console.SetCursorPosition(curBox.cursorLeft, curBox.cursorTop);
            }

            public void Write(string str) =>
                curBox.Write(str);

            public void WriteLine(string str) =>
                curBox.WriteLine(str);

            public void Write(string boxName, string str)
            {
                UpdateCursorPosition();
                boxes[boxName].Write(str);
                ReturnCursorPosition();
            }

            public void WriteLine(string boxName, string str)
            {
                UpdateCursorPosition();
                boxes[boxName].WriteLine(str);
                ReturnCursorPosition();
            }

            public string ReadLine(string boxName)
            {
                UpdateCursorPosition();
                var result = boxes[boxName].ReadLine();
                ReturnCursorPosition();

                return result;
            }

            public void Clear(string boxName)
            {
                UpdateCursorPosition();
                boxes[boxName].Clear();
                ReturnCursorPosition();
            }

            private void UpdateCursorPosition()
            {
                if (curBox != null)
                {
                    curBox.cursorLeft = Console.CursorLeft;
                    curBox.cursorTop = Console.CursorTop;
                }
            }

            private void ReturnCursorPosition()
            {
                if (curBox != null)
                    Console.SetCursorPosition(curBox.cursorLeft, curBox.cursorTop);
            }
        }
    }
}
