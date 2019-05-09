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
        /// <param name="tileArray">Posição a ser verificada.</param>
        /// <returns>Returna a verificação como válida ou não.</returns>
        public static bool CheckSelectTile(string currentInput, Tile[,] tileArray)
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
                
                if(x >= 0 && x < tileArray.GetLength(0) && y >= 0 && y < tileArray.GetLength(1))
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
        /// <param name="ghostArray">Fantasma a ser verificado.</param>
        /// <returns></returns>
        public static bool CheckSelectGhost(string currentInput, Player p)
        {
            int i;

            if(currentInput.Contains('d'))
            {
                if (Int32.TryParse(currentInput.Remove(0,1), out int g))
                {
                    //i = Int32.Parse(currentInput.Remove(0,1));
                    if(g >= 0 && g < p.dungeonGhosts.Count)
                    {
                        if (p.dungeonGhosts[g] != null) return true;
                        else return false;
                    }
                    else return false;
                } 
                else return false;
            }
            else if (Int32.TryParse(currentInput, out int h))
            {
                //i = Int32.Parse(currentInput);
                if (h >= 0 && h < p.playerGhosts.Count)
                {
                    if(p.playerGhosts[h] != null) return true;
                    else return false;
                }
                else return false;

            }
            else return false;
 
        }
    }
}
