using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Timer_Example
{
    public partial class Form1 : Form
    {
        int counter = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (countingTimer.Enabled == false)
            {
                countingTimer.Enabled = true;
                startButton.Text = "Pause";
            }
            else
            {
                countingTimer.Enabled = false;
                startButton.Text = "Start";

                
            }
        }
        private void countingTimer_Tick(object sender, EventArgs e)
        {
            counter++;
            counterOutput.Text = $"{counter}";

            //if (counter == 1)
            //{
            //    colorOutput.BackColor = Color.DarkBlue;
            //}
            //else if (counter == 2)
            //{
            //    colorOutput.BackColor = Color.LightGreen;
            //}
            //else
            //{
            //    colorOutput.BackColor = Color.DarkRed;
            //    counter = 0;
            //}
            if (counter % 3 == 0)
            {
                if (colorOutput.BackColor == Color.Teal)
                {
                    colorOutput.BackColor = Color.DarkBlue;
                }
                else if (colorOutput.BackColor == Color.DarkBlue)
                {
                    colorOutput.BackColor = Color.LightGreen;
                }
                else
                {
                    colorOutput.BackColor = Color.Teal;
                }
            }
        }
    }
}
