using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Controla o flow do jogo, a condição de vitória, os jogadores, o turno
    /// e o loop.
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
        /// <param name="fastMode">Verificar se 'fastMode' está ativo.</param>
        public Game(bool fastMode)
        {
            _fastMode = fastMode;

            _board = new Board();
            _dungeon = new Dungeon();
            _renderer = new Renderer();
            players[0] = new Player();
            players[1] = new Player();

            foreach(Ghost g in players[0].playerGhosts)
                g.SetStartPossiblePos(_board.Tiles);
            foreach(Ghost g in players[1].playerGhosts)
                g.SetStartPossiblePos(_board.Tiles);

            for(int i = 0; i < players.Length; i++)
            {
                foreach(Ghost g in players[i].playerGhosts)
                {
                    g.SetStartPossiblePos(_board.Tiles);
                }             
            }
        }

        /// <summary>
        /// Metódo para o loop do jogo.
        /// </summary>
        public void GameLoop()
        {
            //SetupPhase();
            for(int i = 0; i < 1666; i++)
            {
                currentPlayer = players[i % 2];
                currentPlayer.selectedGhost = null;
                UpdateDrawCall();
                DoPlayerTurn();
                if(WinCondition()) 
                    break;
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

            // Verificação para o modo rápido do jogo, que vê se existe
            // 3 fantasmas fora.
            if (_fastMode)
            {
                if (currentPlayer.ghostsOut.Count >= 3)
                {
                    Console.WriteLine("Winner Winner Chicken Dinner!");
                    Console.ReadKey();
                    return true;
                }
            }

            // Verificação para o modo normal do jogo, que vê se existem três
            // fantasmas com cores unícas.
            else if (!_fastMode)
            {
                // NOTA:
                // Verificar se a lista está vazia antes de introduzir o
                // metódo.

                // Para cada fantasma na lista de fantasmas fora do mapa,
                // pertencente a um jogador, verificar se um fantasma da cor
                // está presente, e assinalar.
                foreach (Ghost g in currentPlayer.ghostsOut)
                {
                    if (g.color == EnumColor.Red) outRed = true;
                    if (g.color == EnumColor.Blue) outBlue = true;
                    if (g.color == EnumColor.Yellow) outYellow = true;
                }
                // Se as três cores estiverem presentes, returnamos verdade a
                // condição vitória.
                if (outRed && outBlue && outYellow) return true;
            }

            // Se não, fica falso.
            return false;
        }

        // Executa as ações que constituem o turno 
        //para 1 jogador
        private void DoPlayerTurn()
        {
            PlayerInteractionHandler.PlayerSelectGhost(_renderer,_board, 
                _dungeon, currentPlayer, players);

            if(currentPlayer.selectedGhost != null)
                PlayerInteractionHandler.PlayerSelectTile(_renderer, 
                    _board,_dungeon, currentPlayer, players);
        }

        // Utilisa o renderer para desenhar tudo no ecrã com os
        // estados atualizados
        private void UpdateDrawCall()
        {
            _renderer.DrawNumbers();
            _renderer.DrawTiles(_board.Tiles);
            _renderer.DrawPortals(_board.Portals);
            _renderer.DrawGhostsOnBoard(_board);
            _renderer.DrawPlayerGhostList(currentPlayer);
            _renderer.DrawDungeonGhostList(_dungeon);
        }

        // Primeira fase do jogo, em que os jogadores apenas
        // colocam os fantasmas no tabuleiro
        private void SetupPhase()
        {
            currentPlayer = players[0];

            UpdateDrawCall();
            DoPlayerTurn();

            currentPlayer = players[1];
            UpdateDrawCall();
            DoPlayerTurn();
            UpdateDrawCall();
            DoPlayerTurn();

            for(int i = 0; i < 15; i++)
            {
                currentPlayer = players[i % 2];
                UpdateDrawCall();
                DoPlayerTurn();
            }    
        }
    }
}
