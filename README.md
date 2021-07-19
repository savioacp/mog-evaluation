# mog-evaluation
Aplicação solicitada pela empresa Mog para avaliar meus conhecimentos.

## Escolhas de tecnologias
- **SQLite**: Sendo um banco de dados em arquivo, elimina a necessidade de ter um RDMS completo rodando.
- **Entity Framework**: ORM completo e de fácil configuração.

## Rotas
#### `/student` [GET, POST]
Listagem e criação de estudantes, respectivamente.

#### `/student/{id}` [GET, PUT, DELETE]
Requisição, alteração e deleção, respectivamente, de um estudante.

#### `/classes` [GET, POST]
Listagem e criação de matérias, respectivamente.

#### `/classes/{id}` [GET, PUT, DELETE]
Requisição, alteração e deleção, respectivamente, de uma matéria.

#### `/grades` [GET, POST]
Listagem e criação de notas, respectivamente.
Ao método GET poderá ser passado nos query params o id do estudante e o id da nota para o filtro.

#### `/grades/{id}` [GET, PUT, DELETE]
Requisição, alteração e deleção, respectivamente, de uma nota específica.

## Executando o projeto
`git clone https://github.com/savioacp/mog-evaluation`
`dotnet run`

Em instantes, acesse /swagger ou diretamente as rotas de recursos.
