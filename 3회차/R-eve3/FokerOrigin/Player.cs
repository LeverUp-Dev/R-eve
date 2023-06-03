using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Poker
{
    class Player
    {
        static int counter = 1;
        
        private int playerNo;
        public int PlayerNo
        {
            get { return playerNo; }            
        }

        public Player()
        {
            this.playerNo = counter++;
        }

        public static int numCard = 5;
        public Card[] card = new Card[numCard];
    }
}
