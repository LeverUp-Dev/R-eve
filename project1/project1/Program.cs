using System.Collections.Concurrent;

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

    }
    private static void Main(string[] args)
    {
        Random ran = new Random();

        Console.WriteLine("1번째 원");
        Cicrcle cic1 = new Cicrcle();
        cic1.X = ran.Next(-50, 50);
        cic1.Y = ran.Next(-50, 50);
        cic1.CPoint();
        cic1.radius = ran.Next(1, 5);
        cic1.CSize();

        Console.WriteLine("2번째 원");
        Cicrcle cic2 = new Cicrcle();
        cic2.X = ran.Next(-50, 50);
        cic2.Y = ran.Next(-50, 50);
        cic2.CPoint();
        cic2.radius = ran.Next(1, 5);
        cic2.CSize();

    }
}