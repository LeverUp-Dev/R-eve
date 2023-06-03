using System;
using System.Threading;

namespace Class_Poker
{
    public enum Suit { S, D, H, C };
    public struct Card
    {
        public Suit suit;
        public int number;
    }

    internal class Cards
    {      
        public static Card[] card = new Card[52];

        public Cards()
        {
            for (int i = 0; i < card.Length; i++)
            {
                card[i].suit = (Suit)(i / 13);
                card[i].number = i % 13 + 1;
            }     
        }

        public void ShowCards() 
        {
            for (int i = 0; i < card.Length; i++)
            {
                Console.Write("{0} {1}, ", card[i].suit, card[i].number.ToString("00"));
                if (i%13==12)
                {
                    Console.WriteLine();                    
                }
                Thread.Sleep(1);
            }
            Console.WriteLine("----------------------------------------");
            Console.ReadKey();
        }

        public void Shuffle()
        {
            Random r = new Random();

            for (int i = 0; i < 100; i++)
            {
                int r1 = r.Next(52);
                int r2 = r.Next(52);

                Card tmpCard = card[r1];
                card[r1] = card[r2];
                card[r2] = tmpCard;
            }
        }

        public void Distribute(int numPlayer)
        {
            Player[] player = new Player[numPlayer];
            for (int i = 0; i < numPlayer; i++)
            {
                player[i] = new Player(); // 메모리 할당
            }

            int k = 0;
            for (int i = 0; i < numPlayer; i++) // 플레이어 수
            {
                Console.Write(player[i].PlayerNo.ToString("000"));
                for (int j = 0; j < Player.numCard; j++) // 플레이어당 카드 수
                {                    
                    player[i].card[j] = card[k];  // 카드 할당
                    //player[i].card[j].suit = card[k].suit;
                    //player[i].card[j].number = card[k].number;
                    k++;

                    Console.Write($": {player[i].card[j].suit} {player[i].card[j].number.ToString("00")}, ");
                    Thread.Sleep(1); // 특정패 볼때 주석
                }

                CheckCard(player[i]);
                Console.WriteLine();
            }
        }

        private void CheckCard(Player player)
        {
            Console.Write("= ");

            int c1 = JockBo.IsOnePair(player);
            if (c1 != 0) return;
            int c2 = JockBo.IsTwoPair(player);
            if (c2 != 0) return;
            int c3 = JockBo.IsTriple(player);
            if (c3 != 0) return;
            int c4 = JockBo.IsStraight(player);
            if (c4 != 0) return;
            int c5 = JockBo.IsFlush(player);
            if (c5 != 0) return;
            int c6 = JockBo.IsFullHouse(player);
            if (c6 != 0)
            {
                //Console.ReadKey();
                return;
            }

            int c7 = JockBo.IsPoker(player);
            if (c7 != 0)
            {
                Console.ReadKey();
                return;
            }
            int c8 = JockBo.IsStraightFlush(player);
            if (c8 != 0) return;
            int c9 = JockBo.IsNoPair(player);
            if (c9 != 0) return;
        }
    }
}