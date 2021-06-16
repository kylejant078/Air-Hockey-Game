
namespace Final_Project
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.topLabel = new System.Windows.Forms.Label();
            this.timeLabel = new System.Windows.Forms.Label();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.inputPlayerName = new System.Windows.Forms.TextBox();
            this.instructionsLabel = new System.Windows.Forms.Label();
            this.enterButton = new System.Windows.Forms.Button();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.startEscapeLabel = new System.Windows.Forms.Label();
            this.highScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // topLabel
            // 
            this.topLabel.BackColor = System.Drawing.Color.Transparent;
            this.topLabel.Font = new System.Drawing.Font("OCR A Extended", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.topLabel.ForeColor = System.Drawing.Color.White;
            this.topLabel.Location = new System.Drawing.Point(147, -1);
            this.topLabel.Name = "topLabel";
            this.topLabel.Size = new System.Drawing.Size(306, 31);
            this.topLabel.TabIndex = 0;
            this.topLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timeLabel
            // 
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(2, -1);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(166, 31);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scoreLabel
            // 
            this.scoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.scoreLabel.Font = new System.Drawing.Font("OCR A Extended", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel.ForeColor = System.Drawing.Color.White;
            this.scoreLabel.Location = new System.Drawing.Point(471, -1);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(126, 31);
            this.scoreLabel.TabIndex = 2;
            this.scoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // inputPlayerName
            // 
            this.inputPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inputPlayerName.Location = new System.Drawing.Point(186, 252);
            this.inputPlayerName.Name = "inputPlayerName";
            this.inputPlayerName.Size = new System.Drawing.Size(219, 31);
            this.inputPlayerName.TabIndex = 3;
            // 
            // instructionsLabel
            // 
            this.instructionsLabel.BackColor = System.Drawing.Color.Transparent;
            this.instructionsLabel.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionsLabel.ForeColor = System.Drawing.Color.Black;
            this.instructionsLabel.Location = new System.Drawing.Point(156, 286);
            this.instructionsLabel.Name = "instructionsLabel";
            this.instructionsLabel.Size = new System.Drawing.Size(284, 31);
            this.instructionsLabel.TabIndex = 4;
            this.instructionsLabel.Text = "Enter Player Name";
            this.instructionsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // enterButton
            // 
            this.enterButton.BackColor = System.Drawing.Color.LightGreen;
            this.enterButton.FlatAppearance.BorderSize = 0;
            this.enterButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.MediumSpringGreen;
            this.enterButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enterButton.Font = new System.Drawing.Font("OCR A Extended", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enterButton.ForeColor = System.Drawing.Color.DarkGreen;
            this.enterButton.Location = new System.Drawing.Point(236, 330);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(124, 58);
            this.enterButton.TabIndex = 5;
            this.enterButton.Text = "Enter";
            this.enterButton.UseVisualStyleBackColor = false;
            this.enterButton.Click += new System.EventHandler(this.mainButton_Click);
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 20;
            this.gameTimer.Tick += new System.EventHandler(this.gameTimer_Tick);
            // 
            // startEscapeLabel
            // 
            this.startEscapeLabel.BackColor = System.Drawing.Color.Transparent;
            this.startEscapeLabel.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startEscapeLabel.ForeColor = System.Drawing.Color.Black;
            this.startEscapeLabel.Location = new System.Drawing.Point(1, 296);
            this.startEscapeLabel.Name = "startEscapeLabel";
            this.startEscapeLabel.Size = new System.Drawing.Size(592, 31);
            this.startEscapeLabel.TabIndex = 6;
            this.startEscapeLabel.Text = "Press Space to Start , or Escape to Exit";
            this.startEscapeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // highScoreLabel
            // 
            this.highScoreLabel.BackColor = System.Drawing.Color.Transparent;
            this.highScoreLabel.Font = new System.Drawing.Font("OCR A Extended", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.highScoreLabel.ForeColor = System.Drawing.Color.Gray;
            this.highScoreLabel.Location = new System.Drawing.Point(1, 327);
            this.highScoreLabel.Name = "highScoreLabel";
            this.highScoreLabel.Size = new System.Drawing.Size(592, 74);
            this.highScoreLabel.TabIndex = 7;
            this.highScoreLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Final_Project.Properties.Resources.hockey_net;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.highScoreLabel);
            this.Controls.Add(this.startEscapeLabel);
            this.Controls.Add(this.enterButton);
            this.Controls.Add(this.instructionsLabel);
            this.Controls.Add(this.inputPlayerName);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.topLabel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label topLabel;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.TextBox inputPlayerName;
        private System.Windows.Forms.Label instructionsLabel;
        private System.Windows.Forms.Button enterButton;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label startEscapeLabel;
        private System.Windows.Forms.Label highScoreLabel;
    }
}

