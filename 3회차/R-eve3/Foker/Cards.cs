using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foker
{
    public enum Suit { H, S, C, D };
    public struct Card
    {
        public int number;
        public Suit suit;       
    }

    internal class Cards
    {
        public static Card[] card = new Card[52];

        public Cards()
        {
            int cardCnt = 0;

            for (int i = 0; i < card.Length; i++)
            {
                cardCnt++;
                card[i].number = cardCnt;
                if (i < 13)
                {                    
                    card[i].suit = Suit.H;
                }                    
                else if(i > 12 && i < 26)
                {
                    card[i].suit = Suit.C;
                }
                else if (i > 25 && i < 39)
                {
                    card[i].suit = Suit.S;
                }
                else if (i > 38)
                {
                    card[i].suit = Suit.D;
                }
                if (cardCnt == 13)
                {
                    cardCnt = 0;
                }
            }
        }

        public void ShowCards()
        {
            Suit prev = card[0].suit;
            for (int i = 0; i < card.Length; i++)
            {
                if (prev != card[i].suit)
                {
                    Console.WriteLine();
                }
                prev = card[i].suit;
                Console.Write(card[i].suit + " " + card[i].number + ", ");
            }
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public void Shuffle()
        {
            Random ran = new Random();
            //card = card.OrderBy(x => ran.Next()).ToString());
        }
    }
}
