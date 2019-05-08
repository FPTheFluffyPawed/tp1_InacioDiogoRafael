using System;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Class onde se guarda a posição dos vários objetos de jogo na grelha,
    /// para facilitar o acesso a esta informação.
    /// </summary>
    class Position
    {
        // Propriedades de leitura e escrita.
        public int x {get; set;}
        public int y {get; set;}

        /// <summary>
        /// Método construtor para a posição inicial dos objetos.
        /// </summary>
        /// <param name="initialX"> Posição inicial x. </param>
        /// <param name="initialY"> Posição inicial y. </param>
        public Position(int initialX, int initialY)
        {
            x = initialX;
            y = initialY;
        }

        public Position(){}
    }
}