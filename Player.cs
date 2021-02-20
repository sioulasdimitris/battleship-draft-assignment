using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{

    class Player
    {
        private int movesCount;//keep count of the moves for each game
        private int shipsNum = 4;
        private Ship[] ships;
        private int sinkedShipsNum = 0;
        private HashSet<int> exclude;//we keep the taken positions

        public Player()
        {
            exclude = new HashSet<int>();
            movesCount = 0;
            ships = new Ship[shipsNum];
            //create the 4 ships
            ships[0] = new Ship("aircraftCarrier", "Aircraft Carrier", 5);
            ships[1] = new Ship("destroyer", "Destroyer", 4);
            ships[2] = new Ship("warShip", "War Ship", 3);
            ships[3] = new Ship("submarine", "Submarine", 2);

            //for each ship, create random position
            for (int i=0; i < ships.Length; i++)
            {
                createPosition(ships[i]);
            }

        }

        public void createPosition(Ship ship)//create position for each ship method
        {
            int[] squares = new int[ship.getLength()];
            int firstPosition;
            int orientation;

            bool firstPass = false;
            bool secondPasss = false;

            while (firstPass == false)
            {
                firstPass = true;
                firstPosition = getNewRandomPosition();
                orientation = getRandomOrientation();

                if (orientation == 2)//horizontal
                {
                    if (firstPosition >= 0 && firstPosition <= 9)
                    {
                        if (firstPosition + ship.getLength() - 1 <= 9)
                            secondPasss = true;

                    }
                    else if (firstPosition >= 10 && firstPosition <= 19)
                    {
                        if (firstPosition + ship.getLength() - 1 <= 19)
                            secondPasss = true;

                    }
                    else if (firstPosition >= 20 && firstPosition <= 29)
                    {
                        if (firstPosition + ship.getLength() - 1 <= 29)
                            secondPasss = true;

                    }
                    else if (firstPosition >= 30 && firstPosition <= 39)
                    {
                        if (firstPosition + ship.getLength() - 1 <= 39)
                            secondPasss = true;

                    }
                    else if (firstPosition >= 40 && firstPosition <= 49)
                    {
                        if (firstPosition + ship.getLength() - 1 <= 49)
                            secondPasss = true;

                    }
                    else if (firstPosition >= 50 && firstPosition <= 59)
                    {
                        if (firstPosition + ship.getLength() - 1 <= 59)
                            secondPasss = true;

                    }
                    else if (firstPosition >= 60 && firstPosition <= 69)
                    {
                        if (firstPosition + ship.getLength() - 1 <= 69)
                            secondPasss = true;

                    }
                    else if (firstPosition >= 70 && firstPosition <= 79)
                    {
                        if (firstPosition + ship.getLength() - 1 <= 79)
                            secondPasss = true;

                    }
                    else if (firstPosition >= 80 && firstPosition <= 89)
                    {
                        if (firstPosition + ship.getLength() - 1 <= 89)
                            secondPasss = true;

                    }
                    else if (firstPosition >= 90 && firstPosition <= 99)
                    {
                        if (firstPosition + ship.getLength() - 1 <= 99)
                            secondPasss = true;

                    }


                    if (secondPasss)
                    {
                        for (int i = 1; i < ship.getLength(); i++)//horizontal
                        {
                            if (exclude.Contains(firstPosition + i))
                            {
                                firstPass = false;
                                break;
                            }
                        }

                        if (firstPass)
                        {
                            for (int i = 0; i < ship.getLength(); i++)
                            {
                                squares[i] = firstPosition + i;
                                exclude.Add(firstPosition + i);
                            }
                        }
                    }
                    else
                    {
                        firstPass = false;
                    }

                } else //vertical
                {
                    secondPasss = true;

                    if ((secondPasss) && (firstPosition + (ship.getLength() * 10) < 100))
                    {
                        for (int i = 0; i < ship.getLength()*10; i=i+10)//horizontal
                        {
                            if (exclude.Contains(firstPosition + i))
                            {
                                firstPass = false;
                                break;
                            }
                        }
                        int x = 0;
                        if (firstPass)
                        {
                            for (int i = 0; i < ship.getLength(); i++)
                            {
                                squares[i] = firstPosition + x;
                                exclude.Add(firstPosition + x);
                                x += 10;
                            }
                        }
                    }
                    else
                    {
                        firstPass = false;
                    }
                }

            }//while

            ship.setSquares(squares);
        }

        private int getNewRandomPosition()//return a random integer in range 0-99 excluding the already taken positions
        {
            var range = Enumerable.Range(0, 100).Where(i => !exclude.Contains(i));

            var rnd = new System.Random();
            int index = rnd.Next(0, 100 - exclude.Count);//exclude taken positions
            return range.ElementAt(index);
        }

        private int getRandomOrientation()//get random orientation, 1 for vertical, 2 for horizontal
        {
            Random rnd = new Random();
            int orientation = rnd.Next(1, 3);
            return orientation;
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

        public void increaseMovesCount()
        {
            this.movesCount++;
        }

        public int getMovesCount()
        {
            return this.movesCount;
        }

    }
}
