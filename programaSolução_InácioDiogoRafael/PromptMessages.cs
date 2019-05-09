namespace programaSolução_InácioDiogoRafael
{
    /// <summary>
    /// Classe que guarda as mensagens apresentadas no ecrã ao jogador
    /// através da funcionalidade da class Renderer
    /// </summary>
    static class PromptMessages
    {
        // Mensagem para quando for altura do jogador selecionar um fantasma
        public static string  SelectGhost = "Escreve o número correspondente" +
            " ao fantasma que queres selecionar, e depois carrega ENTER";

        // Mensagem para quando for altura do jogador selecionar um fantasma
        public static string SelectTile = "Escreve as coordenadas do " +
            "quadrado onde queres colocar o fantasma selecionado, no formato" +
            " 'x,y' sem as ''. e depois carrega ENTER";
    }
}