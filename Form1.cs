using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_RacingMonsters
{
    public partial class Form1 : Form
    {
        Random myRandom = new Random();
        int gameStart = 44;
        //create an array of pictureboxes
        PictureBox[] pbx = new PictureBox[4];

        int[] yAlign = new int[] { 65, 140, 217, 284 };


        public Form1()
        {


            for (int i = 0; i < pbx.Length; i++)
            {
                pbx[i] = new PictureBox();
                pbx[i].Name = "pbBox" + i;
                pbx[i].Size = new Size(70, 77);
                pbx[i].BorderStyle = BorderStyle.FixedSingle;
                pbx[i].Location = new Point(42, yAlign[i]);
                pbx[i].Visible = true;
                pbx[i].SizeMode = PictureBoxSizeMode.StretchImage;

                this.Controls.Add(pbx[i]);
            }
            pbx[0].Image = Resource1.Ugor;
            pbx[1].Image = Resource1.Agor;
            pbx[2].Image = Resource1.Igor;
            pbx[3].Image = Resource1.Ogor;

            pbx[0].Tag = "Ugor";
            pbx[1].Tag = "Agor";
            pbx[2].Tag = "Igor";
            pbx[3].Tag = "Ogor";




            InitializeComponent();
        }

        private void btnRace_Click(object sender, EventArgs e)
        {
            var gameEnd = 624;

            bool isEnd = false;
            string winner = "";

            while (!isEnd)
            {
                for (int i = 0; i < 4; i++)
                {
                    var ran = myRandom.Next(1, 50);
                    Thread.Sleep(50);
                    pbx[i].Location = new Point(pbx[i].Location.X + ran, pbx[i].Location.Y);

                    if (pbx[i].Location.X >= gameEnd)
                    {
                        isEnd = true;
                        winner = pbx[i].Tag.ToString();
                        lblWinner.Text = winner + " is the WINNER";

                    }

                }

            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < 4; i++)
            {
                pbx[i].Location = new Point(gameStart, pbx[i].Location.Y);
            }


        }
    }
}
