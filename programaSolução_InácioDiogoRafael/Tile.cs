using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Classe Tile para obter as cores de uma casa.
    /// </summary>
    class Tile
    {
        private EnumColor TileColor;
        public Tile(EnumColor tileColor)
        {
            TileColor = tileColor;
        }

        EnumColor GetColor() => TileColor;

    }
}
