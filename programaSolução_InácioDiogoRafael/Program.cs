using System;

namespace programaSolução_InácioDiogoRafael
{
    class Program
    {

        static void Main(string[] args)
        {
            Game gm;
            if (args[0] == "--quick") gm = new Game(true);
            else gm = new Game(false);
        }
    }
}
