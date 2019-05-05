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
        // Utilizar EnumColor para buscar as cores.
        private EnumColor TileColor;

        // Construtor para criar uma casa com cor.
        public Tile(EnumColor tileColor)
        {
            TileColor = tileColor;
        }

        // Buscar e returnar a cor de um objeto.
        EnumColor GetColor() => TileColor;

    }
}
