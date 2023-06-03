using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CursorMultiTask
{
    class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Program
    {
        enum Mark { empty, player, item }
        static int screenX = 50, screenY = 25;
        static Mark[,] screen = new Mark[screenX, screenY];
        static List<Point> itemList = new List<Point>();
        static int px = 25, py = 12;
        static bool isGameOn = true;
        static ConsoleKeyInfo cki;

        static void Main(string[] args)
        {
            ClearScreen();      
            MakeItem();  
            DrawScreen(); 

            KeyInput();            

            while (isGameOn == true)
            {
                MovePlayer(); 
                CheckState();
            }
            ExitGame(); 
        }

        private static void KeyInput()
        {
            Task task = new Task(() =>
            {
                while (true)
                {
                    cki = Console.ReadKey();
                }

            });
            task.Start();
        }

        private static void MovePlayer()
        {            
            Console.SetCursorPosition(px, py);
            Console.WriteLine(" ");
            
            switch (cki.Key)
            {
                case ConsoleKey.LeftArrow:
                    px--;
                    break;
                case ConsoleKey.RightArrow:
                    px++;
                    break;
                case ConsoleKey.UpArrow:
                    py--;
                    break;
                case ConsoleKey.DownArrow:
                    py++;
                    break;
                default:
                    break;
            }
            if (px >= screenX) px = 1;
            if (px <= 0) px = screenX - 1;
            if (py >= screenY) py = 1;
            if (py <= 0) py = screenY - 1;
            Console.SetCursorPosition(px, py);
            Console.Write("P");
            ShowCursorPosition();
            Thread.Sleep(100);
        }

        private static void CheckState()
        {
            if (screen[px, py] == Mark.item) // 플레이어 위치에 아이템이 있으면
            {
                for (int i = itemList.Count - 1; i >= 0; i--) // 리스트 각각에 대해
                {
                    if (itemList[i].x == px && itemList[i].y == py) // 리스트의 아이템과 같으면
                    {
                        itemList.Remove(itemList[i]); //제거
                        if (itemList.Count == 0)
                        {
                            isGameOn = false;
                        }
                    }
                }
                screen[px, py] = Mark.empty;
            }
        }


        private static void ShowCursorPosition()
        {
            Console.SetCursorPosition(15, 26);
            Console.WriteLine("=========== x:{0}, y:{1} Item:{2} ===========", px, py, itemList.Count);
        }

        private static void ClearScreen()
        {
            for (int i = 0; i < screenX; i++)
            {
                for (int j = 0; j < screenY; j++)
                {
                    screen[i, j] = Mark.empty;
                }
            }
        }

        //한 자리에 두개 이상 있을 수도 있음
        private static void MakeItem()
        {
            Random r = new Random();

            for (int i = 0; i < 10; i++)
            {
                int x = r.Next(1, screenX - 1);
                int y = r.Next(1, screenY - 1);
                Point p = new Point(x, y);
                itemList.Add(p);
                screen[x, y] = Mark.item;
            }
        }

        private static void DrawScreen()
        {
            Console.CursorVisible = false;

            for (int i = 0; i < screenX; i++)
            {
                for (int j = 0; j < screenY; j++)
                {
                    if (screen[i, j] == Mark.item)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("$"); //WinKey + .
                    }
                }
            }
            ShowCursorPosition();
        }

        private static void ExitGame()
        {
            for (int i = 0; i < screenX; i++)
            {
                for (int j = 0; j < screenY; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.WriteLine("#");
                }
            }
        }
    }
}

