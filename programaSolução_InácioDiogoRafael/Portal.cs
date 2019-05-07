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
        EnumColor color;
        public Portal(EnumColor color, EnumPortalDirection startDirection)
        {
            this.color = color;
            Direction = startDirection;
        }

        // Rodar portal na direção dos ponteiros do relógio
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

        public void FreeGhost()
        {

        }
    }
}
