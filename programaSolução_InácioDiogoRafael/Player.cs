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
        List<int> playerGhosts = new List<int>(9);
        // Lista do número de fantasmas que estão na dungeon começando com 0
        List<int> dungeonGhosts = new List<int>(0);
    }
}
