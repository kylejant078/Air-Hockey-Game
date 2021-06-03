using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading; //allows the use of Thread.Sleep() 
using System.Media; //allows the use of SoundPlayer 
namespace BruceNuclearProgram
{
    public partial class BruceNuclear : Form
    {
        public BruceNuclear()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //create a sound player and load the alert.wav sound, then play it
            SoundPlayer alertPlayer = new SoundPlayer(Properties.Resources.alert);
            alertPlayer.Play();

            //put code here
            label5.BackColor = Color.Red;
            reactor2StateLabel.BackColor = Color.Red;

            //change message in output label
            label6.Text = "Meltdown Imminent";

            //show changes and then pause
            Refresh();
            Thread.Sleep(1000);

            //change the colour of state labels to white
            label5.BackColor = Color.White;
            reactor2StateLabel.BackColor = Color.White;

            //show changes and then pause
            Refresh();
            Thread.Sleep(1000);

            //change the font and backgroud colours of the output label
            label5.BackColor = Color.Red;
            reactor2StateLabel.BackColor = Color.Red;

            //redraw the screen to show updates then pause for 1 second
            Refresh();
            Thread.Sleep(1000);




        }

        private void BruceNuclear_Load(object sender, EventArgs e)
        {

        }
    }
}
