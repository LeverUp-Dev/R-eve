using System;
using System.Collections.Concurrent;
using System.ComponentModel.Design.Serialization;

internal class Program
{
    
    class Cicrcle
    {
        public double PI;
        public double radius;
        public int X;
        public int Y;

        public void CPoint()
        {
            Console.Write("원의 위치: ({0}, {1}) ", X, Y);
        }

        public void CSize()
        {
            this.PI = 3.14;
            double size = radius * radius * PI;
            Console.WriteLine("원의 크기: {0:.00}",size);
        }
        public bool Crash(Cicrcle other)
        {
            int w = (int)other.X - X;
            int h = (int)other.Y - Y;
            int pita = (w*w)+(h*h);
            float hypotenuse = Root(pita);
            return hypotenuse <= (radius + other.radius);
        }
        public static float Root(int a)
        {
            float c = 1.0f;
            while (true)
            {
                c = c + 0.01f;
                if ((c * c) >= a)
                    break;
            }
            return (int)(c * 100) / 100.0f;
        }

    }

    private static void Main(string[] args)
    {  
        Random ran = new Random();
        int cnt = 0;
        while (true) {
            
            cnt++;
            Console.WriteLine(cnt +"번째 실행");

        Console.Write("원1:");
        Cicrcle cic1 = new Cicrcle();
        cic1.X = ran.Next(1, 100);
        cic1.Y = ran.Next(1, 100);
        cic1.CPoint();
        cic1.radius = ran.Next(1, 10);
        cic1.CSize();

        Console.Write("원2:");
        Cicrcle cic2 = new Cicrcle();
        cic2.X = ran.Next(1, 100);
        cic2.Y = ran.Next(1, 100);
        cic2.CPoint();
        cic2.radius = ran.Next(1, 10);
        cic2.CSize();

            Console.WriteLine("");

            if (cic1.Crash(cic2) == false)
            {
                continue;
            }
            if(cic2.Crash(cic1) == true) 
            {
                Console.WriteLine(cnt+ "번째 실행에서 " 
                    +"원이 서로 교차(충돌) 하였습니다.");
            }
            break;
        }

    }
}