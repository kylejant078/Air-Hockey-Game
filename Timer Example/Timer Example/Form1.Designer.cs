
namespace Timer_Example
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
            this.counterOutput = new System.Windows.Forms.Label();
            this.colorOutput = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.countingTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // counterOutput
            // 
            this.counterOutput.AutoSize = true;
            this.counterOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.counterOutput.Location = new System.Drawing.Point(186, 65);
            this.counterOutput.Name = "counterOutput";
            this.counterOutput.Size = new System.Drawing.Size(65, 24);
            this.counterOutput.TabIndex = 0;
            this.counterOutput.Text = "label 1";
            // 
            // colorOutput
            // 
            this.colorOutput.BackColor = System.Drawing.Color.Teal;
            this.colorOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.colorOutput.Location = new System.Drawing.Point(170, 142);
            this.colorOutput.Name = "colorOutput";
            this.colorOutput.Size = new System.Drawing.Size(93, 74);
            this.colorOutput.TabIndex = 1;
            this.colorOutput.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // startButton
            // 
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(152, 275);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(124, 60);
            this.startButton.TabIndex = 2;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // countingTimer
            // 
            this.countingTimer.Interval = 1000;
            this.countingTimer.Tick += new System.EventHandler(this.countingTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 405);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.colorOutput);
            this.Controls.Add(this.counterOutput);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label counterOutput;
        private System.Windows.Forms.Label colorOutput;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Timer countingTimer;
    }
}

