using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{   
    /// <summary>
    /// Propriedades dos fantasma. Diz a cor, a que jogador pertencem, as suas
    /// coordenadas e se estão dentro da Dungeon ou não
    /// </summary>
    class Ghost
    {
        
        public Player owner {get; private set;}
        public EnumColor color {get; private set;}

       public Position pos;

        bool inDungeon;

        public Ghost(EnumColor ghostColour, Player owner)
        {
            pos = new Position();
            color = ghostColour;
            this.owner = owner;
            inDungeon = false;
        }

        public void ChangeOwner(Player newOwner) => owner = newOwner;



    }
}
