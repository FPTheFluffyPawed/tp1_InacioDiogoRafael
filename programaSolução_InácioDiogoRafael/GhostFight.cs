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
        /// </summary>
        /// <param name="Attacker">Fantasma atacante.</param>
        /// <param name="Defender">Fantasma defensor.</param>
        /// <param name="d">Chamar a masmorra.</param>
        static void Resolve(Ghost Attacker, Ghost Defender, Dungeon d)
        {
            // Se o atacante for azul, perder contra vermelho e ganhar contra amarelo.
            if (Attacker.color == EnumColor.Blue)
            {
                switch (Defender.color)
                {
                    case EnumColor.Yellow:
                        d.UpdatePrisionerList(Defender);
                        break;
                    case EnumColor.Red:
                        d.UpdatePrisionerList(Attacker);
                        break;
                    default:
                        break;
                }
            }

            // Se o atacante for vermelho, perder contra amarelo e ganhar contra azul.
            else if (Attacker.color == EnumColor.Red)
            {
                switch (Defender.color)
                {
                    case EnumColor.Blue:
                        d.UpdatePrisionerList(Defender);
                        break;
                    case EnumColor.Yellow:
                        d.UpdatePrisionerList(Attacker);
                        break;
                    default:
                        break;
                }
            }

            // Se o atacante for amarelo, perder contra azul e ganhar contra vermelho.
            else if (Attacker.color == EnumColor.Yellow)
            {
                switch (Defender.color)
                {
                    case EnumColor.Red:
                        d.UpdatePrisionerList(Defender);
                        break;
                    case EnumColor.Blue:
                        d.UpdatePrisionerList(Attacker);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}