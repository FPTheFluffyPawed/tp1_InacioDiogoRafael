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

        public EnumPortalDirection Direction {get; private set;}
        private EnumColor _color;

        public Position pos {get; private set;}
        public Portal(EnumColor color, EnumPortalDirection startDirection, int X0, int Y0)
        {
            this.color = color;
            Direction = startDirection;
            pos = new Position(X0,Y0);
        }
    }
}