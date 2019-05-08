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

        public void WinCondition(Player player)
        {
            if (player.ghostsOut.Count == 3)
            {
                Console.WriteLine("Winner Winner Chicken Dinner!");
                Console.ReadKey();
            }
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
