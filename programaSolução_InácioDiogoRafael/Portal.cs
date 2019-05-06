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
        EnumPortalDirection direction;
        EnumColor color;

        // Rodar portal na direção dos ponteiros do relógio
        public void ChangeDirection()
        {
            switch (direction)
            {
                case EnumPortalDirection.Left:
                    direction = EnumPortalDirection.Up;
                    break;
                case EnumPortalDirection.Up:
                    direction = EnumPortalDirection.Right;
                    break;
                case EnumPortalDirection.Right:
                    direction = EnumPortalDirection.Down;
                    break;
                case EnumPortalDirection.Down:
                    direction = EnumPortalDirection.Left;
                    break;
                default:
                    break;
            }
        }

        public void FreeGhosts(int i, int j)
        {
            // Variables
            Board board = new Board();
            var ghostPos;
            bool freeGhost;

            // Check ghost color
            if (board.GetTileColor(i, j) == ghost.GetColor && direction == ghostPos)
                freeGhost = true;
        }
    }
}
