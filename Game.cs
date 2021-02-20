using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    class Game
    {
        private int whosTurnIs;
        private int numOfGames;


        public Game()
        {
            this.numOfGames = 0;
        }

        public void startNewGame()
        {
            this.whosTurnIs = 1;
            this.numOfGames++;
        }

        public int getNumOfGames()
        {
            return this.numOfGames;
        }

        public void changeTurn()
        {
            this.whosTurnIs++;
            if (this.whosTurnIs > 2)
            {
                this.whosTurnIs = 1;
            }
        }

        public int getWhosTurnIs()
        {
            return this.whosTurnIs;
        }


    }
}
