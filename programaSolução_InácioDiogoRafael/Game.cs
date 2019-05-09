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

        private string _input;
        private int _inputInt;
        private int _inIntX;
        private int _inIntY;
        private string[] _inputArr;

        private Ghost g1;
        private Ghost g2;


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
        }

        /// <summary>
        /// Metódo para o loop do jogo.
        /// </summary>
        public void GameLoop()
        {
            for(int i = 0; i < 888; i++)
            {
                currentPlayer = players[i % 2];
                currentPlayer.selectedGhost = null;
                // Desenha o mapa do jogo.
                Console.WriteLine(_fastMode);
                Console.ReadLine();
                _renderer.DrawNumbers();
                _renderer.DrawTiles(_board.Tiles);
                _renderer.DrawPortals(_board.Portals);
                _renderer.DrawPlayerGhostList(currentPlayer);
                _renderer.DrawDungeonGhostList(_dungeon);
            
                //Pedir para selecionar um fantasma
                do
                {
                _renderer.ShowPrompt(PromptMessages.SelectGhost, currentPlayer);
                _input = Console.ReadLine();
                }
                while(!InputValidate.CheckSelectGhost(_input,currentPlayer));

                //Atribuir o Ghost selecionado ao jogador certo
                if (_input.Contains('d')) 
                {
                    _inputInt = Int32.Parse(_input.Remove(0,1));
                    currentPlayer.dungeonGhosts[_inputInt].ChangeOwner(players[currentPlayer.playerNumber % 2]);

                }
                else
                {
                    _inputInt = Int32.Parse(_input);
                    currentPlayer.selectedGhost = currentPlayer.playerGhosts[_inputInt]; 
                }

                // Usar o ghost selecionado se houver, e colocá-lo numa 
                //Tile válida
                if(currentPlayer.selectedGhost != null)
                {
                    //Pedir para selecionar uma Tile
                    do
                    {
                     _renderer.ShowPrompt(PromptMessages.SelectTile, currentPlayer);
                    _input = Console.ReadLine();                       

                    }
                    while(!InputValidate.CheckSelectTile(_input, _board.Tiles));

                    _inputArr = _input.Split(',');
                    _inIntX = Int32.Parse(_inputArr[0]);
                    _inIntY = Int32.Parse(_inputArr[1]);

                    g1 = currentPlayer.selectedGhost;
                    foreach(Position p in g1.possiblePos)
                    {
                        if(p.x == _inIntX && p.y == _inIntY)
                        {
                            if(_board.Tiles[_inIntX,_inIntY].ghostOnTile 
                                != null) 
                            {   
                                g2 = _board.Tiles[_inIntX,_inIntY].ghostOnTile;

                                if(g2.color != g1.color)
                                {
                                    if(GhostFight.Resolve(g1, g2, _dungeon))
                                    {
                                        _board.PlaceGhostOnTile(g1,_inIntX, _inIntY);

                                    }
                                }
                                else  _board.PlaceGhostOnTile(g1,_inIntX, _inIntY);
                                        
                            }


                        }
                        
                    }


                }
                



               

                // Verificar se o jogador ganhou.
                if(WinCondition()) break;

                // NOTA:
                // Termina a vez de o jogador.

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

        /// <summary>
        /// Metódo que trata a vez de um jogador. INCOMPLETO.
        /// </summary>
        public void playerTurn()
        {

        }
    }
}
