using System;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Class onde se guarda a posição dos vários objetos de jogo na grelha,    /// para facilitar o acesso a esta informação.
    /// </summary>
    class Position
    {
        public int x {get; set;}
        public int y {get; set;}

        public Position(int initialX, int initialY)
        {
            x = initialX;
            y = initialY;

        }

        public Position(){}


    }


}