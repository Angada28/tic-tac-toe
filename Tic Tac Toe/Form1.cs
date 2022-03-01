using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_Toe
{
    public partial class Form1 : Form
    {
        #region variables
        //gets filled with either x or o based on the picture box that is clicked 
        string[] checkboard = { "", "", "", "", "", "", "", "", "" };
        //used to help determine who goes next
        bool currentTurn = true;
        //used to help check for a draw
        int ctr = 0;
        Random box = new Random();
        public Form1()
        {
            InitializeComponent();
            move1();
        }
        #endregion
        //decides who goes first
        private void move1()
        {
            switch (box.Next(2))
            {
                case 0:
                    currentTurn = true;
                    MessageBox.Show("X will go first");
                    break;
                case 1:
                    currentTurn = false;
                    MessageBox.Show("O will go first");
                    break;
            }
        }
        //makes the image appear, decides who goes next and fill spot in the array
        private void clicked(object sender, EventArgs e)
        {
            PictureBox picked = (PictureBox)sender;
            char[] brokenname = picked.Name.ToCharArray();
            string fullnum = brokenname[2].ToString();
            int numinname = int.Parse(fullnum) - 1;
            switch (currentTurn)
            {
                case true:
                    picked.Image = Properties.Resources.tic_tac_toe_X;
                    picked.Enabled = false;
                    ctr++;                    
                    checkboard[numinname] = "x";
                    currentTurn = false;
                    break;
                case false:
                    picked.Image = Properties.Resources.letter_o_icon_2_256;
                    picked.Enabled = true;
                    ctr++;
                    checkboard[numinname] = "o";
                    currentTurn = true;
                    break;
            }
            WinCheck();
        }
        //checks for all 17 outcomes
        private void WinCheck()
        {
            // if x matches horizontal
            if (checkboard[0] == checkboard[1] && checkboard[1] == checkboard[2] && checkboard[2] == "x")
            {
                messagex();
            }
            else if (checkboard[3] == checkboard[4] && checkboard[4] == checkboard[5] && checkboard[5] == "x")
            {
                messagex();
            }
            else if (checkboard[6] == checkboard[7] && checkboard[7] == checkboard[8] && checkboard[8] == "x")
            {
                messagex();
            }
            //if x wins vertical
            else if (checkboard[0] == checkboard[3] && checkboard[3] == checkboard[6] && checkboard[6] == "x")
            {
                messagex();
            }
            else if (checkboard[1] == checkboard[4] && checkboard[4] == checkboard[7] && checkboard[7] == "x")
            {
                messagex();
            }
            else if (checkboard[2] == checkboard[5] && checkboard[5] == checkboard[8] && checkboard[8] == "x")
            {
                messagex();
            }
            //if x wins diagonal
            else if (checkboard[0] == checkboard[4] && checkboard[4] == checkboard[8] && checkboard[8] == "x")
            {
                messagex();
            }
            else if (checkboard[6] == checkboard[4] && checkboard[4] == checkboard[2] && checkboard[2] == "x")
            {
                messagex();
            }           
            // if o matches horizontal
            if (checkboard[0] == checkboard[1] && checkboard[1] == checkboard[2] && checkboard[2] == "o")
            {
                messageo();
            }
            else if (checkboard[3] == checkboard[4] && checkboard[4] == checkboard[5] && checkboard[5] == "o")
            {
                messageo();
            }
            else if (checkboard[6] == checkboard[7] && checkboard[7] == checkboard[8] && checkboard[8] == "o")
            {
                messageo();
            }
            //if o wins vertical
            else if (checkboard[0] == checkboard[3] && checkboard[3] == checkboard[6] && checkboard[6] == "o")
            {
                messageo();
            }
            else if (checkboard[1] == checkboard[4] && checkboard[4] == checkboard[7] && checkboard[7] == "o")
            {
                messageo();
            }
            else if (checkboard[2] == checkboard[5] && checkboard[5] == checkboard[8] && checkboard[8] == "o")
            {
                messageo();
            }
            //if o wins diagonal
            else if (checkboard[0] == checkboard[4] && checkboard[4] == checkboard[8] && checkboard[8] == "o")
            {
                messageo();
            }
            else if (checkboard[6] == checkboard[4] && checkboard[4] == checkboard[2] && checkboard[2] == "o")
            {
                messageo();
            }
            //no one wins
            else if (ctr == 9)
            {
                MessageBox.Show("no one wins"); if (MessageBox.Show("Do you want to try again?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Restart();
                }
                else
                {
                    Application.Exit();
                }
            }
        }
        private void messagex()
        {
            MessageBox.Show("x wins"); if (MessageBox.Show("Do you want to try again?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }
        private void messageo()
        {
            MessageBox.Show("O wins"); if (MessageBox.Show("Do you want to try again?", "Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Restart();
            }
            else
            {
                Application.Exit();
            }
        }
    }
}
