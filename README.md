# 1º Projeto de Linguagens de Programação I 2018/2019

## Autores
Diogo Heriques, a21802132

Inácio Amerio, a21803493

Rafael Silva, a21805637

[Repositório Git](https://github.com/FPTheFluffyPawed/tp1_InacioDiogoRafael)

## Organização do trabalho

Cada membro do grupo fez:

Diogo Henriques:

* Fez a estrutura inicial do código com o Rafael.
* Fez a classe `Portal.cs`.
* Criou as enumerações presentes no código.
* Fez pequenos ajustes em diversas partes do código de forma a corrigir _bugs_,
  corrigir identação e apagar código morto.
* Comentou o código juntamente com o Inácio.
* Criou o fluxograma, diagrama UML, ficheiro Doxygen e ficheiro Markdown.

Inácio Amerio:

* Apesar de não ter participado na estruturação inicial do programa, discutiu e 
  deu novas ideias à medida que desenvolvemos o projeto.
* Fez as classes `Tile.cs` e `Board.cs`.
* Fixou inúmeros problemas ao longo de todo o código, como _bugs_, etc... 
* Comentou o código juntamente com o Diogo.
* Ajudou o Diogo do diagrama UML.

Rafael Silva:

* Fez a estrutura inicial do código com o Diogo.
* Fez as classes `Ghost.cs`, `InputValidate.cs`, `PlayerInteractionHandler.cs`, 
  `PromptMessages.cs`, `Renderer.cs` e `Dungeon.cs`.
* Funcionou como guia do grupo.
* Ajudou o Diogo e o Inácio sempre que os mesmos tiveram dúvidas acerca de como
  fazer alguma parte do programa.
* Fez o ficheiro Markdown juntamente com o Diogo.

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

![<Diagrama UML>](images/Uml.png)

### Fluxograma 

![<Fluxograma>](images/Fluxograma.png)

### Conclusões
* Em conclusão com este projeto, ao utilizar uma combinação de enumerações e classes, combinação de código em equipa e tratamento de ideas em conjunto, podemos concordar que projetos grandes demoram a ser feitos, sendo preciso estruturação bem feita com comunicação clara entre os programadores na equipa.

### Referências

* A maneira que é usada no `Gameloop` para alternar entre os jogadores, utilizando o resto da divisão para ir alternadno entre os elementos do _Array_. Foi retirada de um post de _StackOverflow_.
* De resto, utilizámos a API do .NET, _StackOverFlow_ e _CodeProject.com_ como fontes de sabedoria quando nos deparámos com erros de compilação, e problemas ao utilizar os métodos como `Console.SetCursorPosition()`, `Console.SetWindowSize()`, `Console.CursorLeft`.

