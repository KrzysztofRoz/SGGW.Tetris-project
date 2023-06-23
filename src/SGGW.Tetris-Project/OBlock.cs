using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGGW.Tetris_Project
{
    public class OBlock : Block
    {
        private readonly Positions[][] tiles = new Positions[][] 
        {
            new Positions[]{new Positions(0,0), new Positions(0, 1), new Positions(1, 0) , new Positions(1, 1) }
        };
        public override int Id => 3;


        protected override Positions StartOffset => new Positions(0, 4);
        protected override Positions[][] Tiles => tiles;
    }
}
