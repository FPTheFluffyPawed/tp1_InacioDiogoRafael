# 1º Projeto de Linguagens de Programação I 2018/2019

## Autores
Diogo Heriques, a21802132

Inácio Amerio, numero

Rafael Silva, a21805637

## Organização do trabalho

Cada membro do grupo fez:

Diogo Henriques:
* Fill

Inácio Amerio:
* Fill

Rafael Silva:
* Fill

## Descrição da solução

### Estrutura do Programa
O programa foi estruturado em:

* Dados de Estrutura (As _enum_, _Position, PrompMessage, Player_)
* Elementos de Estrutura (_Board, Dungeon, Tile_)
* Agentes do jogo (_Ghost, Portal_)
* Ajudantes de utilização (_InputValidate, PlayerInteractionHandler, GhostFight_)
* Estrutura de Jogo e Apresentação (_Game, Program, Renderer_)

O principio que tentámos seguir foi que as várias classes interagissem com o jogo de uma forma crescente da lista acima, os Agentes de Jogo iriam aceder aos elementos como a Board para garantir que a interação com outros agentes fosse válida.

Os dados de estrutura não fazem nada senão guardar informação que vái ser usada pelos Elementos de Estrutura e Agentes de Jogo.

Os Agentes do Jogo são os elementos mais dinâmicos do programa, afetados pelas regras estabelecidas nos Ajudantes de Utilização.

Os Ajudantes de utilização são classes `static`, tratam de lógica entre jogador->jogo e entre agentes, a lógica do jogo que trata das regras do jogo em si são aplicadas nestas classes e o jogador tem de passar por elas para poder interagir com o jogo.

As classes de Estrutura de Jogo e Apresentação "ordenam" todas as anteriores, inicializando-as e apresentando os dados, agentes, e elementos, como estão na posição mais baixa da lista não são manipulados por nenhuma outra classe, sendo apenas chamados a fazer a sua função.
Pode ser considerado a _Front End_ do programa.

### Diagrama UML
* Um diagrama UML de classes simples (i.e., sem indicação dos membros da classe) descrevendo a estrutura de classes.

### Fluxograma
* Um fluxograma mostrando o funcionamento do programa

### Conclusões
* Conclusões que não sei programar

### Referências

* A maneira que é usada no `Gameloop` para alternar entre os jogadores, utilizando o resto da divisão para ir alternadno entre os elementos do _Array_. Foi retirada de um post de _StackOverflow_.
* De resto, utilizámos a API do .NET, _StackOverFlow_ e _CodeProject.com_ como fontes de sabedoria quando nos deparámos com erros de compilação, e problemas ao utilizar os métodos como `Console.SetCursorPosition()`, `Console.SetWindowSize()`, `Console.CursorLeft`.

