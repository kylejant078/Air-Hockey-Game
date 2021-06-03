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

namespace Flowchart_Program
{
    public partial class FlowchartProgam : Form
    {
        public FlowchartProgam()
        {
            InitializeComponent();
            outputLabel.Visible = false;
            exitButton.Visible = false;
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            startButton.Visible = false;
            this.BackColor = Color.Black;
            outputLabel.Visible = true;
            outputLabel.Text = "Hello World";
            Refresh();
            Thread.Sleep(3000);
            this.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(1000);
            this.BackColor = Color.Black;
            Refresh();
            Thread.Sleep(1000);
            this.BackColor = Color.Red;
            Refresh();
            Thread.Sleep(1000);
            this.BackColor = Color.Black;
            Refresh();
            Thread.Sleep(1000);
            outputLabel.Text = "Press the exit button";
            exitButton.Visible = true;

        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            exitButton.Visible = false;
            outputLabel.Text = "Good Bye";
            Refresh();
            Thread.Sleep(2500);
            Application.Exit();
        }
    }
}
