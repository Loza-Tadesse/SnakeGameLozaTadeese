using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnakeGameLozaTadesse
{
    public partial class GameForm : Form
    {
        public GameForm()
        { 
            InitializeComponent();
            game = new Game(ref GameScreen, ref scoreTSMI, ref timeTSMI, ref timer, ref foodTimer);
        }

        Game game;

        private void newGameTSMI_Click(object sender, EventArgs e)
        {
            game.New();
        }

        private void timerTick(object sender, EventArgs e)
        {
            game.Tick();
        }

        private void foodTimerTick(object sender, EventArgs e)
        {
            game.SpawnFood();
        }

        private void FormGame_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left: game.SetPlayerDirection(1); break;
                case Keys.Right: game.SetPlayerDirection(2); break;
                case Keys.Up: game.SetPlayerDirection(3); break;
                case Keys.Down: game.SetPlayerDirection(4); break;
            }

        }

        private void aboutTSMI_Click(object sender, EventArgs e)
        {
            Form Score = new ScoreBoard();
            Score.Show();
            this.Hide();
        }
    }
}
