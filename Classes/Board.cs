using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace XOX.Classes
{
    public class Board
    {
        public char[,] grid = new char[3, 3];

        public Board() => Reset();

        // Tahtayı Sıfırlıyorum \\
        public void Reset()
        {
            for(int i = 0; i < 3; i++)
            {
                for(int k = 0; k < 3; k++)
                {
                    grid[i, k] = ' ';
                }
            }
        }

        // Geçerli Hamle Kontrolü \\ bool
        public bool isMoveValid(int x, int y) => grid[x, y] == ' ';

        // Hareketi Gerçekleştiriyorum \\
        public void PlaceMove(int x, int y, char symbol) => grid[x, y] = symbol;

        // Kazanan Kontrolü \\ bool
        public bool CheckWin(char symbol)
        {
            for(int i = 0; i < 3; i++)
            {
                if (grid[i, 0] == symbol && grid[i, 1] == symbol && grid[i, 2] == symbol || grid[0, i] == symbol && grid[1, i] == symbol && grid[2, i] == symbol)
                {
                    return true;
                }

            }

            return (grid[0, 0] == symbol && grid[1, 1] == symbol && grid[2, 2] == symbol || grid[2, 0] == symbol && grid[1, 1] == symbol && grid[0, 2] == symbol);

        }

        // bool 
        public bool isFull()
        {
            foreach(var hucre in grid)
            {
                if (hucre == ' ') return false;
            }

            return true;
        }



    }
}
