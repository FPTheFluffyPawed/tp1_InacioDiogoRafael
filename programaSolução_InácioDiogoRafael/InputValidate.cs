using System;
using System.Collections.Generic;
using System.Text;


namespace programaSolução_InácioDiogoRafael
{   
    /// <summary>
    /// Verifica se os inputs dos jogadores são válidos para o contexto do 
    /// jogo.
    /// </summary>
    static class InputValidate
    {
        /// <summary>
        /// Verificar se a posição selecionada é válida no mapa.
        /// </summary>
        /// <param name="currentInput">Comando introduzido.</param>
        /// <param name="tileArray">Posição inserida.</param>
        /// <returns>Returna a verificação como válida ou não.</returns>
        static bool CheckSelectTile(string currentInput, Tile[,] tileArray)
        {
            string[] coords;
            if (!currentInput.Contains(",")) return false;
            else coords = currentInput.Split(",", 2);

            if (!Int32.TryParse(coords[0], out int x) || 
                !Int32.TryParse(coords[1], out int y)) 
            {
                return false;
            }
            else 
            {
                if (tileArray[Int32.Parse(coords[0]),Int32.Parse(coords[1])] 
                != null)
                {
                    return true;
                }
                else return false;
            }
        }

        /// <summary>
        /// Verificação se o fantasma selecionado é valido.
        /// </summary>
        /// <param name="currentInput">Comando introduzido.</param>
        /// <param name="ghostArray">Fantasma inserido.</param>
        /// <returns></returns>
        static bool CheckSelectGhost(string currentInput, Ghost[] ghostArray)
        {
            if (Int32.TryParse(currentInput, out int g) && 
                ghostArray[Int32.Parse(currentInput)] != null) return true;
            else return false;
        }
    }
}
