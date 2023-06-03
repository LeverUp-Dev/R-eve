using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Poker
{
    class Program
    {
        static void Main(string[] args)
        {
            Cards cards = new Cards();
            // 카드제작 : Cards() 무늬와 숫자 입력                      
            cards.ShowCards();
            cards.Shuffle();
            cards.ShowCards();

            ConsoleKeyInfo cki;
            do
            {
                cards.Distribute(5); // 플레이어 수 결정
                cki = Console.ReadKey(); // 특정패 볼때 주석
                // 승패 결정 (생략)
                cards.Shuffle();
                Console.Clear();
            }
            while (cki.Key != ConsoleKey.Escape); // 특정패 볼때 주석
            //while (true); // 특정패 볼때 주석 해제

        }

    }
}
