using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Classe responsável por mostrar e atualizar o estado de jogo no ecrã.
    /// </summary>
    class Renderer
    {
        private char _tileVisual = '+';
        private char _mirrorVisual = 'M';
        private char _ghostPlayer1Visual = '@';
        private char _ghostPlayer2Visual = '&';
        private char[] _portalVisuals = {'←','→','↑','↓'};

        public void DrawNumbers()
        {
            Console.WriteLine(" 01234");
            Console.Write("0\n1\n2\n3\n4");
        }
        public void DrawTiles(Tile[,] tiles)
        {
            for (int x = 0; x < tiles.GetLength(0); x++ )
            {
                for (int y = 0; y < tiles.GetLength(1); y++ )
                {

                    Console.SetCursorPosition(x + 1, y + 1);
                    
                    if(tiles[x,y].GetTile() == EnumTileType.Mirror)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(_mirrorVisual);
                    }

                    else if(tiles[x,y].GetTile() == EnumTileType.Tile)
                    {   
                        TextColorSwitcher(tiles[x,y].GetColor());

                        Console.Write(_tileVisual);
                    }
                    else Console.Write("");
                   
                }
            }

        }

        public void DrawPortals(Portal[] portals)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            for (int i = 0; i < portals.Length; i++)
             {

                Console.SetCursorPosition(portals[i].pos.x + 1, portals[i].pos.y + 1);
                TextColorSwitcher(portals[i].GetColor());
                Console.Write(_portalVisuals[(int)portals[i].Direction]);
            }
        }

        public void DrawPlayerGhostList(Player currentPlayer)
        {

            char c = ' ';
            Ghost g;
            Console.SetCursorPosition(15,0);
            Console.WriteLine("Your Ghosts, type the number on the left to select them.\n\n");
            
            if (currentPlayer.playerNumber == 1) c = _ghostPlayer1Visual;
            else if (currentPlayer.playerNumber == 2) c = _ghostPlayer2Visual;

            for (int i = 0; i < currentPlayer.playerGhosts.Count; i++)
            {
                Console.CursorLeft = 15;
                g = currentPlayer.playerGhosts[i];
                TextColorSwitcher(g.color);
                Console.Write($"[{i}] - {c}, at ({g.pos.x},{g.pos.y})\n");

            }

        }

        private void TextColorSwitcher(EnumColor c)
        {

            switch(c)
            {
                case EnumColor.Blue:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;

                case EnumColor.Red:
                Console.ForegroundColor = ConsoleColor.Red;
                break;

                case EnumColor.Yellow:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;

                default:
                 Console.ForegroundColor = ConsoleColor.White;
                 break;

            }        

        }

    }
}