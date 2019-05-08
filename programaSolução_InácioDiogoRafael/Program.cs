using System;

namespace programaSolução_InácioDiogoRafael
{
    class Program
    {
        /// <summary>
        /// Corre o programa, chamando a classe Game.
        /// </summary>
        /// <param name="args"> Argumentos inseridos na consola. </param>
        static void Main(string[] args)
        {
            // Chama a classe Game.
            Game gm;
            /* Verifica os argumentos inseridos na consola. Se for inserido o
            argumento --quick, será iniciado o modo "quick" em que a 
            a condição de vitória é diferente. */
            if (args[0] == "--quick") gm = new Game(true);
            else gm = new Game(false);
        }
    }
}
