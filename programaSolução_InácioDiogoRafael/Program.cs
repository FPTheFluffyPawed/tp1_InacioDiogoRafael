using System;

namespace programaSolução_InácioDiogoRafael
{
    class Program
    {

        static void Main(string[] args)
        {
            // CODIGO TESTE
            // verificação se consige buscar informação do Tile
            Tile tile = new Tile();
            Console.WriteLine(tile.GetTileType(0, 0));
            Console.WriteLine(tile.GetTileType(0, 1));
            Console.WriteLine(tile.GetTileType(0, 2));
            Console.WriteLine(tile.GetTileType(0, 3));
            Console.WriteLine(tile.GetTileType(0, 4));
            Console.WriteLine(tile.GetGhostType(0, 2));

            //parte complicada, testar introduzir fantasmas, não tem verificação mas podera ter no futuro em Player inputs
            // resumo: array utilizado para introduzir os valores, separar os valores, transformar em duas variaveis separadas e inserir para buscar
            // é IMPORTANTE que seja introduzido "<numero> <numero>" senão dá erro
            // é melhor ter a certeza com formas de verificar, claro!
            string[] iGhost = Console.ReadLine().Split();
            int insertedRow = int.Parse(iGhost[0]);
            int insertedColumn = int.Parse(iGhost[0]);
            tile.SetGhostType(insertedRow, insertedColumn);
            Console.WriteLine(tile.GetGhostType(insertedRow, insertedColumn));
        }
    }
}
