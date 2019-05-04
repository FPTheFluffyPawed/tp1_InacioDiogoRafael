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
        /// <summary>
        /// Listas para o número de fantasmas que o jogador possui e para o 
        /// número de jogadores que está na dungeon. Usamos uma lista em vez de
        /// um array pois é possiver alterar o conteúdos da mesma 
        /// dinamicamente.
        /// </summary>
        // Lista do número de fantasmas que o jogador possui, começando com 9
        List<string> playerGhosts = new List<string>(9);
        // Lista do número de fantasmas que estão na dungeon começando com 0
        List<string> dungeonGhosts = new List<string>(0);
    }
}
