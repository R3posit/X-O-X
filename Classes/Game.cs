using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace XOX.Classes
{
    public class Game
    {
        public Board Board { get; }
        public Player Player1 { get; }
        public Player Player2 { get; }
        public Player CurrentPlayer { get; private set; }
        public Game(Player player1, Player player2)
        {
            Player1 = player1;
            Player2 = player2;
            Board = new Board();
            CurrentPlayer = Player1;
        }

        public bool PlayMove(int x, int y)
        {
            if(!Board.isMoveValid(x, y)) return false;

            Board.PlaceMove(x, y, CurrentPlayer.Symbol);
            return true;
        }

        public bool CheckForWin() => Board.CheckWin(CurrentPlayer.Symbol);

        public bool CheckForDraw() => Board.isFull();

        public void SwitchPlayer()
        {
            CurrentPlayer = (CurrentPlayer == Player1) ? Player2 : Player1;
        }


    }
}
