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
        private EnumTileType TileType;

        // Construtor para criar uma casa com cor.
        public Tile(EnumColor tileColor, EnumTileType tileType)
        {
            TileColor = tileColor;
            TileType = tileType;
        }

        public Tile(EnumTileType tileType)
        {
            TileType = tileType;
        }

        // Buscar e returnar a cor de um objeto.
        EnumColor GetColor() => TileColor;

        // Buscar e returnar a cor de um objeto.
        EnumTileType GetTile() => TileType;
    }
}
