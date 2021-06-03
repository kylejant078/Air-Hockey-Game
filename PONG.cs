using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace PONG
{
    public partial class Form1 : Form
    {
        //global variables
        Rectangle player1 = new Rectangle(10, 150, 10, 60);
        Rectangle player2 = new Rectangle(10, 220, 10, 60);
        Rectangle ball = new Rectangle(295, 195, 10, 10);

        int PlayerTurn = 1;

        int player1Score = 0;
        int player2Score = 0;

        int playerSpeed = 5;
        int ballXSpeed = -8;
        int ballYSpeed = 8;

        bool wDown = false;
        bool sDown = false;
        bool upArrowDown = false;
        bool downArrowDown = false;

        bool aDown = false;
        bool dDown = false;
        bool leftDown = false;
        bool rightDown = false;

        Pen whitePen = new Pen(Color.White, 3);

        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush whiteBrush = new SolidBrush(Color.White);

        //Create soundplayers for each sound to be used later
        SoundPlayer playerHit = new SoundPlayer();
        SoundPlayer playerScore = new SoundPlayer();
        SoundPlayer playerWin = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            //Set up the soundplayers and have them loaded so they are ready to be used later
            playerHit = new SoundPlayer(Properties.Resources.pingPongHit);
            playerScore = new SoundPlayer(Properties.Resources.pongScoreSound);
            playerWin = new SoundPlayer(Properties.Resources.winSound);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //create key down events
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = true;
                    break;
                case Keys.S:
                    sDown = true;
                    break;
                case Keys.A:
                    aDown = true;
                    break;
                case Keys.D:
                    dDown = true;
                    break;
                case Keys.Up:
                    upArrowDown = true;
                    break;
                case Keys.Down:
                    downArrowDown = true;
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
            //create key up events
            switch (e.KeyCode)
            {
                case Keys.W:
                    wDown = false;
                    break;
                case Keys.S:
                    sDown = false;
                    break;
                case Keys.A:
                    aDown = false;
                    break;
                case Keys.D:
                    dDown = false;
                    break;
                case Keys.Up:
                    upArrowDown = false;
                    break;
                case Keys.Down:
                    downArrowDown = false;
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
            //move ball
            ball.X += ballXSpeed;
            ball.Y += ballYSpeed;

            //move players
            if (wDown == true && player1.Y > 0)
            {
                player1.Y -= playerSpeed;
            }

            if (sDown == true && player1.Y < this.Height - player1.Height)
            {
                player1.Y += playerSpeed;
            }

            if (aDown == true && player1.X > 0)
            {
                player1.X -= playerSpeed;
            }

            if (dDown == true && player1.X < this.Width - player1.Width)
            {
                player1.X += playerSpeed;
            }

            if (upArrowDown == true && player2.Y > 0)
            {
                player2.Y -= playerSpeed;
            }

            if (downArrowDown == true && player2.Y < this.Height - player2.Height)
            {
                player2.Y += playerSpeed;
            }

            if (leftDown == true && player2.X > 0)
            {
                player2.X -= playerSpeed;
            }

            if (rightDown == true && player2.X < this.Width - player2.Width)
            {
                player2.X += playerSpeed;
            }

            //ball collision with top and bottom walls
            if (ball.Y < 0 || ball.Y > this.Height - ball.Height)
            {
                ballYSpeed *= -1; // or: ballYSpeed = -ballYSpeed;
            }

            //ball collision with player
            if (player1.IntersectsWith(ball) && ballXSpeed == -8 && PlayerTurn == 1)
            {
                playerHit.Play(); //edit length
                ballXSpeed *= -1;
                ball.X = player1.X + ball.Width;
                PlayerTurn = 2;
            }
            else if (player2.IntersectsWith(ball) && ballXSpeed == -8 && PlayerTurn == 2)
            {
                playerHit.Play();
                ballXSpeed *= -1;
                ball.X = player2.X + ball.Width;
                PlayerTurn = 1;
            }

            //ball collision with right wall
            if (ball.X > this.Width - ball.Width)
            {
                ballXSpeed *= -1;
            }

                //check for point scored 
                if (ball.X < 0 && PlayerTurn == 1)
                {
                player2Score++;
                p2ScoreLabel.Text = $"{player2Score}";
                playerScore.Play();

                ball.X = 295;
                ball.Y = 195;
                ballXSpeed = 8;

                player1.X = 10;
                player2.X = 10;
                
                player1.Y = 150;
                player2.Y = 220;
                }
                else if (ball.X < 0 && PlayerTurn == 2)
            {
                player1Score++;
                p1ScoreLabel.Text = $"{player1Score}";
                playerScore.Play();

                ball.X = 295;
                ball.Y = 195;
                ballXSpeed = 8;

                player1.X = 10;
                player2.X = 10;

                player1.Y = 150;
                player2.Y = 220;
            }
                
                //check for game over
                if (player1Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 1 Wins!!";
                playerWin.Play();
            }
            else if (player2Score == 3)
            {
                gameTimer.Enabled = false;
                winLabel.Visible = true;
                winLabel.Text = "Player 2 Wins!!";
                playerWin.Play();
            }
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);
            e.Graphics.FillRectangle(whiteBrush, ball);
            if (PlayerTurn == 1)
            {
                e.Graphics.DrawRectangle(whitePen, player1);
            }
            else if (PlayerTurn == 2)
            {
                e.Graphics.DrawRectangle(whitePen, player2);
            }
        }
    }
}
