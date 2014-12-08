using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacetrackSimulator
{
    public class Guy
    {
        //class variables
        public string Name; //guys name
        public Bet MyBet; //instance of bet that is specific to the guy
        public int Cash; //total cash

        public RadioButton MyRadioButton; //select user for betting
        public Label MyLabel; //show current bet

        //class methods
        public void UpdateLabels()
        {
            MyRadioButton.Text = Name + " has " + Cash + " bucks"; //myRadioButton to bet description
            if (MyBet == null) //mylabel to bets description
            {
                MyLabel.Text = Name + " hasn't placed a bet";
            }
            else
            {
                MyLabel.Text = Name + " bets " + MyBet.Amount + " on dog #" + MyBet.Dog;
            }
        }
        public void ClearBet() //set myBet to 0
        {
            MyBet = null;
        }
        public bool PlaceBet(int BetAmount, int DogToWin) //place bet if amount can be done and return true
        {
            if (BetAmount <= Cash)
            {
                MyBet = new Bet();
                MyBet.Amount = BetAmount;
                MyBet.Dog = DogToWin;
                return true;
            }
            else
            {
                MessageBox.Show("You don't have that much to bet.");
                return false;
            }
        }
        public void Collect(int Winner) //pay out, clear bet, update labels
        {
            if (MyBet.PayOut(Winner) > 0)
            {
                Cash += (2 * MyBet.PayOut(Winner));
            }
            else 
                Cash += MyBet.PayOut(Winner);
            ClearBet();
            UpdateLabels();
        }
    }
}
