﻿using System;
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
        public Tile[,] Tiles {get; private set;}
        public Portal[] Portals {get; private set;}

        /// <summary>
        /// Construtor para criar um novo 'Board'.
        /// </summary>
        public Board()
        {
            Tiles = new Tile[5, 5];
            Portals = new Portal[3];
            AssignTileInformation();
            PlacePortals();
        }

        /// <summary>
        /// Metódo para meter a informação correta nas casas corretas
        /// para criar o mapa predefinido do jogo.
        /// </summary>
        private void AssignTileInformation()
        {
            // Com o array bidimensional, assinalamos as posições.
            // 1ª linha.
            Tiles[0, 0] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[1, 0] = new Tile(EnumColor.Red, EnumTileType.Tile);
            Tiles[2, 0] = new Tile(EnumTileType.Portal);        
            Tiles[3, 0] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[4, 0] = new Tile(EnumColor.Red, EnumTileType.Tile);

            // 2ª linha.
            Tiles[0, 1] = new Tile(EnumColor.Yellow, EnumTileType.Tile);
            Tiles[1, 1] = new Tile(EnumTileType.Mirror);
            Tiles[2, 1] = new Tile(EnumColor.Yellow, EnumTileType.Tile);
            Tiles[3, 1] = new Tile(EnumTileType.Mirror);
            Tiles[4, 1] = new Tile(EnumColor.Yellow, EnumTileType.Tile);

            // 3ª linha.
            Tiles[0, 2] = new Tile(EnumColor.Red, EnumTileType.Tile);
            Tiles[1, 2] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[2, 2] = new Tile(EnumColor.Red, EnumTileType.Tile); 
            Tiles[3, 2] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[4, 2] = new Tile(EnumTileType.Portal);       

            // 4ª linha.
            Tiles[0, 3] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[1, 3] = new Tile(EnumTileType.Mirror);
            Tiles[2, 3] = new Tile(EnumColor.Yellow, EnumTileType.Tile);
            Tiles[3, 3] = new Tile(EnumTileType.Mirror);
            Tiles[4, 3] = new Tile(EnumColor.Red, EnumTileType.Tile);

            // 5ª linha.
            Tiles[0, 4] = new Tile(EnumColor.Yellow, EnumTileType.Tile);
            Tiles[1, 4] = new Tile(EnumColor.Red, EnumTileType.Tile);
            Tiles[2, 4] = new Tile(EnumTileType.Portal);        
            Tiles[3, 4] = new Tile(EnumColor.Blue, EnumTileType.Tile);
            Tiles[4, 4] = new Tile(EnumColor.Yellow, EnumTileType.Tile);

            for(int x = 0; x < Tiles.GetLength(0); x++)
            {
                for (int y = 0; y < Tiles.GetLength(1); y++)
                {
                    Tiles[x,y].pos.x = x;
                    Tiles[x,y].pos.y = y;
                }
            }
        }

        /// <summary>
        /// Metódo para assinalar os portais nas posições corretas com as
        /// suas cores.
        /// </summary>
        private void PlacePortals()
        {
            Portals[0] =
                new Portal(EnumColor.Red, EnumPortalDirection.Up, 2, 0);
            Portals[1] = 
                new Portal(EnumColor.Yellow, EnumPortalDirection.Right, 4, 2);
            Portals[2] = 
                new Portal(EnumColor.Blue, EnumPortalDirection.Down, 2, 4);
        }

        /// <summary>
        /// Getter para obter a cor em uma posição de Tiles.
        /// </summary>
        /// <param name="i">X</param>
        /// <param name="j">Y</param>
        /// <returns></returns>
        public EnumColor GetTileColor(int i, int j)
        {
            return Tiles[i, j].GetColor();
        }

        /// <summary>
        /// Getter para obter o tipo de casa em uma posição de Tiles.
        /// </summary>
        /// <param name="i"> X </param>
        /// <param name="j"> Y </param>
        /// <returns></returns>
        public EnumTileType GetTileType(int i, int j)
        {
            return Tiles[i, j].GetTile();
        }

        /// <summary>
        /// Método para color os fantasmas nas casas
        /// </summary>
        /// <param name="g"> Variável tipo Ghost </param>
        /// <param name="newX"> X atualizado </param>
        /// <param name="newY"> Y atualizado </param>
        public void PlaceGhostOnTile(Ghost g, int newX, int newY)
        {
            Tiles[g.pos.x, g.pos.y].ghostOnTile = null;
            Tiles[newX, newY].ghostOnTile = g;

            g.isOnBoard = true;

            g.UpdatePosition(newX, newY, 
            Tiles[newX, newY].GetTile() == EnumTileType.Mirror);
        }
    }
}
