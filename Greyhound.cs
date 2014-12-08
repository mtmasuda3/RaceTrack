using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacetrackSimulator
{
    public class Greyhound
    {
        //class variables
        public int StartingPosition; //where the picturebox should start
        public int RacetrackLength; //length of the racetrack
        public PictureBox MyPictureBox = null; //picturebox object
        public int Location = 0; //location on the racetrack
        public Random Randomizer; //random instance

        //class methods
        public bool Run()
        {
            Location = Randomizer.Next(1, 5); //move forward 1,2,3,4 spaces at random
            MyPictureBox.Left += StartingPosition + Location; //update picturebox location
            if (MyPictureBox.Left >= RacetrackLength) //return true if race is won
                return true;
            else
                return false;
        }
        public void TakeStartingPosition()
        {
            Location = 0; //set location back to 0
            MyPictureBox.Left = StartingPosition; //picturebox location back to start
        }

    }
}
