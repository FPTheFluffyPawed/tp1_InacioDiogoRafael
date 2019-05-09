using System;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Classe que trata os inputs do jogador.
    /// </summary>
    static class PlayerInteractionHandler
    {
        private static string currentIn;
        private static string[] conInArr = new string[2];
        private static int convertedIn;
    
        private static int conInX;
        private static int conInY;

        /// <summary>
        /// Metódo a ser chamado ao o jogador escolher um fantasma.
        /// </summary>
        /// <param name="r">Renderer.</param>
        /// <param name="b">Board.</param>
        /// <param name="d">Dungeon.</param>
        /// <param name="currentP">Jogador atual.</param>
        /// <param name="pList">Lista de jogadores.</param>
        public static void PlayerSelectGhost(Renderer r, Board b, Dungeon d,
            Player currentP, Player[] pList)
        {
            do
            {
            r.ShowPrompt(PromptMessages.SelectGhost, currentP);
            currentIn = Console.ReadLine();
            }
            while(!InputValidate.CheckSelectGhost(currentIn,currentP));

            // Atribuir o Ghost selecionado ao jogador certo
            // Agarrar os fantasmas da masmorra.
            if (currentIn.Contains('d')) 
            {
                // Retirar a número do string.
                convertedIn = Int32.Parse(currentIn.Remove(0, 1));
                currentP.selectedGhost = currentP.dungeonGhosts[convertedIn];
                currentP.selectedGhost.SetStartPossiblePos(b.Tiles);

                // Dar fantasma ao jogador oponente.
                if (currentP.playerNumber == 2)
                {
                    currentP.dungeonGhosts[convertedIn].ChangeOwner(pList[0]);
                    d.ReleasePrisioner(currentP.selectedGhost);
                }
                else
                {
                    currentP.dungeonGhosts[convertedIn].ChangeOwner(pList[1]);
                    d.ReleasePrisioner(currentP.selectedGhost);
                }
            }
            else
            {
                convertedIn = Int32.Parse(currentIn);
                currentP.selectedGhost = currentP.playerGhosts[convertedIn]; 
            }
        }

        /// <summary>
        /// Metódo a ser chamado para escolher uma casa.
        /// </summary>
        /// <param name="r">Renderer.</param>
        /// <param name="b">Board.</param>
        /// <param name="dungeon">Dungeon.</param>
        /// <param name="currentP">Jogador atual.</param>
        /// <param name="pList">Lista de jogadores.</param>
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