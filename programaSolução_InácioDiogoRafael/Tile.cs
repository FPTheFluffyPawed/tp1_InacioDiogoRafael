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

        // Propriedade do tipo Ghost.
        public Ghost ghostOnTile { get; set; }

        public Position pos;

        /// <summary>
        /// Construtor para criar uma casa com cor.
        /// </summary>
        /// <param name="tileColor"> Cor da casa. </param>
        /// <param name="tileType"> Tipo da casa. </param>
        public Tile(EnumColor tileColor, EnumTileType tileType)
        {
            TileColor = tileColor;
            TileType = tileType;
            ghostOnTile = null;
        }

        /// <summary>
        /// Construtor para criar o tipo de casa ( Mirror, Portal ou Tile ).
        /// </summary>
        /// <param name="tileType"> Tipo de casa. </param>
        public Tile(EnumTileType tileType)
        {
            TileType = tileType;
            ghostOnTile = null;
        }

        // Buscar e returnar a cor de um objeto.
        public EnumColor GetColor() => TileColor;

        // Buscar e returnar a cor de um objeto.
        public EnumTileType GetTile() => TileType;
    }
}
