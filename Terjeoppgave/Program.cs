using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleTurtle
{
    class Program
    {
        private static int _myCol;
        private static int _myRow;
        private static Direction _myDirection;

        static void Main(string[] args)
        {
            var rowLength = Console.WindowWidth;
            _myCol = rowLength / 2;
            _myRow = Console.WindowHeight / 2;
            _myDirection = Direction.Right;
            var maxRowIndex = Console.WindowHeight - 3;
            var charsOnScreen = rowLength * maxRowIndex;
            var screen = string.Empty.PadLeft(charsOnScreen, ' ').ToCharArray();
            const string symbols = "A>V<";
            while (true)
            {
                Console.Clear();
                for (var rowIndex = 0; rowIndex < maxRowIndex; rowIndex++)
                {
                    Console.WriteLine(screen, rowIndex * rowLength, rowLength);
                }
                Console.WriteLine("Kommandoer: pil opp = GO, pil venstre = TURN LEFT, pil høyre = TURN RIGHT");
                var key = Console.ReadKey().Key;

                if (key == ConsoleKey.UpArrow)
                {
                    if (_myDirection == Direction.Right) _myCol++;
                    else if (_myDirection == Direction.Left) _myCol--;
                    else if (_myDirection == Direction.Up) _myRow--;
                    else if (_myDirection == Direction.Down) _myRow++;
                    var index = _myCol + rowLength * _myRow;
                    screen[index] = symbols[(int)_myDirection];
                }
                else if (key is ConsoleKey.RightArrow or ConsoleKey.LeftArrow)
                {
                    var delta = key == ConsoleKey.RightArrow ? 1 : -1;
                    _myDirection = (Direction)(((int)_myDirection + delta + 4) % 4);
                }
            }
        }
    }
}