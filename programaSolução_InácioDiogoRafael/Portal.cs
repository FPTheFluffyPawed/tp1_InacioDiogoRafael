using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Propriedades da casa Portal. A direção para que estã virado e a cor.
    /// </summary>
    class Portal
    {
        public EnumPortalDirection Direction {get; private set;}
        private EnumColor _color;
        List<Ghost> freeGhosts;


        public Position pos {get; private set;}
        public Portal(EnumColor color, EnumPortalDirection startDirection, int X0, int Y0)
        {
            _color = color;
            Direction = startDirection;
            pos = new Position(X0,Y0);
        }

        public void ChangeDirection()
        {
            switch (Direction)
            {
                case EnumPortalDirection.Left:
                    Direction = EnumPortalDirection.Up;
                    break;
                case EnumPortalDirection.Up:
                    Direction = EnumPortalDirection.Right;
                    break;
                case EnumPortalDirection.Right:
                    Direction = EnumPortalDirection.Down;
                    break;
                case EnumPortalDirection.Down:
                    Direction = EnumPortalDirection.Left;
                    break;
                default:
                    break;
            }
        }

        public void FreeGhosts(int i, int j, Ghost savedGhost)
        {
            Player p1 = new Player();
            Ghost ghost = new Ghost(EnumColor.Red, p1);

            if (_color == ghost.color && pos == ghost.pos)
            {
                savedGhost.Add(savedGhost);
                savedGhost.owner.playerGhosts.Remove(savedGhost);
                savedGhost.owner.ghostsOut.Add(savedGhost);
            }
        }

        public EnumColor GetColor() => _color;
    }
}