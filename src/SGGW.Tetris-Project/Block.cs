using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGGW.Tetris_Project
{
    abstract class Block
    {
        //TODO:
        //pola:
        //abstarct Postions[][] Tiles
        //abstarc Position Start 
        //abstarct int ID
        //abstract int rotationState
        //Position Offset
        //public Constructor (Start Offset Column i ROW) w konkretnych blokach dodaje Tiles

        //metody all public
        // IEnumerable<Positions> TilePositions() return lista aktualnych pozycji bloku
        //void RotateL() obraca w lewo
        //void RotateR() obraca w prawo
        //void Move(rzad,kolumna) rusza w prawo lewo i dol
        //??? void Reset() zmiana do pierwotnej pozycji

    }
}
