using System;
using System.Collections.Generic;
using System.Text;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Propriedades da casa Portal. A direção para que estã virado e a cor.
    /// </summary>
    class Portal
    {
        // Propriedade de leitura e escrita, pública do tipo 
        // EnumPortalDirection.
        public EnumPortalDirection Direction {get; private set;}

        // Variável de instância.
        private EnumColor _color;

        // Lista do tipo Ghost.
        List<Ghost> freeGhosts;

        // Propriedade de leitura e escrita, pública do tipo Position.
        public Position pos {get; private set;}

        // Chama a classe Position.
        Position posToCheck;

        /// <summary>
        /// Construtor que contem as propriedades do portal, como a cor, 
        /// posição, direção, etc... .
        /// </summary>
        /// <param name="color"> Cor do portal. </param>
        /// <param name="startDirection"> A direção incial do portal. </param>
        /// <param name="X0"> X inicial. </param>
        /// <param name="Y0"> Y inicial. </param>
        public Portal(EnumColor color, EnumPortalDirection startDirection, 
            int X0, int Y0)
        {
            _color = color;
            Direction = startDirection;
            pos = new Position(X0,Y0);
            freeGhosts = new List<Ghost>(0);
            posToCheck = new Position(pos.x, pos.y);                           
        }

        /// <summary>
        /// Método do tipo EnumColor que retorna a cor do portal.
        /// </summary>
        /// <returns> A cor do portal. </returns>
        public EnumColor GetColor() => _color;

        /// <summary>
        /// Método para alterar a direção do portal.
        /// </summary>
        public void ChangeDirection()
        {
            // Controla o fluxo das direções usando a Enumeração
            // PortalDirection.
            switch (Direction)
            {
                case EnumPortalDirection.Left:
                    Direction = EnumPortalDirection.Up;
                    break;
                case EnumPortalDirection.Up:
                    Direction = EnumPortalDirection.Right;
                    break;
                case EnumPortalDirection.Right:
                    Direction = EnumPortalDirection.Down;
                    break;
                case EnumPortalDirection.Down:
                    Direction = EnumPortalDirection.Left;
                    break;
                default:
                    break;
            }
        }
        
        /// <summary>
        /// Método que verifica se há fantasmas na casa ao lado do portal para
        /// o lado que ele está virado.
        /// </summary>
        /// <param name="board"> Chama a classe board </param>
        public void FreeGhosts(Board board)
        {
            // Chama a classe Tile.
            Tile checkedTile;
            // Chama a classe Ghost.
            Ghost ghostToSave;

            // Diz que posição tem de se verificar consoante a direção do 
            // portal.
            switch (Direction)
            {
                case EnumPortalDirection.Left:
                    posToCheck.y = pos.x - 1;
                    break;
                case EnumPortalDirection.Up:
                    posToCheck.y = pos.y + 1;
                    break;
                case EnumPortalDirection.Right:
                    posToCheck.y = pos.x + 1;
                    break;
                case EnumPortalDirection.Down:
                    posToCheck.y = pos.y - 1;
                    break;
                default:
                    break;
            }

            // Acede ao array Tiles na classe Portal.
            checkedTile = board.Tiles[posToCheck.x, posToCheck.y];
            // Acede aos valores da propiredade ghostOnTile.
            ghostToSave = checkedTile.ghostOnTile;

            // Verifica se há um fantasma na posição desejada.
            if (ghostToSave != null)
            {
                /* Se houver, compara as cores do fantasma e do portal e se
                ambas forem iguais, adiciona o fantasma a lista de fantasmas
                salvos. */
                if (_color == ghostToSave.color)
                {
                    freeGhosts.Add(ghostToSave);
                    ghostToSave.owner.playerGhosts.Remove(ghostToSave);
                    ghostToSave.owner.ghostsOut.Add(ghostToSave);
                }
            }
        }
    }
}