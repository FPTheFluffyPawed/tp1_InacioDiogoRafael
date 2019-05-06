using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace programaSolução_InácioDiogoRafael
{   
    /// <summary>
    /// Capta os inputs dos jogadores.
    /// </summary>
    static class InputValidate
    {
        
        static bool CheckSelectTile(string currentInput, Tile[,] tileArray)
        {
            string[] coords;
            if (!currentInput.Contains(",")) return false;
            else coords = currentInput.Split(",");

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




    }
}
