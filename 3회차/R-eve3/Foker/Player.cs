using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Foker
{
    class Player
    {
        static int cnt = 1;

        private int playerNo;
        public int PlayerNo
        {
            get { return playerNo; }
        }

        public Player()
        {
            this.playerNo = cnt++;
        }

    }
}
