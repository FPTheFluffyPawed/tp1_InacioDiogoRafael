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
            freeGhosts = new List<Ghost>(0);
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
        
        public void FreeGhosts()
        {
            Position posToCheck = new Position(pos.x, pos.y);

            switch (Direction)
            {
                case EnumPortalDirection.Left:
                    posToCheck.y = pos.x - 1;
                    break;
                case EnumPortalDirection.Up:
                    posToCheck.y = pos.y + 1;
                    break;
                case EnumPortalDirection.Right:
                    posToCheck.y = pos.x + 1;
                    break;
                case EnumPortalDirection.Down:
                    posToCheck.y = pos.y - 1;
                    break;
                default:
                    break;
        }

        public void FreeGhosts(Board board)
        {
            Tile checkedTile;
            checkedTile = board.Tiles[posToCheck.x, posToCheck.y];
            Ghost ghostToSave;
            ghostToSave = checkedTile.GetGhostOnTile;

            if (ghostToSave != null)
                {
                    if (_color == ghostToSave.color)
                    {
                        freeGhosts.Add(ghostToSave);
                        ghostToSave.owner.playerGhosts.Remove(ghostToSave);
                        ghostToSave.owner.ghostsOut.Add(ghostToSave);
                    }
                }
            }
        public EnumColor GetColor() => _color;
    }
}