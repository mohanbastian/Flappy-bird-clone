using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_bird_clone
{
    public partial class Form1 : Form
    {
        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;




        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            theBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            ScoreText.Text = "Score: " + score.ToString();

            if (pipeBottom.Left < -150)
            {
                pipeBottom.Left = 1200;
                score++;
            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 1350;
                score++;
            }

            if (theBird.Bounds.IntersectsWith(pipeBottom.Bounds) || theBird.Bounds.IntersectsWith(pipeTop.Bounds)||
                theBird.Bounds.IntersectsWith(ground.Bounds) || theBird.Top < -25)
            {
                endGame();
            }
        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 10;
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = -10;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            ScoreText.Text += "\n Game Over!!!";
        }
    }
}
