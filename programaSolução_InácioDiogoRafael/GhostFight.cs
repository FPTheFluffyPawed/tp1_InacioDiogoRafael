using System;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Classe que trata sobre a 'luta' entre os fantasmas.
    /// </summary>
    static class GhostFight
    {
        /// <summary>
        /// Metódo para tratar a luta, resolvendo o conflito e
        /// verificar as cores.
        /// Retorna True se o atacante ganhar
        /// </summary>
        /// <param name="Attacker">Fantasma atacante.</param>
        /// <param name="Defender">Fantasma defensor.</param>
        /// <param name="d">Refência á masmorra a utilizar.</param>
        public static bool Resolve(Ghost Attacker, Ghost Defender, 
            Dungeon d, Board p)
        {
            // Se o atacante for azul, perder contra vermelho e ganhar contra 
            // amarelo.
            if (Attacker.color == EnumColor.Blue)
            {
                switch (Defender.color)
                {
                    case EnumColor.Yellow:
                        d.UpdatePrisionerList(Defender);
                        Defender.isOnBoard = false;
                        p.Portals[0].ChangeDirection();
                        return true;
                        
                    case EnumColor.Red:
                        d.UpdatePrisionerList(Attacker);
                        Attacker.isOnBoard = false;
                        p.Portals[2].ChangeDirection();
                        return false;
                        
                    default:
                        return false;
                }
            }

            // Se o atacante for vermelho, perder contra amarelo e ganhar
            // contra azul.
            else if (Attacker.color == EnumColor.Red)
            {
                switch (Defender.color)
                {
                    case EnumColor.Blue:
                        d.UpdatePrisionerList(Defender);
                        Defender.isOnBoard = false;
                        p.Portals[2].ChangeDirection();
                        return true;
                    case EnumColor.Yellow:
                        d.UpdatePrisionerList(Attacker);
                        Attacker.isOnBoard = false;
                        p.Portals[0].ChangeDirection();
                        return false;
                    default:
                        return false;
                }
            }
            
            // Se o atacante for amarelo, perder contra azul e ganhar
            // contra vermelho.
            else if (Attacker.color == EnumColor.Yellow)
            {
                switch (Defender.color)
                {
                    case EnumColor.Red:
                        d.UpdatePrisionerList(Defender);
                        Defender.isOnBoard = false;
                        p.Portals[0].ChangeDirection(); 
                        return true;
                    case EnumColor.Blue:
                        d.UpdatePrisionerList(Attacker);
                        Attacker.isOnBoard = false;
                        p.Portals[1].ChangeDirection(); 
                        return false;
                    default:
                        return false;
                }
            }
            else return false;
        }
    }
}