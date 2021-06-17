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
        //Create Global Rectangles
        Rectangle target;
        Rectangle playerAim = new Rectangle(290, 160, 20, 20);
        Rectangle puck = new Rectangle(285, 300, 30, 20);

        //Create Global Variables
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
        int counter = 0;

        //Create List to be used to hold values for highscores
        List<int> Scores = new List<int>();
        int highScore = 0;

        //Create Random Number Generator that will be used to determine random positions of the targets
        Random randGen = new Random();

        //Create Variables to be used in the Paint Event
        Pen redPen = new Pen(Color.Red, 6);
        Pen blackPen = new Pen(Color.Black, 5);
        SolidBrush whiteBrush = new SolidBrush(Color.White);
        SolidBrush blackBrush = new SolidBrush(Color.Black);

        //Create Soundplayers to be used for in game events
        SoundPlayer targetHit = new SoundPlayer();
        SoundPlayer gameEnd = new SoundPlayer();
        SoundPlayer missTarget = new SoundPlayer();

        public Form1()
        {
            InitializeComponent();
            //Initialize the Soundplayers by implementing the associated wav. sound file
            targetHit = new SoundPlayer(Properties.Resources.targetHit);
            gameEnd = new SoundPlayer(Properties.Resources.hockeyHorn);
            missTarget = new SoundPlayer(Properties.Resources.targetMiss);

            //Hide labels that are not needed yet
            highScoreLabel.Visible = false;
            startEscapeLabel.Visible = false;
            moveInstructionsLabel.Visible = false;
        }

        //Create new public void to be called when the game is starting
        public void GameInitialize()
        {
            //Initialize labels, values and variables
            timeLabel.Text = "";
            scoreLabel.Text = "";
            gameTimer.Enabled = true;
            gameState = "running";
            time = 500;
            score = 0;

            //Create random number generators responsible for chosing x and y points for the targets
            randXValue = randGen.Next(155, 400);
            randYValue = randGen.Next(66, 220);

            //create the first target rectangle
            target = new Rectangle(randXValue, randYValue, 40, 40);
            playerAim = new Rectangle(290, 160, 20, 20);

        }
        private void mainButton_Click(object sender, EventArgs e)
        {
            //Take the user input from the textbox then display and put it into a variable that holds the user's name
            playerName = inputPlayerName.Text;
            topLabel.Text = $"Welcome {playerName}!";

            //Hide buttons, textboxes and labels that aren't needed
            enterButton.Visible = false;
            inputPlayerName.Visible = false;
            instructionsLabel.Visible = false;
            startEscapeLabel.Visible = true;
            moveInstructionsLabel.Visible = true; 

            //Change game state to waiting
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
            //Add 1 to the counter each time the method repeats
            counter++;

            //Hide label that isn't needed
            startEscapeLabel.Visible = false;

            //Start counting down each time this method runs
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
                //Update puck position
                puck.X = playerAim.X - 5;
                puck.Y = playerAim.Y;
                //Pause to show puck position
                Refresh();
                Thread.Sleep(500);

                if (playerAim.IntersectsWith(target))
                {
                    //reset the counter back to 0
                    counter = 0;

                    //Play sound for hitting the target
                    targetHit.Play();

                    //Update puck position
                    puck.X = playerAim.X - 5;
                    puck.Y = playerAim.Y;

                    //Increase the score by 1 point each time a target is hit
                    score++;

                    //Collect 2 new random numbers
                    randXValue = randGen.Next(155, 413);
                    randYValue = randGen.Next(66, 220);

                    //create the new target rectangle using the 2 random numbers
                    target = new Rectangle(randXValue, randYValue, 40, 40);
                }
                else
                {
                    //Play sound for missing the target
                    missTarget.Play();

                    //reset the counter back to 0
                    counter = 0;
                }
                //Reset the player aim position
                playerAim.X = 290; 
                playerAim.Y = 160; 
            }
            if (counter == 40)
            {
                //reset the counter back to 0
                counter = 0;

                //Collect 2 new random numbers
                randXValue = randGen.Next(155, 400);
                randYValue = randGen.Next(66, 220);

                //create the new target rectangle using the 2 random numbers
                target = new Rectangle(randXValue, randYValue, 40, 40);
            }
            //check if the time equals 0
            if (time == 0)
            {
                //add highscore to the Scores list
                highScore = score;
                Scores.Add(highScore);

                //sort the Scores list so the values are in order
                Scores.Sort();

                //if the count of Scores in the list is greater than 3 then remove the one at [0]
                if (Scores.Count > 3)
                {                        
                    Scores.RemoveAt(0);
                }

                //Reverse the order of the list so the values go from highest to lowest
                Scores.Reverse();

                //Clear the label used to display the highscores so the previous value doesn't appear the next time a new final score has occured
                highScoreLabel.Text = "";
                for (int i = 0; i < Scores.Count(); i++)
                {
                    highScoreLabel.Text += $"High Scores: {playerName}: {Scores[i]}\n";
                }

                //Play game end sound
                gameEnd.Play();

                //Stop the gameTimer_Tick Method
                gameTimer.Enabled = false;

                //change gameState to over
                gameState = "over";
            }
            //Update the display and variables
            Refresh();
        }
        
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (gameState == "waiting")
            {
                //update labels
                topLabel.Text = "HOCKEY SKILLS CHALLENGE";
                startEscapeLabel.Text = "Press Space Bar to Start or Escape to Exit";
            }
            else if (gameState == "running")
            {
                //update labels
                topLabel.Text = $"{playerName}"; //shouldnt this happen earlier at top?
                timeLabel.Text = $"Time Left: {time}";
                scoreLabel.Text = $"Score: {score}";
                moveInstructionsLabel.Visible = true;

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
                //reset the counter back to 0
                counter = 0;

                //display labels that are nessescary for this gameState
                //update labels that need to be changed
                highScoreLabel.Visible = true;
                timeLabel.Text = "";
                scoreLabel.Text = $"Score: {score}";
                topLabel.Text = "GAME OVER!";
                startEscapeLabel.Visible = true;
                startEscapeLabel.Text = "Press Space Bar to Start or Escape to Exit";
            }
        }
    }
}
