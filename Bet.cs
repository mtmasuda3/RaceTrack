using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RacetrackSimulator
{
    public class Bet
    {
        //class variables
        public int Amount; //amount of cash that is bet
        public int Dog; //number of the dog that the bet is on
        public Guy Bettor; //guy who placed the bet

        //class methods
        public void GetDescription()
        {
            //did this in updateLabel() in Guy class
        }
        public int PayOut(int Winner)//return amount for winners and losers
        {
            if (Dog == Winner)
            {
                return Amount;
            }

            else
            {
                return -Amount;
            }
        }
    }
}
