# FluentAssociation
Uma biblioteca para realizar data-mining para encontrar elementos fortemente conectados em uma base de dados.

## Introdução
Ok, imagina esse caso:
> Uma das maiores redes de varejo dos Estados Unidos descobriu, em seu gigantesco armazém de dados, que a venda de fraldas descartáveis estava associada à de cerveja. Em geral, os compradores eram homens, que saíam à noite para comprar fraldas e aproveitavam para levar algumas latinhas para casa. Os produtos foram postos lado a lado. Resultado: a venda de fraldas e cervejas disparou.

*Referências:*  
*Exame: [O que cerveja tem a ver com fraldas?](https://exame.abril.com.br/revista-exame/o-que-cerveja-tem-a-ver-com-fraldas-m0053931/)*  
*Medium: [A inteligencia em comprar Cerveja e Fraldas](https://medium.com/@wonderwanny/a-inteligencia-em-comprar-cerveja-e-fraldas-a617899556)*

### Modo de uso:

Instanciação e carregamento dos dados:  
![Inicio](https://user-images.githubusercontent.com/30809620/68982274-16399880-07e5-11ea-84ab-f3cf84707817.PNG)  
Ou se for aplicação web:  
![services](https://user-images.githubusercontent.com/30809620/68983591-754ddc00-07ea-11ea-8fb8-a4415ba6731f.PNG)  

Depois é só usar um dos seguintes métodos para retornar uma lista de combinações dos diferentes elementos da lista juntamente com as métricas de Suporte (Suport) e Confiança (Confidence):

* Get1ItemSets()  
* Get2ItemSets()  
* Get3ItemSets()  
* Get4ItemSets()



Exemplo nos testes:  
![teste](https://user-images.githubusercontent.com/30809620/68982733-f2775200-07e6-11ea-9b64-8fc5417e3fab.PNG)
