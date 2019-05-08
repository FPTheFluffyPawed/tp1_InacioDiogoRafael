using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{   
    /// <summary>
    /// Propriedades dos fantasma. Diz a cor, a que jogador pertencem, as suas
    /// coordenadas e se estão dentro da Dungeon ou não.
    /// </summary>
    class Ghost
    {
        
        public Player owner {get; private set;}
        public EnumColor color {get; private set;}

        // Utilizar a classe das posições para meter o novo fantasma.
        public Position pos;

        // Verificação para ver se estão na masmorra ou não.
        public bool inDungeon {get; set;}

        /// <summary>
        /// Construtor para criar um fantasma.
        /// </summary>
        /// <param name="ghostColour">Cor de o fantasma novo.</param>
        /// <param name="owner">A quem pertence este novo fantasma.</param>
        public Ghost(EnumColor ghostColour, Player owner)
        {
            pos = new Position();
            color = ghostColour;
            this.owner = owner;
            inDungeon = false;
        }

        /// <summary>
        /// Metódo para mudar a quem pertence o fantasma.
        /// </summary>
        /// <param name="newOwner">Jogador a obter o novo fantasma.</param>
        public void ChangeOwner(Player newOwner) => owner = newOwner;
    }
}
