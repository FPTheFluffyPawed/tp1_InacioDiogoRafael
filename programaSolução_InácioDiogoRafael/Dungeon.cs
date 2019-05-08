using System;
using System.Collections.Generic;

namespace programaSolução_InácioDiogoRafael
{
    class Dungeon
    {
        List<Ghost> prisioners;

        public Dungeon()
        {
            prisioners = new List<Ghost>(0);
        }

        public List<Ghost> GetPrisionerList() => prisioners;
        public void UpdatePrisionerList(Ghost newGuy)
        {
            prisioners.Add(newGuy);
            newGuy.inDungeon = true;
            newGuy.owner.playerGhosts.Remove(newGuy);
            newGuy.owner.dungeonGhosts.Add(newGuy);
        }

        public void ReleasePrisioner(Ghost freeGuy)
        {
            freeGuy.inDungeon = false;
            freeGuy.owner.playerGhosts.Add(freeGuy);
            freeGuy.owner.dungeonGhosts.Remove(freeGuy);
            prisioners.Remove(freeGuy);


        }

    }
}