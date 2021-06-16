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
using System.Media;


namespace Final_Project
{
    public partial class Form1 : Form
    {
        
        //List<Rectangle> player = new List<Rectangle>();
        Rectangle target;

        Rectangle playerAim = new Rectangle(290, 160, 20, 20);
        Rectangle puck = new Rectangle(285, 300, 30, 20);
        int playerAimSpeed = 5;
        string playerName;
        bool wDown = false;
        bool sDown = false;
        bool aDown = false;
        bool dDown = false;
        bool enterDown = false;
        string gameState = "waiting";
        int score = 0;
        int time = 500;
        int randXValue = 0;
        int randYValue = 0;
        List<int> Scores = new List<int>();
        int highScore = 0;
       
        Random randGen = new Random();

        Pen redPen = new Pen(Color.Red, 6);
        Pen blackPen = new Pen(Color.Black, 5);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);
        SoundPlayer targetHit = new SoundPlayer();
        SoundPlayer gameEnd = new SoundPlayer();
        SoundPlayer missTarget = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            //Rectangle playerStart = new Rectangle(285, 300, 30, 20);
            //player.Add(puck);
            targetHit = new SoundPlayer(Properties.Resources.targetHit);
            gameEnd = new SoundPlayer(Properties.Resources.hockeyHorn);
            missTarget = new SoundPlayer(Properties.Resources.targetMiss);
            highScoreLabel.Visible = false;
            startEscapeLabel.Visible = false;
        }

        public void GameInitialize()
        {
            timeLabel.Text = "";
            scoreLabel.Text = "";
            gameTimer.Enabled = true;
            gameState = "running";
            time = 500;
            score = 0;

            randXValue = randGen.Next(155, 413);
            randYValue = randGen.Next(66, 220);
            //create the target rectangle
            target = new Rectangle(randXValue, randYValue, 40, 40);

        }
        private void mainButton_Click(object sender, EventArgs e)
        {
            playerName = inputPlayerName.Text;
            topLabel.Text = $"Welcome {playerName}!";
            enterButton.Visible = false;
            inputPlayerName.Visible = false;
            instructionsLabel.Visible = false;
            startEscapeLabel.Visible = true;
            gameState = "waiting";
            this.Focus();
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
                case Keys.Space:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        GameInitialize();
                    }
                    break;
                case Keys.Escape:
                    if (gameState == "waiting" || gameState == "over")
                    {
                        Application.Exit();
                    }
                    break;
                case Keys.Enter:
                    enterDown = true;
                    break;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
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
                case Keys.Enter:
                    enterDown = false;
                    break;
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            
            startEscapeLabel.Visible = false;
            time--;

            //move the player aim
            if (aDown == true && playerAim.X > 0)
            {
                playerAim.X -= playerAimSpeed;
            }
            if (dDown == true && playerAim.X < 580)
            {
                playerAim.X += playerAimSpeed;
            }
            if (wDown == true && playerAim.Y > 0)
            {
                playerAim.Y -= playerAimSpeed;
            }
            if (sDown == true && playerAim.Y < 380)
            {
                playerAim.Y += playerAimSpeed;
            }
            //check for collision with target and puck
            
            if (enterDown == true)
            {
                puck.X = playerAim.X - 5;
                puck.Y = playerAim.Y;
                Refresh();
                Thread.Sleep(500);

                if (playerAim.IntersectsWith(target))
                {
                    targetHit.Play();
                    puck.X = playerAim.X - 5;
                    puck.Y = playerAim.Y;

                    score++;
                    //player.Remove(puck);
                    //player.Add(puck);
                    randXValue = randGen.Next(155, 413);
                    randYValue = randGen.Next(66, 220);
                    //create the target rectangle
                    target = new Rectangle(randXValue, randYValue, 40, 40);
                    //puck.X = 285;
                    //puck.Y = 300;
                    //playerAim.X = 290;
                    //playerAim.Y = 160;
                }
                else
                {
                    missTarget.Play();
                }


                
                playerAim.X = 290; ///why does this not work ?
                playerAim.Y = 160; ///when commented out, the missed shots wont be repositioned, when uncommented
                                   ///target hits wont register properly
         
            }
            //reset puck and player aim positions

            //if (playerAim.IntersectsWith(target) && enterDown == true)
            //{ 
            //    targetHit.Play();
            //    puck.X = playerAim.X - 5;
            //    puck.Y = playerAim.Y;
               
            //    score++;
            //    //player.Remove(puck);
            //    //player.Add(puck);
            //    randXValue = randGen.Next(155, 413);
            //    randYValue = randGen.Next(66, 220);
            //    //create the target rectangle
            //    target = new Rectangle(randXValue, randYValue, 40, 40);
            //    //puck.X = 285;
            //    //puck.Y = 300;
            //    playerAim.X = 290;
            //    playerAim.Y = 160;
            //}
            //check if the time equals 0
            if (time == 0)
            {
                
                // add highscore to the Scores list
                highScore = score;
                Scores.Add(highScore);
                // sort the Scores list
                Scores.Sort();
                // if the count of Scores is greater than 3 remove the one at [0]
                if (Scores.Count > 3)
                {                        
                    Scores.RemoveAt(0);
                }
                
                gameEnd.Play();
                gameTimer.Enabled = false;
                gameState = "over";
            }
            
            Refresh();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                topLabel.Text = "HOCKEY SKILLS CHALLENGE";

                startEscapeLabel.Text = "Press Space Bar to Start or Escape to Exit";
            }
            else if (gameState == "running")
            {
                //update labels
                topLabel.Text = $"{playerName}"; //shouldnt this happen earlier at top?
                timeLabel.Text = $"Time Left: {time}";
                scoreLabel.Text = $"Score: {score}";
                //draw targets
                e.Graphics.FillEllipse(whiteBrush, randXValue, randYValue, 40, 40);
                e.Graphics.DrawEllipse(redPen, randXValue, randYValue, 40, 40);
                e.Graphics.DrawEllipse(redPen, randXValue + 10, randYValue + 10, 20, 20);
                //draw the aiming target
                e.Graphics.FillEllipse(whiteBrush, playerAim);
                e.Graphics.DrawEllipse(blackPen, playerAim);
                
                //draw puck
                e.Graphics.FillRectangle(blackBrush, puck);
                puck.X = 285;
                puck.Y = 300;

                highScoreLabel.Visible = false;
            }
            else if (gameState == "over")
            {
                highScoreLabel.Visible = true;
                timeLabel.Text = "";
                scoreLabel.Text = $"Score: {score}";
                topLabel.Text = "GAME OVER!";
                startEscapeLabel.Visible = true;
                startEscapeLabel.Text = "Press Space Bar to Start or Escape to Exit";

                //create a for loop to show all the scores in Scores list. tip /n
                for (int i = 0; i < Scores.Count(); i++)
                {
                    //highScoreLabel.Text += $"High Scores: {playerName}: {highScore}\n";
                    highScoreLabel.Text += $"High Scores: {playerName}: {Scores[i]}\n"; ///????? y?
                }
            }
        }
    }
}
