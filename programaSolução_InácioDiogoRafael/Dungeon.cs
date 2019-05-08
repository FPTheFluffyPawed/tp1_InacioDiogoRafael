using System;
using System.Collections.Generic;

namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// A classe utilizada para guardar os fantasmas que perderam uma luta.
    /// </summary>
    class Dungeon
    {
        // Lista para guardar os prisioneiros.
        List<Ghost> prisioners;

        /// <summary>
        /// Construtor para criar a classe, inicializando a lista com 0.
        /// </summary>
        public Dungeon()
        {
            prisioners = new List<Ghost>(0);
        }

        /// <summary>
        /// Getter para obter os prisioneiros dentro da lista.
        /// </summary>
        /// <returns>Fantasmas atualmentes na masmorra.</returns>
        public List<Ghost> GetPrisionerList() => prisioners;

        /// <summary>
        /// Metódo para atualizar e adicionar um fantasma a lista de 
        /// prisioneiros.
        /// </summary>
        /// <param name="newGuy">Fantasma a ser mandado para a 
        /// masmorra.</param>
        public void UpdatePrisionerList(Ghost newGuy)
        {
            // Adiciona o novo fantasma...
            prisioners.Add(newGuy);
            // Asinala o novo fantasma que esta na masmorra...
            newGuy.inDungeon = true;
            // Retira o fantasma a ser adicionado da lista de fantasmas do 
            // jogador...
            newGuy.owner.playerGhosts.Remove(newGuy);
            // Termina com adição do fantasma a lista de fantasmas na masmorra.
            newGuy.owner.dungeonGhosts.Add(newGuy);
        }

        /// <summary>
        /// Metódo para atualizar e libertar um fantasma da lista de 
        /// prisioneiros.
        /// </summary>
        /// <param name="freeGuy">Fantasma a ser libertado da masmorra.</param>
        public void ReleasePrisioner(Ghost freeGuy)
        {
            // Asinala o fantasma a ser libertado que já não está na
            // masmorra...
            freeGuy.inDungeon = false;
            // Adiciona o fantasma a ser libertado a lista de fantasmas do
            // jogador...
            freeGuy.owner.playerGhosts.Add(freeGuy);
            // Retira o fantasma a ser libertado da lista de fantasmas na
            // masmorra...
            freeGuy.owner.dungeonGhosts.Remove(freeGuy);
            // Termina com a remoção do fantasma da lista de prisioneiros.
            prisioners.Remove(freeGuy);
        }
    }
}