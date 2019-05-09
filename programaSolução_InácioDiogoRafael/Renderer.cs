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
        // Variáveis de instância.
        private char _tileVisual = '+';
        private char _mirrorVisual = 'M';
        private char _ghostPlayer1Visual = '@';
        private char _ghostPlayer2Visual = '&';
        private char[] _portalVisuals = {'←','→','↑','↓'};

        /// <summary>
        /// Construtor que define a altura e largura da janela da consola.
        /// </summary>
        public Renderer()
        {
            // Largura, altura.
            Console.SetWindowSize(140, 30);
        }

        /// <summary>
        /// Método para desenhar os números da grelha do jogo.
        /// </summary>
        public void DrawNumbers()
        {
            Console.Clear();

            // Números horizontais.
            Console.WriteLine(" 01234");
            // Números verticais.
            Console.Write("0\n1\n2\n3\n4");
        }

        /// <summary>
        /// Método para desenhar as casas.
        /// </summary>
        /// <param name="tiles"> Referência à classe Tiles. </param>
        public void DrawTiles(Tile[,] tiles)
        {
            // Desenha as casas horizontais.
            for (int x = 0; x < tiles.GetLength(0); x++ )
            {
                // Desenha as casas verticais.
                for (int y = 0; y < tiles.GetLength(1); y++ )
                {
                    Console.SetCursorPosition(x + 1, y + 1);
                    
                    // Dão a cor dependendo do tipo de casa.
                    if(tiles[x,y].GetTile() == EnumTileType.Mirror)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(_mirrorVisual);
                    }

                    else if(tiles[x,y].GetTile() == EnumTileType.Tile)
                    {   
                        if(tiles[x,y].ghostOnTile == null)
                        {
                            TextColorSwitcher(tiles[x,y].GetColor());
                            Console.Write(_tileVisual);
                        }
                    }
                    else Console.Write(""); 
                }
            }
        }

        /// <summary>
        /// Método para desenhar os portais.
        /// </summary>
        /// <param name="portals"> Referência a classe portal. </param>
        public void DrawPortals(Portal[] portals)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Desenha o portal com a cor, posição e direção corretas.
            for (int i = 0; i < portals.Length; i++)
            {
                Console.SetCursorPosition(portals[i].pos.x + 1, 
                    portals[i].pos.y + 1);
                TextColorSwitcher(portals[i].GetColor());
                Console.Write(_portalVisuals[(int)portals[i].Direction]);
            }
        }

        /// <summary>
        /// Método que apresenta a lista de fantasmas dos jogadores.
        /// </summary>
        /// <param name="currentPlayer">  Variável do jogador no momento.
        /// </param>
        public void DrawPlayerGhostList(Player currentPlayer)
        {
            // Variável.
            char c = ' ';
            // Cor da consola.
            Console.ForegroundColor = ConsoleColor.White;
            // Acede a classe Ghost.
            Ghost g;

            // Na posição (30,0) da janela da consola vai ser escrito 
            // "Your Ghosts:".
            Console.SetCursorPosition(30,0);
            Console.Write("Your Ghosts:");

            // Na posição (15,1) da janela da consola vai ser escrito 
            // "Type the number on the left to select them.".
            Console.SetCursorPosition(15,1);
            Console.Write("Type the number on the left to select them.");

            // Na posição (15,2) da janela da consola vai ser escrito 
            // "Then type in grid coordinates to place them.\n".
            Console.SetCursorPosition(15,2);
            Console.Write("Then type in grid coordinates to place them.\n");
            
            // Modifica os visuais dos fantsmas dos jgoadores.
            if (currentPlayer.playerNumber == 1) c = _ghostPlayer1Visual;
            else if (currentPlayer.playerNumber == 2) c = _ghostPlayer2Visual;

            // Conta quantos fantasmas o jogador tem.
            for (int i = 0; i < currentPlayer.playerGhosts.Count; i++)
            {
                Console.CursorLeft = 25;
                g = currentPlayer.playerGhosts[i];
                TextColorSwitcher(g.color);
                if(g.isOnBoard)
                    Console.Write($"[{i}] - {c}, at ({g.pos.x},{g.pos.y})\n");
                else if(!g.isOnBoard)
                    Console.Write($"[{i}] - {c} -NOT PLACED YET-\n");
            }
        }

        /// <summary>
        /// Método para apresentar a lista da caverna dos fantasmas.
        /// </summary>
        /// <param name="dung"> Acede a classe Dungeon. </param>
        public void DrawDungeonGhostList(Dungeon dung)
        {
            // Variável.
            char c = ' ';
            // Coloca a cor da consola a branco.
            Console.ForegroundColor = ConsoleColor.White;
            // Acede a classe Ghost.
            Ghost g;
            
            // Na posição (90, 0) é escrito "Your Ghosts:".
            Console.SetCursorPosition(90,0);
            Console.Write("Your Ghosts in the Dungeon:");

            // Na posição (70, 1) é escrito "Type 'd' + the number on the 
            // left to select them.".
            Console.SetCursorPosition(70,1);
            Console.Write("Type 'd' + the number on the left to select them.");

            // Na posição (70, 2) é escrito "Selecting a ghost in the 
            // Dungeon will give the other player.\n" .
            Console.SetCursorPosition(70,2);
            Console.Write("Selecting a ghost in the Dungeon will give" + 
             "it to the other player.\n");

            
            // Apresenta os fantasmas de cada jogador na caverna.
            for (int i = 0; i < dung.GetPrisionerList().Count; i++)
            {
                g = dung.GetPrisionerList()[i];
                if (g.owner.playerNumber == 1) c = _ghostPlayer1Visual;
                else if (g.owner.playerNumber == 2) c = _ghostPlayer2Visual;
                TextColorSwitcher(g.color);

                Console.CursorLeft = 90;
                Console.Write($"[{i}] - {c}.\n");
            }

            // Faz um tracejado a branco na coluna 70.
            Console.CursorLeft = 70;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("---------------------------------------------" +
                "-----------");
        }

        public void DrawGhostsOnBoard(Board b)
        {
            char c = ' ';
            foreach(Tile t in b.Tiles)
            {
                if(t.ghostOnTile != null)
                {
                    if (t.ghostOnTile.owner.playerNumber == 1) 
                    c = _ghostPlayer1Visual;
                    else if (t.ghostOnTile.owner.playerNumber == 2) 
                    c = _ghostPlayer2Visual;                   
                    Console.SetCursorPosition(t.pos.x + 1, t.pos.y + 1 );
                    TextColorSwitcher(t.ghostOnTile.color);
                    Console.Write(c);
                    
                }

            }

        }

        public void ShowPrompt(string msg, Player currP)
        {
            Console.SetCursorPosition(0,25);
            Console.WriteLine("     ");
            Console.WriteLine("     ");
            Console.SetCursorPosition(0,25);
            Console.Write($"Jogador{currP.playerNumber}: " + msg +"\n");
        }
        //public void ShowPrompt(string msg, )

        /// <summary>
        /// Método para definir a cor do texto na consola.
        /// </summary>
        /// <param name="c"> Variável cor. </param>
        private void TextColorSwitcher(EnumColor c)
        {
            // Controla que cor deve ser representada na consola consoante a
            // cor dos fantasmas e portais.
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