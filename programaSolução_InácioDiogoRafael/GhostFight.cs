using System;

namespace programaSolução_InácioDiogoRafael
{
    static class GhostFight
    {
        static void Resolve(Ghost Attacker, Ghost Defender, Dungeon d)
        {
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