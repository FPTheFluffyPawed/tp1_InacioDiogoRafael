using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{
    class Renderer
    {
        private char _tileVisual = '+';
        private char _mirrorVisual = 'M';
        private char _ghostPlayer1Visual = '@';
        private char _ghostPlayer2Visual = '&';
        private char[] _portalVisuals = {'←','→','↑','↓'};

        void DrawTiles(Tile[,] tiles)
        {
            for (int x = 0; x < tiles.GetLength(0); x++ )
            {
                for (int y = 0; y < tiles.GetLength(1); y++ )
                {
                    Console.SetCursorPosition(x,y);
                    switch(tiles[x,y].GetTile())
                    {
                        case EnumTileType.Tile:
                        Console.Write(_tileVisual);
                        break;
                        case EnumTileType.Mirror:
                        Console.Write(_mirrorVisual);
                        break;
                        default:
                        break;
                    }
                }
            }

        }

        void DrawPortals(Portal[] portals)
        {
             for (int i = 0; i < portals.Length; i++)
            {
                Console.SetCursorPosition(portals[i].pos.x,portals[i].pos.y);
                Console.Write(_portalVisuals[(int)portals[i].Direction]);
            }
            
        }



    }


}