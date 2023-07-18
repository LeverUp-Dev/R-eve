using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGenerate
{
    class Player
    {
        public int x, y;
        private readonly char image;
        public Player(char character, int inx, int iny)
        {
            image = character;
            x = inx;
            y = iny;
        }

        public char Image => image;
        ConsoleKeyInfo c;

        public void Input()
        {
            c = Console.ReadKey(true);
            switch (c.Key)
            {
                case ConsoleKey.UpArrow:
                    y--;
                    break;
                case ConsoleKey.DownArrow:
                    y++;
                    break;
                case ConsoleKey.LeftArrow:
                    x-=2;
                    break;
                case ConsoleKey.RightArrow:
                    x+=2;
                    break;
                default:
                    break;
            }
        }
    }
}
