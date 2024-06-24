using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LudoGame
{
    public partial class LudoMainGame : Form
    {
        // za pochetok 2, posle ke se smeni
        int numOfPlayers = 2;
        bool diceRolled = false;
        int diceValue = 6;
        //int[] positions = new int[47];
        Player yellow;
        Player blue;
        Player green;
        Player red;
        List<Player> players = new List<Player>();
        int currentPlayerIndex = 0;
        PictureBox[] pictureBoxes = new PictureBox[47];




        public LudoMainGame()
        {
            InitializeComponent();

            AttachClickEvents();

            this.Height = this.ClientSize.Height + 80;
            start();
        }

        private void AttachClickEvents()
        {
            // Iterate through all controls in the form
            List<PictureBox> pictureBoxList = new List<PictureBox>();

            foreach (Control control in this.Controls)
            {
                // Check if the control is a PictureBox and its name matches the pattern "position" followed by a number
                if (control is PictureBox pictureBox && control.Name.StartsWith("position") && int.TryParse(control.Name.Substring(8), out _))
                {
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                    control.Click += new EventHandler(PictureBox_Click);
                    pictureBoxList.Add(pictureBox);
                }
            }
            pictureBoxes = pictureBoxList.ToArray();
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox p = (PictureBox)sender;
            if (p.Tag != null)
            {
                Piece piece = p.Tag as Piece;
                Player player = players[currentPlayerIndex];
                string color = piece.color;
                if(player.name != piece.color)
                {
                    return;
                } else
                {
                    int index = int.Parse(p.Name.Substring(8));
                   // MessageBox.Show(String.Format("{0}", index));

                    index += diceValue;
                    string tmp  = "position" + index;
                    PictureBox pictureBox = this.pictureBoxes.FirstOrDefault(x => x.Name == tmp);
                    pictureBox.Tag = piece;
                    string relativePath = @"Assets\" + color + "Piece.png";
                    pictureBox.Image = Image.FromFile(relativePath);
                    p.Tag = null;
                    p.Image = null;
                    foreach (PictureBox pb in pictureBoxes)
                    {
                        pb.Click -= PictureBox_Click;
                    }
                }
            }

        }

        public void start()
        {
            position0.Tag = new Piece("yellow");
            string rp = @"Assets\yellowPiece.png";
            position0.Image = Image.FromFile(rp);

            rp = @"Assets\bluePiece.png";

            position1.Tag = new Piece("blue");
            position1.Image = Image.FromFile(rp);
            // ova  treba da se podobri, samo za start
            if (numOfPlayers == 2)
            {
                yellow = new Player("yellow");
                string relativePath = @"Assets\yellowTilePiece.png";
                yellowHome1.Image = Image.FromFile(relativePath);
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        Piece piece = new Piece("yellow");
                        yellow.pieces.Add(piece);
                        yellowHome1.Tag = piece;
                    }
                    else if (i == 1)
                    {
                        Piece piece = new Piece("yellow");
                        yellow.pieces.Add(piece);
                        yellowHome2.Tag = piece;
                    }
                    else if (i == 2)
                    {
                        Piece piece = new Piece("yellow");
                        yellow.pieces.Add(piece);
                        yellowHome3.Tag = piece;
                    }
                    else
                    {
                        Piece piece = new Piece("yellow");
                        yellow.pieces.Add(piece);
                        yellowHome4.Tag = piece;
                    }
                }

                yellowHome2.Image = Image.FromFile(relativePath);
                yellowHome3.Image = Image.FromFile(relativePath);
                yellowHome4.Image = Image.FromFile(relativePath);
                blue = new Player("blue");
                for (int i = 0; i < 4; i++)
                {
                    if (i == 0)
                    {
                        Piece piece = new Piece("blue");
                        blue.pieces.Add(piece);
                        blueHome1.Tag = piece;
                    }
                    else if (i == 1)
                    {
                        Piece piece = new Piece("yellow");
                        blue.pieces.Add(piece);
                        blueHome2.Tag = piece;
                    }
                    else if (i == 2)
                    {
                        Piece piece = new Piece("yellow");
                        blue.pieces.Add(piece);
                        blueHome3.Tag = piece;
                    }
                    else
                    {
                        Piece piece = new Piece("yellow");
                        blue.pieces.Add(piece);
                        blueHome4.Tag = piece;
                    }
                }

                relativePath = @"Assets\blueTilePiece.png";
                blueHome1.Image = Image.FromFile(relativePath);
                blueHome2.Image = Image.FromFile(relativePath);
                blueHome3.Image = Image.FromFile(relativePath);
                blueHome4.Image = Image.FromFile(relativePath);

                players.Add(yellow);
                players.Add(blue);
            }

            ///koj mozhe da mrda

            players[currentPlayerIndex].canMove = true;
            updateUI();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LudoMainGame_Load(object sender, EventArgs e)
        {

        }
        public async void diceRoll()
        {
            Random random = new Random();

            string sPath = @"Assets\roll.wav";
            SoundPlayer player = new SoundPlayer(sPath);

            player.Play();
            int n;
            for (int i = 0; i < 6; i++)
            {
                n = random.Next(1, 7);
                await Task.Delay(50);
                diceValue = n;
                if (n == 1)
                {
                    string relativePath = @"Assets\dice1.png";

                    dice.Image = Image.FromFile(relativePath);
                }
                if (n == 2)
                {
                    string relativePath = @"Assets\dice2.png";

                    dice.Image = Image.FromFile(relativePath);
                }
                if (n == 3)
                {
                    string relativePath = @"Assets\dice3.png";

                    dice.Image = Image.FromFile(relativePath);
                }
                if (n == 4)
                {
                    string relativePath = @"Assets\dice4.png";

                    dice.Image = Image.FromFile(relativePath);

                }
                if (n == 5)
                {
                    string relativePath = @"Assets\dice5.png";

                    dice.Image = Image.FromFile(relativePath);
                }
                if (n == 6)
                {
                    string relativePath = @"Assets\dice6.png";

                    dice.Image = Image.FromFile(relativePath);
                }
            }
        }

        private void pictureBox69_Click(object sender, EventArgs e)
        {
            diceRoll();

        }
        //public void nextPlayer()
        //{
        //    currentPlayerIndex = (currentPlayerIndex + 1) % players.Count;
        //    players[currentPlayerIndex].canMove = true;
        //    updateUI();
        //}
        public void updateUI()
        {
            Player player = players[currentPlayerIndex];
            if(player.name == "yellow")
            {
                yellowBar.Value = 100;
                blueBar.Value = 0;
            } else if(player.name == "blue")
            {
                blueBar.Value = 100;
                yellowBar.Value = 0;
            }
        }

        private void endTurnBtn_Click(object sender, EventArgs e)
        {
            currentPlayerIndex++;
            if (currentPlayerIndex == 2)
            {
                currentPlayerIndex = 0;
            }
            AttachClickEvents();
            updateUI();
        }
    }
}
