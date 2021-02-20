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
        }

        public Boolean getSinked()
        {
            return sinked;
        }

        public String getName()
        {
            return name;
        }

        public int[] getSquares()//get the squares that the ship is going to be placed
        {
            return squares;
        }

        public void setSquares(int[] squares)//set the squares the ship is going to be placed
        {
            this.squares = squares;
        }

        public int getLength()//get the length of the ship (how many squares)
        {
            return length;
        }

        public void increaseSuccesfulHits()//if some square of the ship is hit increase succesfulHits variable
        {
            succesfulHits++;
            if (succesfulHits == length)//if the sucessful hits are equal to the ship's length, the ship has been sinked
                sinked = true;
        }

    }


}
