using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{   
    /// <summary>
    /// Controla o flow do jogo, a condição de vitória, o turno e o loop
    /// </summary>
    class Game
    {
        Player[] players = new Player[2];
        Player currentPlayer;

        private bool _fastMode;

        private Board _board;
        private Dungeon _dungeon;
        private Renderer _renderer;

        public Game(bool fastMode)
        {
            _fastMode = fastMode;

            _board = new Board();
            _dungeon = new Dungeon();
            _renderer = new Renderer();
            players[0] = new Player();
            players[1] = new Player();
            

        }

        public bool WinCondition()
        {
            bool outRed = false;
            bool outBlue = false;
            bool outYellow = false;
        
            if (_fastMode)
            {
                if (currentPlayer.ghostsOut.Count >= 3)
                {
                     Console.WriteLine("Winner Winner Chicken Dinner!");
                    Console.ReadKey();
                    return true;
                }
            }

            else if (!_fastMode)
            {
                //Check if list is empty before entering method
                foreach (Ghost g in currentPlayer.ghostsOut)
                {
                    if (g.color == EnumColor.Red) outRed = true;
                    if (g.color == EnumColor.Blue) outBlue = true;
                    if (g.color == EnumColor.Yellow) outYellow = true;
                }

                if (outRed && outBlue && outYellow) return true;
            }

            return false;
        }

        public void playerTurn()
        {
            for(int i = 0; i < 888; i++)
            {
                currentPlayer = players[i % 2];
            }
        }
    }
}
