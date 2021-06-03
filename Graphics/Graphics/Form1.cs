using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicsExamples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Text = "Graphics Examples";
                
            Graphics g = this.CreateGraphics();
            Pen redPen = new Pen(Color.Red, 10);
            SolidBrush bluebrush = new SolidBrush(Color.Blue);
            Font drawFont = new Font("Arial", 16);

            g.Clear(Color.White);

            g.DrawLine(redPen, 0, 0, 100, 100);

            g.DrawRectangle(redPen, 30, 30, 100, 200);
            g.FillRectangle(bluebrush, 30, 30, 100, 200);

            g.DrawEllipse(redPen, 25, 25, 200, 100);
            g.FillEllipse(bluebrush, 25, 25, 100, 200);

            g.DrawArc(redPen, 250, 20, 50, 50, 30, 300);
            g.DrawPie(redPen, 250, 20, 50, 50, 120, 300);
            g.FillPie(bluebrush, 250, 20, 50, 50, 120, 300);

            g.DrawString("Begin", drawFont, bluebrush, 50, 300);

        }
    }
}
