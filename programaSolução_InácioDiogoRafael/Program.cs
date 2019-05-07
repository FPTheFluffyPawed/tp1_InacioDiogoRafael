using System;

namespace programaSolução_InácioDiogoRafael
{
    class Program
    {

        static void Main(string[] args)
        {
            // CODIGO TESTE
            // verificação se consige buscar informação do Tile
            Board board = new Board();
            Renderer renderer = new Renderer();


            renderer.DrawNumbers();
            renderer.DrawPortals(board.Portals);
            renderer.DrawTiles(board.Tiles);

            /*Console.WriteLine("Cor = {0}    Tipo = {1}", board.GetTileColor(0, 0), board.GetTileType(0, 0));
            Console.WriteLine("Cor = {0}    Tipo = {1}", board.GetTileColor(0, 1), board.GetTileType(0, 1));
            Console.WriteLine("Cor = {0}    Tipo = {1}", board.GetTileColor(0, 2), board.GetTileType(0, 2));
            Console.WriteLine("Cor = {0}    Tipo = {1}", board.GetTileColor(0, 3), board.GetTileType(0, 3));
            Console.WriteLine("Cor = {0}    Tipo = {1}", board.GetTileColor(0, 4), board.GetTileType(0, 4));*/

            //parte complicada, testar introduzir fantasmas, não tem verificação mas podera ter no futuro em Player inputs
            // resumo: array utilizado para introduzir os valores, separar os valores, transformar em duas variaveis separadas e inserir para buscar
            // é IMPORTANTE que seja introduzido "<numero> <numero>" senão dá erro
            // é melhor ter a certeza com formas de verificar, claro!

            /*string[] iGhost = Console.ReadLine().Split();
            int insertedRow = int.Parse(iGhost[0]);
            int insertedColumn = int.Parse(iGhost[0]);
            board.SetGhostType(insertedRow, insertedColumn);
            Console.WriteLine(board.GetGhostType(insertedRow, insertedColumn));*/
        }
    }
}
