using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// As propriedades de cada casa. As suas coordenadas e de que tipo é.
    /// </summary>
    class Tile
    {
        private EnumTileType[,] tileType;
        private EnumGhostType[,] ghostType;

        // Inicia a declaração dos espaços que contém os tipos de bloco.
        public Tile()
        {
            tileType = new EnumTileType[5, 5];
            ghostType = new EnumGhostType[5, 5];    // Posição (x, y) para colocar fantasmas. Usar para obter as posições.
            TileInformation();
        }

        // Buscar a posição no array e meter a informação.
        public void TileInformation()
        {
            // Contentor para por fantasmas deixa-se em branco.
            // Isto é usado para definir os tipos nas casas do mapa, que é 5x5 (25 espaços).
            // 1ª linha
            tileType[0, 0] = EnumTileType.BlueTile;
            tileType[0, 1] = EnumTileType.RedTile;
            tileType[0, 2] = EnumTileType.RedPortal;
            tileType[0, 3] = EnumTileType.BlueTile;
            tileType[0, 4] = EnumTileType.RedTile;

            //2ª linha
            tileType[1, 0] = EnumTileType.YellowTile;
            tileType[1, 1] = EnumTileType.Mirror;
            tileType[1, 2] = EnumTileType.YellowTile;
            tileType[1, 3] = EnumTileType.Mirror;
            tileType[1, 4] = EnumTileType.YellowTile;

            //3ª linha
            tileType[2, 0] = EnumTileType.RedTile;
            tileType[2, 1] = EnumTileType.BlueTile;
            tileType[2, 2] = EnumTileType.RedPortal;
            tileType[2, 3] = EnumTileType.BlueTile;
            tileType[2, 4] = EnumTileType.YellowPortal;

            //4ª linha
            tileType[3, 0] = EnumTileType.BlueTile;
            tileType[3, 1] = EnumTileType.Mirror;
            tileType[3, 2] = EnumTileType.YellowTile;
            tileType[3, 3] = EnumTileType.Mirror;
            tileType[3, 4] = EnumTileType.RedTile;

            //5ª linha
            tileType[4, 0] = EnumTileType.YellowTile;
            tileType[4, 1] = EnumTileType.RedTile;
            tileType[4, 2] = EnumTileType.BluePortal;
            tileType[4, 3] = EnumTileType.BlueTile;
            tileType[4, 4] = EnumTileType.YellowTile;
        }

        //get tipo de casa
        public string GetTileType(int i, int j)
        {
            return Convert.ToString(tileType[i, j]);
        }

        //get tipo de fantasma
        public string GetGhostType(int i, int j)
        {
            return Convert.ToString(ghostType[i, j]);
        }

        //set o fantasma num local especifico, dependo de outro codigo
        public void SetGhostType(int i, int j)
        {
            int insertGhost = Convert.ToInt32(Console.ReadLine());
            EnumGhostType colorGhost = (EnumGhostType)insertGhost;
            ghostType[i, j] = colorGhost;
        }
    }
}
