using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Point
{

    class Point
    {
        float x;
        float y;

        public Point()
        {

        }

        public Point(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public Point Add(Point p)
        {
            Point n = new Point(0, 0);
            n.x = x + p.x;
            n.y = y + p.y;
            return n;
        }

        public void Print()
        {
            Console.WriteLine($"({x}, {y})");
        }
        public override string ToString()
        {
            return $"({x}, {y})";
        }
    }
}
