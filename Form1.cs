using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PongClone
{
    public partial class Form1 : Form
    {
        public int horizontal_speed = 4;
        public int vertical_speed = 4;
        public int points = 0;
        
        public void Restart()
        {
            ball.Top = 50;
            ball.Left = 50;
            horizontal_speed = 4;
            vertical_speed = 4;
            points = 0;
            points_lbl.Text = "0";
            gametimer.Enabled = true;
            gameover_lbl.Visible = false;
        }
        public Form1()
        {
            Cursor.Hide();
            InitializeComponent();

            gametimer.Enabled = true;


            this.FormBorderStyle = FormBorderStyle.None;
            this.TopMost = true;
            this.Size = new Size(1400, 1000);
            //this.Bounds = Screen.PrimaryScreen.Bounds;
            racket.Top = playground.Bottom - (playground.Bottom / 10);

            gameover_lbl.Left = (playground.Width / 2) - (gameover_lbl.Width / 2);
            gameover_lbl.Top = (playground.Height / 2) - (gameover_lbl.Height / 2);
            gameover_lbl.Visible = false;

        }

        private void gametimer_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2);

            ball.Left += horizontal_speed;
            ball.Top += vertical_speed;

            if (ball.Bottom >= racket.Top && ball.Top <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                Random random = new Random();
                playground.BackColor = Color.FromArgb(random.Next(150, 255), random.Next(150, 255), random.Next(150, 255));

                if (vertical_speed <= 15 && horizontal_speed <= 15)
                {
                    vertical_speed += 2;
                    horizontal_speed += 2;
                }
                
                vertical_speed = -vertical_speed;
                points++;
                points_lbl.Text = points.ToString();
            }
            if (ball.Left <= playground.Left)
            {
                horizontal_speed = -horizontal_speed;
            }
            if (ball.Right >= playground.Right)
            {
                horizontal_speed = -horizontal_speed;
            }
            if (ball.Top <= playground.Top)
            {
                vertical_speed = -vertical_speed;
            }
            if (ball.Bottom >= playground.Bottom)
            {
                gameover_lbl.Visible = true;
                gametimer.Enabled = false;
            }

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape) { this.Close(); }
            if (e.KeyCode == Keys.R) { Restart(); }
        }
    }
}
