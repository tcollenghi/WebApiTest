# WebApiTest
Teste com webApi em .net core

Requisitos - Backend
Os jogadores deverão informar as entradas através das jogadas e o sistema deverá indicar
qual o jogador ganhador.
As entradas das jogadas deverão ser disponibilizadas através de APIs REST, além da
aplicação disponibilizar APIs para realização do cadastro dos jogadores e das jogadas
também.
Exemplos:
1. Entrada 1 – Jogador 1 e Jogada Pedra
2. Entrada 2 – Jogador 2 e Jogada Tesoura
3. Entrada 3 – Jogador 3 e Jogada Tesoura
4. Jogar
5. Resultado Jogador 1 Vitória
• Linguagem: C# .NET Core
• Documentar API (Swagger, Postman e/ou README.md)
• Teste unitários
o API
o Serviços
Observação
• Não utilizar banco de dados.
• O objetivo deste desafio é avaliar o seu conhecimento técnico, estilo de código,
documentação, conhecimento de arquiteturas, padrões de programação e boas
práticas. Faça disso uma oportunidade pra mostrar todo o seu conhecimento.

Pra deixar um pouco mais complicado coloquei "papel" como variável!

O Projeto esta organizado da seguinte forma: 

1 - API - obviamente é a API por si só. (isolada e com Swagger)

2 - Business - Principal regra de negócio, nessa classe esta definida as regras e se houve empate ou algum vencedor.

3 - Data - Camada para representar um modelo relacional, independente da base de dados

4 - Presentation - Camada de apresentação, exercício de bootstrap, responsividade das telas e performance para carregar um site.

5 - Services - Camada que server como DAO, porém com dados estaticos e informações em hardcode, podendo ser substituida por uma camada DAL, ou permanecer como services, dependendo da arquitetura do projeto





