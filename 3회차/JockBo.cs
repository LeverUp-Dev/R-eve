using System;
using System.Collections.Generic;
using System.Linq;

namespace Class_Poker
{
    internal class JockBo
    {
        static int CountNum(Player player)
        {
            int count = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (player.card[i].number == player.card[j].number)
                    {
                        if (i != j) count++;
                    }
                }
            }
            return count;
        }

        static int FindSameNo(Player player)
        {
            for (int i = 0; i < player.card.Length; i++)
            {
                for (int j = 0; j < player.card.Length; j++)
                {
                    if (player.card[i].number == player.card[j].number && i != j)
                    {
                        Console.Write(player.card[i].number.ToString("00")); //
                        return player.card[i].number;
                    }
                }
            }
            return 0;
        }

        public static int IsOnePair(Player player)
        {
            int count = CountNum(player);

            if (count == 2)
            {
                int no = FindSameNo(player);
                Console.Write(" One Pair");

                return no;
            }
            else return 0;
        }

        public static int IsTwoPair(Player player)
        {
            int count = CountNum(player);

            if (count == 4)
            {
                int no = FindSameNo(player);
                Console.Write(" Two Pair");
                return no;
            }
            else return 0;
        }

        public static int IsTriple(Player player)
        {
            int count = CountNum(player);

            if (count == 6)
            {
                int no = FindSameNo(player);
                Console.Write(" Triple");
                return no;
            }
            else return 0;
        }

        public static int IsStraight(Player player)
        {
            List<int> numsList = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                for (int m = 0; m < 5; m++)
                {
                    if (player.card[i].number == player.card[m].number)
                    {
                        if (i != m)
                        {
                            return 0;
                        }
                    }
                }
            }

            for (int i = 0; i < 5; i++)
            {
                numsList.Add(player.card[i].number);
            }            

            int max = numsList.Max();
            int min = numsList.Min();
            if (max - min == 4)
            {
                Console.Write(max.ToString("00") + " Straight***");
                return max;
            }
            else
            {
                return 0;
            }
        }

        public static int IsFlush(Player player)
        {
            for (int i = 1; i < 5; i++)
            {
                if (player.card[0].suit != player.card[i].suit)
                {
                    return 0;
                }
            }

            Console.Write(player.card[0].suit + " Flush***");
            return 1;
        }

        public static int IsFullHouse(Player player)
        {
            int count = CountNum(player);

            if (count == 8)
            {
                Console.Write(" FullHouse!*****");
                return 1;
            }
            else return 0;
        }

        public static int IsPoker(Player player)
        {
            int count = CountNum(player);

            if (count == 12) // 3 *4
            {
                int no = FindSameNo(player);
                Console.Write(" POKER! *********");
                return no;
            }
            else return 0;
        }

        public static int IsStraightFlush(Player player)
        {
            int s = IsStraight(player);
            int f = IsFlush(player);
            if ((s + f) == 2)
            {
                Console.Write(" **********StraightFlush!**********");
                return 1;
            }
            return 0;
        }


        public static int IsNoPair(Player player)
        {
            int max = player.card[0].number;
            for (int i = 1; i < player.card.Length; i++)
            {
                if (max < player.card[i].number)
                {
                    max = player.card[i].number;
                }
            }
            Console.Write(max.ToString("00") + " No Pair");
            return max;

        }
    }
}
