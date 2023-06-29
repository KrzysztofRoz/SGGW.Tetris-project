using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGGW.Tetris_Project
{
    public class GameState
    {
        private Block currentBlock;
        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                currentBlock = value;
                currentBlock.Reset();
            }
        }    
        public GameGrid GameGrid{ get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }
        public int Score { get; private set; }
        public GameState()
        {
            GameGrid = new GameGrid(22,10);
            BlockQueue =new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }
        private bool BlockFits()
        {
            foreach(Positions pos in CurrentBlock.TilePositions())
            {
                
                 if(!GameGrid.ISEmpty(pos.row,pos.column))
                 {
                    return false;
                 }
                 
            }
            return true;
        }
        public void RotateBlockR()
        {
            CurrentBlock.RotateR();
            if(!BlockFits())
            {
                CurrentBlock.RotateL();
            }
        }
        public void RotateBlockL()
        {
            CurrentBlock.RotateL();
            if(!BlockFits())
            {
                CurrentBlock.RotateR();
            }
        }
        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if(!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }
        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
          
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }
        private bool IsGameOver()
        {
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }
        private void PlaceBlock()
        {
            foreach (Positions pos in CurrentBlock.TilePositions())
            {
                GameGrid[pos.row,pos.column] = CurrentBlock.Id;
            }
            Score+=GameGrid.ClearFullRow();
            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }
        public void MoveBlockDown()
        {
            CurrentBlock.Move(1,0); 
            if(!BlockFits()) 
            { 
            CurrentBlock.Move(-1,0);
            PlaceBlock();
            }
        }
        private int TileDropDistance(Positions p)
        {
            int drop = 0;

            while (GameGrid.ISEmpty(p.row + drop + 1, p.column))
            {
                drop++;
            }

            return drop;
        }
        public int BlockDropDistance()
        {
            int drop = GameGrid.rows;

            foreach (Positions p in CurrentBlock.TilePositions())
            {
                drop = Math.Min(drop, TileDropDistance(p));
            }

            return drop;
        }

        public void DropBlock()
        {
            CurrentBlock.Move(BlockDropDistance(), 0);
            PlaceBlock();
        }

    }

}
