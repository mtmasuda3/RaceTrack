using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacetrackSimulator
{
    public partial class Form1 : Form
    {
        //array for guy and greyhound objects
        Guy[] GuyArray = new Guy[3];
        Greyhound[] GreyhoundArray = new Greyhound[4];
        Random MyRandomizer = new Random();
        

        public Form1()
        {
            //initialize all three guy objects and 4 greyhound objects
            InitializeComponent();
            GuyArray[0] = new Guy()
            {
                Name = "Joe",
                MyBet = null,
                Cash = 50,
                MyRadioButton = joeRadioButton,
                MyLabel = joeBetLabel,
            };

            GuyArray[1] = new Guy()
            {
                Name = "Bob",
                MyBet = null,
                Cash = 75,
                MyRadioButton = bobRadioButton,
                MyLabel = bobBetLabel,
            };

            GuyArray[2] = new Guy()
            {
                Name = "Al",
                MyBet = null,
                Cash = 45,
                MyRadioButton = alRadioButton,
                MyLabel = alBetLabel,
            };

            for (int i = 0; i < GuyArray.Length; i++)
            {
                GuyArray[i].ClearBet();
                GuyArray[i].UpdateLabels();
            }
            GreyhoundArray[0] = new Greyhound()
            {
                MyPictureBox = pictureBox2,
                StartingPosition = pictureBox2.Left,
                RacetrackLength = 700 - pictureBox2.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[1] = new Greyhound()
            {
                MyPictureBox = pictureBox3,
                StartingPosition = pictureBox3.Left,
                RacetrackLength = 700 - pictureBox3.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[2] = new Greyhound()
            {
                MyPictureBox = pictureBox4,
                StartingPosition = pictureBox4.Left,
                RacetrackLength = 700 - pictureBox4.Width,
                Randomizer = MyRandomizer
            };

            GreyhoundArray[3] = new Greyhound()
            {
                MyPictureBox = pictureBox5,
                StartingPosition = pictureBox5.Left,
                RacetrackLength = 700 - pictureBox5.Width,
                Randomizer = MyRandomizer
            };

            
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }
        //set radio button names for bet line
        private void joeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bettorName.Text = "Joe"; 
        }

        private void bobRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bettorName.Text = "Bob"; 
        }

        private void alRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            bettorName.Text = "Al"; 
        }
        //for bet line
        private void betButton_Click(object sender, EventArgs e)
        {
            foreach (Guy p in GuyArray)
            {
                if (p.MyRadioButton.Checked == true)
                {
                    p.PlaceBet((int)betUpDown.Value, (int)dogNumberUpDown.Value);
                    p.UpdateLabels();
                    break;
                }
            }
        }
        //race button
        private void button1_Click(object sender, EventArgs e)
        {
            bool betCheck = true;
            foreach (Guy p in GuyArray)
            {
                if (p.MyBet == null)
                {
                    betCheck = false;
                    break;
                }
            }

            if (!betCheck)
            {
                MessageBox.Show("Everyone needs to place a bet.");
            }
            else
            {
                timer1.Start();
            } 
        }
        //timer 
        private void timer1_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < GreyhoundArray.Length; i++)
            {
                GreyhoundArray[i].Run();
                if (GreyhoundArray[i].Run() == true)
                {
                    timer1.Stop();
                    MessageBox.Show(string.Format("greyhound {0} is the winner!", i + 1));
                    foreach (Guy p in GuyArray)
                    {
                        p.Collect(i + 1);
                    }
                    foreach (Greyhound dog in GreyhoundArray)
                    {
                        dog.TakeStartingPosition();
                    }
                    break;
                }


            }
        }
    }
}
