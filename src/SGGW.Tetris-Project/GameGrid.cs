using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGGW.Tetris_Project
{
    public class GameGrid
    {
        private int[,] grid;

        public int rows;
        public int columns;

        public int this[int row, int column]
        {
            get => grid[row, column];
            set => grid[row, column] = value;
        }

        public GameGrid(int row, int col)
        {
            this.rows = row;
            this.columns = col;
            grid = new int[rows, columns];

        }

        public bool IsInside(int row, int col)
        {
            return row >= 0 && col >= 0 && row < rows && col < columns;
        }

        public bool ISEmpty(int row, int col)
        {
            return IsInside(row, col) && grid[row, col] == 0;
        }

        public bool IsRowFull(int row)
        {
            for(int i = 0; i < columns; i++)
            {
                if(ISEmpty(row, i))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsRowEmpty(int row) 
        {
            for (int i = 0; i < columns; i++)
            {
                if (ISEmpty(row, i) == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void ClearRow(int row)
        {
            for(int i = 0; i < columns; i++)
            {
                grid[row, i] = 0;
            }
        }

        private void MoveRowDown(int row, int numRows)
        {
            for(int i = 0; i < columns; i++)
            {
                grid[row + numRows, i] = grid[row, i];
                grid[row, i] = 0;
            }
        }

        //tą klasę muszę ogarnąć lepiej
        public int ClearFullRow()
        {
            int cleared = 0;

            for (int row =rows-1; row >= 0; row--)
            {
                ISEmpty(IsRowFull(row))
                {
                    ClearRow(row);
                    cleared++;
                }
                else if (cleared > 0)
                {
                    MoveRowDown(row, cleared);
                }
            }
            return cleared;
        }


    }
}
//TODO:

        //pola:
        //private int[,] siatka ---
        //public get po kolumnach i get po rzedach (mozna zrobic jako indekser) ---
        //constructor (rzedy+2 , kolumny) on okresla siatke

        //metody:
        //public bool IsInside(wspolrzedna rzad, kolumna) zwraca tak czy nie ---
        //public bool IsRowFull(nr rzedu) tak czy nie ---
        //public bool IsRowEmpty(nr rzedu) tak czy nie ---
        //private void ClerRow(nr_rzedu) usuwamy wszystkie wartosci z rzedu (ustawiamy na 0) ---
        //private void MoveRowDown(nr_rzedu,ilosc_spadkow) przesowa gorne rzedy o dana ilosc w dol 
        //public int ClearFullRow(): return ilosc_pustych_rzedow