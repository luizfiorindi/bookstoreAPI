# Bookstore API

API REST para gerenciamento de livros, desenvolvida com ASP.NET Core e .NET 8.

## Tecnologias

- .NET 8;
- ASP.NET Core Web API;
- Swagger/OpenAPI;
- Armazenamento em memória com `BookRepository` registrado como Singleton.

## Executando o projeto

Na pasta do projeto, execute:

```bash
dotnet run --project BookstoreAPI
```

Durante a execução, a documentação Swagger estará disponível em:

```text
https://localhost:<porta>/swagger
```

## Endpoints

Todos os endpoints de livros utilizam a rota base `/api/book`.

| Método | Rota | Descrição | Resposta principal |
|---|---|---|---|
| `GET` | `/api/book/health` | Verifica se a API está funcionando | `200 OK` |
| `POST` | `/api/book` | Cadastra um livro | `201 Created` |
| `GET` | `/api/book` | Lista todos os livros | `200 OK` |
| `GET` | `/api/book/{id}` | Busca um livro pelo ID | `200 OK` ou `404 Not Found` |
| `PUT` | `/api/book/{id}` | Atualiza um livro | `204 No Content` |
| `DELETE` | `/api/book/{id}` | Exclui um livro | `204 No Content` |
| `GET` | `/api/book/genres` | Lista os gêneros disponíveis | `200 OK` |

### Verificação de saúde

```http
GET /api/book/health
```

Resposta:

```text
Healthy
```

### Criar livro

```http
POST /api/book
Content-Type: application/json
```

```json
{
  "title": "O Hobbit",
  "author": "J. R. R. Tolkien",
  "genre": 3,
  "price": 49.90,
  "stock": 10
}
```

O campo `genre` deve utilizar o ID de um gênero válido. Em caso de sucesso:

```json
{
  "message": null,
  "created": true
}
```

Retorna `400 Bad Request` quando o livro não passa pelas regras de validação ou quando já existe um livro com o mesmo título e autor.

### Listar livros

```http
GET /api/book
```

Exemplo de resposta:

```json
[
  {
    "id": "00000000-0000-0000-0000-000000000000",
    "title": "O Hobbit",
    "author": "J. R. R. Tolkien",
    "genre": 3,
    "price": 49.90,
    "stock": 10
  }
]
```

### Buscar livro por ID

```http
GET /api/book/{id}
```

Retorna `404 Not Found` caso o ID não seja encontrado.

### Atualizar livro

```http
PUT /api/book/{id}
Content-Type: application/json
```

```json
{
  "title": "O Hobbit - Edição Especial",
  "author": "J. R. R. Tolkien",
  "genre": 3,
  "price": 59.90,
  "stock": 15
}
```

Retorna `204 No Content` quando a atualização é realizada, `404 Not Found` se o livro não existir ou `400 Bad Request` se os dados forem inválidos.

### Excluir livro

```http
DELETE /api/book/{id}
```

Retorna `204 No Content` quando o livro é excluído ou `404 Not Found` quando o ID não existe.

### Listar gêneros

```http
GET /api/book/genres
```

Exemplo de resposta:

```json
[
  {
    "id": 0,
    "name": "Ficcao"
  },
  {
    "id": 1,
    "name": "Romance"
  },
  {
    "id": 2,
    "name": "Mistério"
  },
  {
    "id": 3,
    "name": "Fantasia"
  },
  {
    "id": 4,
    "name": "Programacao"
  }
]
```

## Regras de validação

- O título deve possuir entre 3 e 120 caracteres;
- O autor deve possuir entre 3 e 120 caracteres;
- O gênero deve ser um valor válido do enum `Genre`;
- O preço não pode ser negativo;
- O estoque não pode ser negativo;
- Não é permitido cadastrar mais de um livro com o mesmo título e autor.

## Persistência

Os livros são armazenados em memória no `BookRepository`, usando o ciclo de vida Singleton. Isso permite compartilhar a mesma lista entre as requisições enquanto a aplicação estiver em execução.

Os dados são perdidos quando a API é encerrada ou reiniciada. Para persistência permanente, o repository deverá ser substituído por uma implementação utilizando banco de dados.
