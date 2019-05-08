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
        public List<Position> possiblePos;

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
        public void ChangeOwner(Player newOwner)
        {
            owner.playerGhosts.Remove(this);
            owner = newOwner;
            owner.playerGhosts.Add(this);

        }

        public void UpdatePosition(int x, int y, bool onMirrorTile)
        {
            possiblePos = new List<Position>();
            pos.x = x;
            pos.y = y;

            possiblePos[0] = new Position(x, y + 1);
            possiblePos[1] = new Position(x + 1, y);
            possiblePos[2] = new Position(x, y - 1);
            possiblePos[3] = new Position(x - 1, y);

            if(onMirrorTile)
            {
                possiblePos.Add(new Position(1,1));
                possiblePos.Add(new Position(3,1));
                possiblePos.Add(new Position(1,3));
                possiblePos.Add(new Position(3,3));
            }
        }
    }
}
