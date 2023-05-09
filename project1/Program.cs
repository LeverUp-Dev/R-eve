using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatBreeding
{
    class Program
    {
        static void Main(string[] args)
        {
            Cat cat = new Cat("Yawoong", 1);

            cat.Express();
            cat.GetBoard();
            cat.Express();
            cat.Play();            
            cat.Express();       
            cat.Eat();
            cat.Express();
        }
    }
}
