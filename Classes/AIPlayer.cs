using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX.Classes
{
    public class AIPlayer : Player
    {
        private Random random = new Random();

        public AIPlayer(string name, char symbol) : base(name, symbol) { }

        public override (int, int) MakeMove(Board board)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.isMoveValid(i, j))
                    {
                        board.PlaceMove(i, j, Symbol);
                        if (board.CheckWin(Symbol))
                        {
                            board.PlaceMove(i, j, ' ');
                            return (i, j);
                        }
                        board.PlaceMove(i, j, ' ');
                    }
                }
            }

            char opponentSymbol = (Symbol == 'X') ? 'O' : 'X';
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board.isMoveValid(i, j))
                    {
                        board.PlaceMove(i, j, opponentSymbol);
                        if (board.CheckWin(opponentSymbol))
                        {
                            board.PlaceMove(i, j, ' ');
                            return (i, j);
                        }
                        board.PlaceMove(i, j, ' ');
                    }
                }
            }

            if (board.isMoveValid(1, 1))
            {
                return (1, 1);
            }

            int row, col;
            do
            {
                row = random.Next(3);
                col = random.Next(3);
            } while (!board.isMoveValid(row, col));

            return (row, col);
        }

    }
}
