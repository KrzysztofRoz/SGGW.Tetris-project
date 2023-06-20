using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGGW.Tetris_Project
{
    public class Positions
    {
        public int row { get; set; }
        public int column { get; set; }
        public Positions(int row, int column)
        {
            this.row = row;
            this.column = column;
        }
    }
}
