using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{   
    /// <summary>
    /// Propriedades do jogador. Quantos fantasmas eles já salvou, guarda os 
    /// seus fantasmas.
    /// </summary>
    class Player
    {
        /* Usamos uma lista em vez de um array pois é possiver alterar o 
         * conteúdos da mesma dinamicamente */
        // Lista do número de fantasmas que o jogador possui, começando com 9
        List<Ghost> playerGhosts = new List<Ghost>(9);
        // Lista do número de fantasmas que estão na dungeon começando com 0
        List<Ghost> dungeonGhosts = new List<Ghost>(0);

        static int playersMade = 0;
        public int playerNumber {get; private set;}

        Ghost selectedGhost;

        public Player()
        {
            playerNumber = playersMade + 1;
            playersMade++;
            for (int r = 0; r < 3; r++)
            {
                for (int y = 0; y < 3; y++)
                {
                    for (int b = 0; b < 3; b++)
                    {
                        playerGhosts.Add(new Ghost(EnumColor.Blue, this));  
                    }

                   playerGhosts.Add(new Ghost(EnumColor.Yellow, this)); 
                }

                playerGhosts.Add(new Ghost(EnumColor.Red, this));
            }



        }
    }
}
