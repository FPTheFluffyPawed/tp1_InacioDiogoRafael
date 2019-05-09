using System;

namespace programaSolução_InácioDiogoRafael
{
    static class PlayerInteractionHandler
    {
        private static string currentIn;
        private static string[] conInArr = new string[2];
        private static int convertedIn;

        private static int conInX;
        private static int conInY;


        public static void PlayerSelectGhost(Renderer r, Player currentP, Player[] pList)
        {
            do
            {
            r.ShowPrompt(PromptMessages.SelectGhost, currentP);
            currentIn = Console.ReadLine();
            }
            while(!InputValidate.CheckSelectGhost(currentIn,currentP));

            //Atribuir o Ghost selecionado ao jogador certo
            if (currentIn.Contains('d')) 
            {
                convertedIn = Int32.Parse(currentIn.Remove(0,1));
                currentP.dungeonGhosts[convertedIn].ChangeOwner(pList[currentP.playerNumber % 2]);

            }
            else
            {
                convertedIn = Int32.Parse(currentIn);
                currentP.selectedGhost = currentP.playerGhosts[convertedIn]; 
            }
        }

        // Quando o jogador tiver de selecionar uma tile
        public static void PlayerSelectTile(Renderer r, Board b, 
        Dungeon dungeon, Player currentP, Player[] pList)
        {
            Ghost g1;
            Ghost g2;
            
            do
            {
                r.ShowPrompt(PromptMessages.SelectTile, currentP);
                currentIn = Console.ReadLine();                       

            }
            while(!InputValidate.CheckSelectTile(currentIn, b.Tiles));

            conInArr = currentIn.Split(',');
            conInX = Int32.Parse(conInArr[0]);
            conInY = Int32.Parse(conInArr[1]);

            g1 = currentP.selectedGhost;
            foreach(Position p in g1.possiblePos.ToArray())
            {
                if(p.x == conInX  &&  p.y == conInY)
                {
                    if(b.Tiles[conInX,conInY].ghostOnTile != null)   
                    {   
                        g2 = b.Tiles[conInX,conInY].ghostOnTile;

                        if(g2.color != g1.color)
                        {

                            if(GhostFight.Resolve(g1, g2, dungeon, b))
                            {
                                b.PlaceGhostOnTile(g1,conInX, conInY);

                            }                               
                            
                        }
                        
                    }
                    else  
                        b.PlaceGhostOnTile(g1,conInX, conInY);
                   
                }
            }

        }        
    }
}