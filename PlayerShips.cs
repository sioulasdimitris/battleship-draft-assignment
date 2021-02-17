using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{

    class PlayerShips
    {
        private int shipsNum = 4;
        private Ship[] ships;
        private int sinkedShipsNum = 0;

        public PlayerShips()
        {
            ships = new Ship[shipsNum];
            ships[0] = new Ship("aircraftCarrier", "Aircraft Carrier", 5);
            ships[1] = new Ship("destroyer", "Destroyer", 4);
            ships[2] = new Ship("warShip", "War Ship", 3);
            ships[3] = new Ship("submarine", "Submarine", 2);
        }

        public Ship[] getShips()
        {
            return ships;
        }

        public int getSinkedSipsNum()
        {
            return sinkedShipsNum;
        }

        public void increaseSinkedShipsNum()
        {
            sinkedShipsNum++;
        }

        public Boolean isThereAnyLeft()
        {
            if(sinkedShipsNum == shipsNum)
            {
                return false;
            }
            return true;
        }


    }
}
