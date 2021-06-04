using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dodge_Game
{
    public partial class Form1 : Form
    {
        Rectangle hero = new Rectangle(10, 190, 20, 20);
        int heroSpeed = 5;
        List<Rectangle> leftObstacles = new List<Rectangle>();
        List<Rectangle> rightObstacles = new List<Rectangle>();
        int leftObstacleSpeed = 8;
        int rightObstacleSpeed = 8;
        int leftCounter = 0;
        int rightCounter = 0;
        bool leftDown = false;
        bool rightDown = false;
        bool upDown = false;
        bool downDown = false;
        SolidBrush goldBrush = new SolidBrush(Color.Gold);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        public Form1()
        {
            InitializeComponent();
            //Initialize new rectangles at the appropriate starting points for left and right obstacles
            Rectangle leftObstacle = new Rectangle(200, 0, 20, 60);
            Rectangle rightObstacle = new Rectangle(400, 340, 20, 60);
            //Add these new rectangles to the globally created obstacle lists 
            leftObstacles.Add(leftObstacle);
            rightObstacles.Add(rightObstacle);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //create key down cases
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = true;
                    break;
                case Keys.Down:
                    downDown = true;
                    break;
                case Keys.Left:
                    leftDown = true;
                    break;
                case Keys.Right:
                    rightDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            //craete key up cases
            switch (e.KeyCode)
            {
                case Keys.Up:
                    upDown = false;
                    break;
                case Keys.Down:
                    downDown = false;
                    break;
                case Keys.Left:
                    leftDown = false;
                    break;
                case Keys.Right:
                    rightDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            //Add 1 to counter every time this void is run
            leftCounter++;
            //If counter is divisible by 18 and has a remainder of 0 then run this code
            if (leftCounter % 18 == 0)
            {
                Rectangle leftObstacle = new Rectangle(200, 0, 20, 60);
                leftObstacles.Add(leftObstacle);
            }
            //Add 1 to counter every time this void is run
            rightCounter++;
            //If counter is divisible by 18 and has a remainder of 0 then run this code
            if (rightCounter % 18 == 0)
            {
                Rectangle rightObstacle = new Rectangle(400, 340, 20, 60);
                rightObstacles.Add(rightObstacle);
            }
            //move hero based on key(s) pressed down
            if (upDown == true && hero.Y > 0)
            {
                hero.Y -= heroSpeed;
            }
            if (downDown == true && hero.Y < this.Height - hero.Height)
            {
                hero.Y += heroSpeed;
            }
            if (leftDown == true && hero.X > 0)
            {
                hero.X -= heroSpeed;
            }
            if (rightDown == true && hero.X < this.Width - hero.Width)
            {
                hero.X += heroSpeed;
            }
            //move the obstacles
            for (int i = 0; i < leftObstacles.Count(); i++)
            {
                //find the new position of y based on speed
                int y = leftObstacles[i].Y + leftObstacleSpeed;
                //replace the rectangle in the list with updated one using new y
                leftObstacles[i] = new Rectangle(leftObstacles[i].X, y, 20, 60);
            }
            for (int i = 0; i < rightObstacles.Count(); i++)
            {
                //find the new position of y based on speed
                int y = rightObstacles[i].Y - rightObstacleSpeed;
                //replace the rectangle in the list with updated one using new y
                rightObstacles[i] = new Rectangle(rightObstacles[i].X, y, 20, 60);
            }
            //remove obstacles that have hit the ground
            for (int i = 0; i < leftObstacles.Count(); i++)
            {
                if (leftObstacles[i].Y > this.Height + 60)
                {
                    leftObstacles.RemoveAt(i);
                }
            }
            //remove obstacles that have hit the top
            for (int i = 0; i < rightObstacles.Count(); i++)
            {
                if (rightObstacles[i].Y < 0 - 60)
                {
                    rightObstacles.RemoveAt(i);
                }
            }
            //check for collisions between hero and  left obstacles
            for (int i = 0; i < leftObstacles.Count(); i++)
            {
                if (hero.IntersectsWith(leftObstacles[i]))
                {
                    //if contact is made with a obstacle then stop the gameTimer event
                    gameTimer.Enabled = false;
                }
            }
            //check for collisions between hero and  right obstacles
            for (int i = 0; i < rightObstacles.Count(); i++)
            {
                if (hero.IntersectsWith(rightObstacles[i]))
                {
                    //if contact is made with a obstacle then stop the gameTimer event
                    gameTimer.Enabled = false;
                }
            }
            //check for a successful finish (making it to the right wall)
            if (hero.X >= this.Width - hero.Width)
            {
                gameTimer.Enabled = false;
            }
            //Update and display all new values
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //draw hero
            e.Graphics.FillRectangle(goldBrush, hero);
            //fill all rectangles from leftObstacles list
            for(int i = 0; i < leftObstacles.Count(); i++)
            {
                e.Graphics.FillRectangle(whiteBrush, leftObstacles[i]);
            }
            //fill all rectangles from rightObstacles list
            for (int i = 0; i < rightObstacles.Count(); i++)
            {
                e.Graphics.FillRectangle(whiteBrush, rightObstacles[i]);
            }
        }
    }
}
