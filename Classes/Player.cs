using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XOX.Classes
{
    public abstract class Player
    {
        public string Name { get; set; }
        public char Symbol { get; set; }

        protected Player(string name, char symbol)
        {
            Name = name;
            Symbol = symbol;
        }
        public abstract (int, int) MakeMove(Board board);
    }
}
