namespace SnakeGameLozaTadesse
{
    partial class GameForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newGameTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.scoreTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.timeTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.GameScreen = new System.Windows.Forms.Panel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.foodTimer = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newGameTSMI,
            this.aboutTSMI,
            this.toolStripMenuItem1,
            this.scoreTSMI,
            this.timeTSMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1080, 49);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newGameTSMI
            // 
            this.newGameTSMI.BackColor = System.Drawing.Color.White;
            this.newGameTSMI.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newGameTSMI.Name = "newGameTSMI";
            this.newGameTSMI.Size = new System.Drawing.Size(93, 43);
            this.newGameTSMI.Text = "New Game";
            this.newGameTSMI.Click += new System.EventHandler(this.newGameTSMI_Click);
            // 
            // aboutTSMI
            // 
            this.aboutTSMI.BackColor = System.Drawing.Color.White;
            this.aboutTSMI.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutTSMI.Name = "aboutTSMI";
            this.aboutTSMI.Size = new System.Drawing.Size(58, 43);
            this.aboutTSMI.Text = "Score";
            this.aboutTSMI.Click += new System.EventHandler(this.aboutTSMI_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.BackColor = System.Drawing.Color.White;
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(184, 43);
            this.toolStripMenuItem1.Text = " |                                       ";
            // 
            // scoreTSMI
            // 
            this.scoreTSMI.AutoSize = false;
            this.scoreTSMI.BackColor = System.Drawing.Color.White;
            this.scoreTSMI.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreTSMI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.scoreTSMI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scoreTSMI.Name = "scoreTSMI";
            this.scoreTSMI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.scoreTSMI.Size = new System.Drawing.Size(105, 28);
            this.scoreTSMI.Text = "Score: 0";
            this.scoreTSMI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.scoreTSMI.ToolTipText = "The current score you have.";
            // 
            // timeTSMI
            // 
            this.timeTSMI.AutoSize = false;
            this.timeTSMI.BackColor = System.Drawing.Color.White;
            this.timeTSMI.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeTSMI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.timeTSMI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timeTSMI.Name = "timeTSMI";
            this.timeTSMI.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.timeTSMI.Size = new System.Drawing.Size(263, 28);
            this.timeTSMI.Text = "Time Survived: 0 seconds";
            this.timeTSMI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.timeTSMI.ToolTipText = "The time you have survived in this game.";
            // 
            // GameScreen
            // 
            this.GameScreen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.GameScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameScreen.Location = new System.Drawing.Point(0, 49);
            this.GameScreen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.GameScreen.Name = "GameScreen";
            this.GameScreen.Size = new System.Drawing.Size(1080, 677);
            this.GameScreen.TabIndex = 1;
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timerTick);
            // 
            // foodTimer
            // 
            this.foodTimer.Tick += new System.EventHandler(this.foodTimerTick);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 726);
            this.Controls.Add(this.GameScreen);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Snake Game";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormGame_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newGameTSMI;
        private System.Windows.Forms.ToolStripMenuItem aboutTSMI;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem scoreTSMI;
        private System.Windows.Forms.Panel GameScreen;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem timeTSMI;
        private System.Windows.Forms.Timer foodTimer;
    }
}

