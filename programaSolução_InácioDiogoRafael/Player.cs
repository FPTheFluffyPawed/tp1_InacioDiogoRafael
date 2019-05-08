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
        conteúdos da mesma dinamicamente. */
        // Lista do número de fantasmas que o jogador possui, começando com 9.
        public List<Ghost> playerGhosts = new List<Ghost>(9);
        // Lista do número de fantasmas que estão na dungeon começando com 0.
        public List<Ghost> dungeonGhosts = new List<Ghost>(0);
        // Lista do número de fantasmas que estão fora de jogo.
        public List<Ghost> ghostsOut = new List<Ghost>(0);
        
        // Variável da classe
        static int playersMade = 0;
        // Propriedade de leitura e escrita.
        public int playerNumber {get; private set;}

        // Chama a classe Ghost.
        Ghost selectedGhost;

        /// <summary>
        /// Método construtor, que dá três fantasmas de cada cor a cada 
        /// jogador.
        /// </summary>
        public Player()
        {
            playerNumber = playersMade + 1;
            playersMade++;

            // Adiciona até três fantasmas vermelhos.
            for (int r = 0; r < 3; r++)
            {
                playerGhosts.Add(new Ghost(EnumColor.Red, this));
            }

            // Adiciona até três fantasmas azuis.
            for (int b = 0; b < 3; b++)
            {
                playerGhosts.Add(new Ghost(EnumColor.Blue, this));  
            }

            // Adiciona até três fantasmas amarelos.
            for (int y = 0; y < 3; y++)
            {
                playerGhosts.Add(new Ghost(EnumColor.Yellow, this)); 
            }
        }
    }
}
