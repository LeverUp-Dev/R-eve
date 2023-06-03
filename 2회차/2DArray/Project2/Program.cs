using System.Diagnostics;
using System.Net.Security;

internal class Program
{
    private static void Main(string[] args)
    {
        ConsoleKeyInfo kInfo; //kInfo변수에 키입력을 받을 수 있는 기능을 선언
        int x = 25; int y = 10;
        int item = 10;
        
        Random ran = new Random();

        int[,] itemLocation = new int[2, 10];
        int[] itemX = new int[10];
        int[] itemY = new int[10];
        
        for (int i = 0; i < itemX.Length; i++)
        {
            itemX[i] = ran.Next(2, 49);
            for (int j = 0; j < i; j++)
            {
                if (itemX[i] == itemX[j])
                {
                    i--;
                    break;
                }
            }
        }

        for (int i = 0; i < itemY.Length; i++)
        {
            itemY[i] = ran.Next(2, 19);
            for (int j = 0; j < i; j++)
            {
                if (itemY[i] == itemY[j])
                {
                    i--;
                    break;
                }
            }
        }

        while (true)
        {
            for (int j = 0; j < 10; j++)
            {
                itemLocation[0, j] = itemX[j];
                itemLocation[1, j] = itemY[j];

                if (itemLocation[0, j] == x && itemLocation[1, j] == y)
                {
                    Array.Clear(itemX, j, 1);
                    Array.Clear(itemY, j, 1);
                    item--;

                    itemX[j] = 0; itemY[j] = 0;
                }

                //-1 이면 생략 아니면 아래 코드 실행
                if (itemX[j] == 0 && itemY[j] == 0)
                {
                    Console.SetCursorPosition(itemLocation[0, j], itemLocation[1, j]);
                    Console.Write(" ");
                }
                else
                {
                    Console.SetCursorPosition(itemLocation[0, j], itemLocation[1, j]);
                    Console.WriteLine("$");
                }
            }

            if (item == 0)
            {
                Console.SetCursorPosition(0, 0);
                for (int i = 0; i < 20; i++)
                {
                    for (int j = 0; j < 50; j++)
                    {
                        Console.Write("#");
                    }
                    Console.WriteLine();
                    Thread.Sleep(1);
                }
                return;
            }

            Console.SetCursorPosition(7, 20);
            Console.Write("=========x: " + x + ", " + "y: " + y + " item: " + item + "=========");
            Console.SetCursorPosition(x, y);//커서의 시작 위치를 지정
            Console.Write('@');//커서의 위치에 출력될 것을 지정
            kInfo = Console.ReadKey(true);//누른 키 기능을 가져온다.

            //키입력 받는 부분
            switch (kInfo.Key)
            {
                case ConsoleKey.LeftArrow:
                    x--;
                    if (x <= 1)
                        x = 49;
                    Console.Clear();
                    break;
                case ConsoleKey.RightArrow:
                    x++;
                    if (x >= 50)
                        x = 2;
                    Console.Clear();
                    break;
                case ConsoleKey.UpArrow:
                    y--;
                    if (y <= 1)
                        y = 19;
                    Console.Clear();
                    break;
                case ConsoleKey.DownArrow:
                    y++;
                    if (y >= 20)
                        y = 2;
                    Console.Clear();
                    break;

                case ConsoleKey.Escape:
                    for (int i = 0; i < 50; i++) //가로 50칸
                    {
                        for (int j = 0; j < 20; j++) // 세로 20칸
                        {
                            Console.SetCursorPosition(i, j);
                            Console.Write("#");
                        }
                        Console.WriteLine();
                        Thread.Sleep(1);
                    }
                    return;
            }
        }
    }
}