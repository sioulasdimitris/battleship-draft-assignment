using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
   public class Ship
    {
        private String id;
        private String name;
        private int length;
        private int[] squares;
        private int succesfulHits = 0;
        private Boolean sinked = false;


        public Ship(String id, String name, int length)
        {
            this.id = id;
            this.name = name;
            this.length = length;
            squares = new int[length];
            dummyMethod(id, squares);
        }

        private void dummyMethod(String id, int[] squares)
        {
            //ship 1
            if(String.Equals(id, "aircraftCarrier"))
            {
                squares[0] = 1;
                squares[1] = 2;
                squares[2] = 3;
                squares[3] = 4;
                squares[4] = 5;

            }
            //ship 2
            if (String.Equals(id, "destroyer"))
            {
                squares[0] = 10;
                squares[1] = 20;
                squares[2] = 30;
                squares[3] = 40;

            }
            //ship 3
            if (String.Equals(id, "warShip"))
            {
                squares[0] = 54;
                squares[1] = 55;
                squares[2] = 56;

            }
            //ship 4
            if (String.Equals(id, "submarine"))
            {
                squares[0] = 29;
                squares[1] = 39;

            }
        }

        public Boolean getSinked()
        {
            return sinked;
        }

        public String getName()
        {
            return name;
        }

        public int[] getSquares()
        {
            return squares;
        }

        public int getLength()
        {
            return length;
        }

        public void increaseSuccesfulHits()
        {
            succesfulHits++;
            if (succesfulHits == length)
                sinked = true;
        }

    }


}
