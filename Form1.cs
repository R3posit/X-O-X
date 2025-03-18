using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XOX.Classes;

namespace XOX
{
    public partial class Form1 : Form
    {
        private Game game;

        public Form1()
        {
            InitializeComponent();
            NewGame();
        }
        private void NewGame()
        {
            Player player1 = new HumanPlayer("Kerem", 'X');
            Player player2 = new AIPlayer("Bot", 'O');

            game = new Game(player1, player2);
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void Kerem(object sender, EventArgs e)
        {
            PictureBox clicked = sender as PictureBox;
            string name = clicked.Name;
            int row = int.Parse(name[10].ToString());
            int col = int.Parse(name[11].ToString());

            char symbol = game.CurrentPlayer.Symbol;

            if (!game.PlayMove(row, col))
            {
                MessageBox.Show("Geçersiz hamle!");
                return;
            }

            clicked.Image = (symbol == 'X') ?
                            Properties.Resources.XXXXX :
                            Properties.Resources.O_Logo;
            
            if (game.CheckForWin())
            {
                MessageBox.Show($"{game.CurrentPlayer.Name} kazandı!");
                NewGame();
                return;
            }
            else if (game.CheckForDraw())
            {
                MessageBox.Show("Berabere!");
                NewGame();
                return;
            }

            game.SwitchPlayer();


            if (game.CurrentPlayer is AIPlayer ai)
            {
                await Task.Delay(500);

                var (aiRow, aiCol) = ai.MakeMove(game.Board);
                string pbName = $"pictureBox{aiRow}{aiCol}";
                var pb = this.Controls[pbName] as PictureBox;

                if (pb != null)
                {
                    Kerem(pb, EventArgs.Empty);
                }   
            }
        }





    }
}
