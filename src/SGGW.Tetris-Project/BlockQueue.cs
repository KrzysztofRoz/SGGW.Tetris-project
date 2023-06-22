using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SGGW.Tetris_Project
{
    /*
    public class MistakeBlockQueue
    {
        //Iblock inherits properties of Block class 
        public class IBlock : Block
        {
            private readonly Positions[][] tiles = new Positions[][]
            {
                new Positions[] { new(1,0), new(1,1), new(1,2), new(1,3)  },
                new Positions[] { new(0,2), new(1,2), new(2,2), new(3,2)  },
                new Positions[] { new(2,0), new(2,1), new(2,2), new(2,3)  },
                new Positions[] { new(0,1), new(1,1), new(2,1), new(3,1)  }
            };
            //index for conjuring this block
            public override int id => 1;
            protected override Positions StartOffset => new Positions(-1, 3);
            protected override Positions[][] Tiles => tiles;
        }

        public class JBlock : Block
        {
            private readonly Positions[][] tiles = new Positions[][]
            {
                new Positions[] { new(0,0), new(1,0), new(1,1), new(1,2)  },
                new Positions[] { new(0,1), new(0,2), new(1,1), new(2,1)  },
                new Positions[] { new(1,0), new(1,1), new(1,2), new(2,2)  },
                new Positions[] { new(0,1), new(1,1), new(2,0), new(2,1)  }
            };
            public override int id => 2;
            protected override Positions StartOffset => new Positions(0, 3);
            protected override Positions[][] Tiles => tiles;
        }

        public class LBlock : Block
        {
            private readonly Positions[][] tiles = new Positions[][]
            {
                new Positions[] { new(0,2), new(1,0), new(1,1), new(1,2)  },
                new Positions[] { new(0,1), new(1,1), new(2,1), new(2,2)  },
                new Positions[] { new(0,1), new(1,1), new(1,2), new(2,0)  },
                new Positions[] { new(0,0), new(0,1), new(1,1), new(2,1)  }
            };
            public override int id => 2;
            protected override Positions StartOffset => new Positions(0, 3);
            protected override Positions[][] Tiles => tiles;
        }

        public class OBlock : Block
        {
            private readonly Positions[][] tiles = new Positions[][]
            {
                new Positions[] { new(0,0), new(0,1), new(1,0), new(1,1)  }
            };
            public override int id => 4;
            protected override Positions StartOffset => new Positions(0, 4);
            protected override Positions[][] Tiles => tiles;
        }

        public class SBlock : Block
        {
            private readonly Positions[][] tiles = new Positions[][]
            {
                new Positions[] { new(0,1), new(0,2), new(1,0), new(1,1)  },
                new Positions[] { new(0,1), new(1,1), new(1,2), new(2,2)  },
                new Positions[] { new(1,1), new(1,2), new(2,0), new(2,1)  },
                new Positions[] { new(0,0), new(1,0), new(1,1), new(2,1)  }
            };
            public override int id => 5;
            protected override Positions StartOffset => new Positions(0, 3);
            protected override Positions[][] Tiles => tiles;
        }

        public class TBlock : Block
        {
            private readonly Positions[][] tiles = new Positions[][]
            {
                new Positions[] { new(0,1), new(1,0), new(1,1), new(1,2)  },
                new Positions[] { new(0,1), new(1,1), new(1,2), new(2,1)  },
                new Positions[] { new(1,0), new(1,1), new(1,2), new(2,1)  },
                new Positions[] { new(0,1), new(1,0), new(1,1), new(2,1)  }
            };
            public override int id => 6;
            protected override Positions StartOffset => new Positions(0, 3);
            protected override Positions[][] Tiles => tiles;
        }

        public class ZBlock : Block
        {
            private readonly Positions[][] tiles = new Positions[][]
            {
                new Positions[] { new(0,0), new(0,1), new(1,1), new(1,2)  },
                new Positions[] { new(0,2), new(1,1), new(1,2), new(2,1)  },
                new Positions[] { new(1,0), new(1,1), new(2,1), new(2,2)  },
                new Positions[] { new(0,1), new(1,0), new(1,1), new(2,0)  }
            };
            public override int id => 7;
            protected override Positions StartOffset => new Positions(0, 3);
            protected override Positions[][] Tiles => tiles;
        }
        
    }
    */
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBLock(),
            new OBlock(),
            new SBlock(),
            new TBLock(),
            new ZBlock()

        };

        private readonly Random random = new Random();

        public Block NextBlock { get; private set; }

        public BlockQueue()
        {
            NextBlock = new Block();
        }

        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Block GetAndUpdate()
        {
            Block block = NextBlock;
            do
            {
                NextBlock = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
 //TODO:
        //pola
        //Block[] blocks (zawiera 7 klas blokow I, J, L, O, T, S ,Z)---
        //Random do generowania---

        //metody
        //private Block RandomBlock()---
        //public  Block NexteBlock()---
        //public Block GetAndUpdate() daje kolejny blok i uaktualnia kolejke---
        //