using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGGW.Tetris_Project
{
    /// <summary>
    /// Klasa odpowiedzialna za implementacje metod wspolnych dla kazdego z bloku  i abstarakcyjne pola poszczegolnych blokow
    /// </summary>
    abstract class Block
    {
        protected abstract Positions[][] Tiles { get; }
        protected abstract Positions StartOffset { get; }
        public abstract int Id { get; }
        protected int RotationState;
        private Positions Offset;
        public Block()
        {
            Offset = new Positions(StartOffset.row,StartOffset.column);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Kolekcja zawierajaca aktualne pozycje bloku</returns>
        public IEnumerable<Positions> TilePositions()
        {
            foreach (Positions positions in Tiles[RotationState]) 
            { 
            yield return new Positions(positions.row + Offset.row,positions.column + Offset.column);
            }
        }
        /// <summary>
        /// obrot bloku w prawo, dzielenie modulo zapewnie cyklicznosc stanu wzgledem mozliwych pozycji
        /// </summary>
        public void RotateR()
        {
            RotationState =(RotationState+1) %Tiles.Length; 
        }
        /// <summary>
        /// obrot bloku w lewo
        /// </summary>
        public void RotateL()
        {
            if (RotationState == 0)
            {
                RotationState = Tiles.Length-1;
            }
            else
            {
                RotationState--;
            }
        }
        /// <summary>
        /// Ruch bloku wzdluz osi x i y
        /// </summary>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        public void Move(int rows, int columns)
        {
            Offset.row += rows;
            Offset.column += columns;
        }
        /// <summary>
        /// Ustawienie poczatkowych pozycji bloku
        /// </summary>
        public void Reset()
        {
            RotationState = 0;
            Offset.row =StartOffset.row;
            Offset.column =StartOffset.column;
        }
    }
}
