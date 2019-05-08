using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Controla o flow do jogo, a condição de vitória, os jogadores, o turno e o loop.
    /// </summary>
    class Game
    {
        // Cria dois jogadores.
        Player[] players = new Player[2];
        // Variável para selecionar o jogador.
        Player currentPlayer;


        private bool _fastMode;

        private Board _board;
        private Dungeon _dungeon;
        private Renderer _renderer;

        /// <summary>
        /// Construtor para criar o jogo, utilizando 'fastMode'
        /// para inicializar.
        /// </summary>
        /// <param name="fastMode">'true' ou 'false'</param>
        public Game(bool fastMode)
        {
            _fastMode = fastMode;

            _board = new Board();
            _dungeon = new Dungeon();
            _renderer = new Renderer();
            players[0] = new Player();
            players[1] = new Player();
            

        }

        /// <summary>
        /// Metódo para o loop do jogo.
        /// </summary>
        public void GameLoop()
        {
            for(int i = 0; i < 888; i++)
            {
                currentPlayer = players[i % 2];

                // Desenha o mapa do jogo.
                _renderer.DrawNumbers();
                _renderer.DrawTiles(_board.Tiles);
                _renderer.DrawPortals(_board.Portals);
                _renderer.DrawPlayerGhostList(currentPlayer);
                _renderer.DrawDungeonGhostList(_dungeon);
            
                // NOTA:
                // Perguntar e tratar do comando inserido.

            
                // NOTA:
                // Termina a vez de o jogador.

            
                // Verificar se o jogador ganho.
                if(WinCondition()) break;
                }
        }

        /// <summary>
        /// Condição de vitória.
        /// </summary>
        /// <returns>Devolve 'true' se a condição for verdade.</returns>
        public bool WinCondition()
        {
            // Booleans para verificar os fantasmas que estão fora
            // da cor correta.
            bool outRed = false;
            bool outBlue = false;
            bool outYellow = false;

            // Verificação para o modo rápido do jogo, que vê se existe 3 fantasmas fora.
            if (_fastMode)
            {
                if (currentPlayer.ghostsOut.Count >= 3)
                {
                     Console.WriteLine("Winner Winner Chicken Dinner!");
                    Console.ReadKey();
                    return true;
                }
            }

            // Verificação para o modo normal do jogo, que vê se existem três fantasmas com cores
            // unícas.
            else if (!_fastMode)
            {
                // NOTA:
                // Verificar se a lista está vazia antes de introduzir o metódo.


                // Para cada fantasma na lista de fantasmas fora do mapa, pertencente a um jogador,
                // verificar se um fantasma da cor está presente, e assinalar.
                foreach (Ghost g in currentPlayer.ghostsOut)
                {
                    if (g.color == EnumColor.Red) outRed = true;
                    if (g.color == EnumColor.Blue) outBlue = true;
                    if (g.color == EnumColor.Yellow) outYellow = true;
                }

                // Se as três cores estiverem presentes, returnamos verdade a condição vitória.
                if (outRed && outBlue && outYellow) return true;
            }

            // Se não, fica falso.
            return false;
        }

        /// <summary>
        /// Metódo que trata a vez de um jogador. INCOMPLETO.
        /// </summary>
        public void playerTurn()
        {

        }
    }
}
