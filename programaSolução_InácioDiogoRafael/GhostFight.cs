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
                    case enumColor.Yellow:
                    d.UpdatePrisionerList(Defender);
                    break;
                    case enumColor.Red:
                    d.UpdatePrisionerList(Attacker);
                    break;
                    default:
                    break;     
                    
                }

            else if (Attacker.color == EnumColor.Red)
            {
                switch (Defender.color)
                {
                    case enumColor.Blue:
                    d.UpdatePrisionerList(Defender);
                    break;
                    case enumColor.Yellow:
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
                    case enumColor.Red:
                    d.UpdatePrisionerList(Defender);
                    break;
                    case enumColor.Blue:
                    d.UpdatePrisionerList(Attacker);
                    break;
                    default:
                    break;     
                    
                }

            }


        }
    }
}