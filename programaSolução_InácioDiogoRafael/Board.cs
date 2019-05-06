using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// O Board tem a lista das posições todas, tem a grelha, tem as
    /// coordenadas e tem as tiles.
    /// </summary>
    class Board
    {
        Tile[,] Tiles;

        public Board()
        {
            Tiles = new Tile[5, 5];
            AssignTileInformation();
        }
        // Buscar a posição no array e meter a informação.
        public void AssignTileInformation()
        {
            // Contentor para por fantasmas deixa-se em branco.
            // Isto é usado para definir os tipos nas casas do mapa, que é 5x5 (25 espaços).
            // 1ª linha
            Tiles[0, 0] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[0, 1] = new Tile(EnumColor.Red, EnumTileType.Tile);
            Tiles[0, 2] = new Tile(EnumColor.Red, EnumTileType.Portal);
            Tiles[0, 3] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[0, 4] = new Tile(EnumColor.Red, EnumTileType.Tile);

            //2ª linha
            Tiles[1, 0] = new Tile(EnumColor.Yellow, EnumTileType.Tile);
            Tiles[1, 1] = new Tile(EnumTileType.Mirror);
            Tiles[1, 2] = new Tile(EnumColor.Yellow, EnumTileType.Tile);
            Tiles[1, 3] = new Tile(EnumTileType.Mirror);
            Tiles[1, 4] = new Tile(EnumColor.Yellow, EnumTileType.Tile);

            //3ª linha
            Tiles[2, 0] = new Tile(EnumColor.Red, EnumTileType.Tile);
            Tiles[2, 1] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[2, 2] = new Tile(EnumColor.Red, EnumTileType.Portal);
            Tiles[2, 3] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[2, 4] = new Tile(EnumColor.Yellow, EnumTileType.Portal);

            //4ª linha
            Tiles[3, 0] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[3, 1] = new Tile(EnumTileType.Mirror);
            Tiles[3, 2] = new Tile(EnumColor.Yellow, EnumTileType.Tile);
            Tiles[3, 3] = new Tile(EnumTileType.Mirror);
            Tiles[3, 4] = new Tile(EnumColor.Red, EnumTileType.Tile);

            //5ª linha
            Tiles[4, 0] = new Tile(EnumColor.Yellow, EnumTileType.Tile);
            Tiles[4, 1] = new Tile(EnumColor.Red, EnumTileType.Tile);
            Tiles[4, 2] = new Tile(EnumColor.Blue, EnumTileType.Portal);
            Tiles[4, 3] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[4, 4] = new Tile(EnumColor.Yellow, EnumTileType.Tile);
        }

        // Getter para obter o tipo (Color + TileType) em uma posição de Tiles.
        public object GetTileType(int i, int j)
        {
            return Tiles.GetValue(i, j);
        }
    }
}
