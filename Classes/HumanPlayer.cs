using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XOX.Classes
{
    public class HumanPlayer : Player
    {
        public HumanPlayer(string name, char symbol) : base(name, symbol) { }
        public override (int, int) MakeMove(Board board)
        {
            return (-1, -1);
        }

    }
}
