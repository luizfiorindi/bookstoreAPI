# Gerenciador de Livraria

> Desafio prático da formação C# da Rocketseat.

## Conheça o projeto

Construir uma API REST em .NET para gerenciar livros de uma livraria, com CRUD completo, validações, documentação via Swagger e herança entre classes para organizar o domínio.

---

## 1. Requisitos

A API deve permitir:

- [ ] Criar um livro;
- [ ] Visualizar todos os livros que foram criados;
- [ ] Visualizar um livro em específico;
- [ ] Editar informações de um livro;
- [ ] Excluir um livro.

### Campos obrigatórios

| Campo | Tipo | Obrigatório | Regras/Validações |
|---|---|---:|---|
| `id` | GUID | Sim | Gerado automaticamente pelo sistema. |
| `title` | string | Sim | Deve ter entre 2 e 120 caracteres. |
| `author` | string | Sim | Deve ter entre 2 e 120 caracteres. |
| `genre` | string | Sim | Deve ser um dos valores válidos: ficção, romance, mistério, .... |
| `price` | decimal | Sim | Deve ser maior ou igual a 0. |
| `stock` | int | Sim | Deve ser maior ou igual a 0. |

### Regras de negócio

- `title` e `author` não devem existir duplicados;
- `price` não pode ser negativo;
- `stock` não pode ser negativo;
- `genre` deve estar numa lista de gêneros válidos;
- Quando o livro é criado, preencher `CreatedAt` em alterações, atualizar `UpdatedAt`.

### Endpoints

Crie todos os endpoints necessários:

| Método | Endpoint | Descrição |
|---|---|---|
| `POST` | `/api/books` | Criar um novo livro. |
| `GET` | `/api/books` | Listar todos os livros (com filtros opcionais). |
| `GET` | `/api/books/{id}` | Buscar um livro pelo ID. |
| `PUT` | `/api/books/{id}` | Atualizar informações de um livro. |
| `DELETE` | `/api/books/{id}` | Excluir um livro da livraria. |

### Status Code

Retorne status codes apropriados para cada situação:

| Status | Quando usar | Descrição |
|---:|---|---|
| `200` | Consultas e atualização | Requisição bem-sucedida, dados retornados. |
| `201` | Criação de novo recurso | Recurso criado com sucesso. |
| `204` | Exclusão ou atualização | Operação concluída sem conteúdo para retornar. |
| `400` | Validações inválidas ou dados incorretos | Requisição malformada ou campos inválidos. |
| `404` | Recurso não encontrado | ID ou rota não corresponde a nenhum recurso. |
| `409` | Conflito de dados | Conflito com dados já existentes. |
| `500` | Erro inesperado no servidor | Exceções não tratadas ou falhas internas. |

---

## 2. Desenvolvendo o projeto

Para desenvolver esse projeto, recomendamos utilizar as principais tecnologias utilizadas durante o desenvolvimento do primeiro módulo da formação.

Caso tenha alguma dificuldade, você pode utilizar o fórum da Rocketseat para deixar sua dúvida.

Após terminar o desafio, caso queira, você pode dar o próximo passo e deixar a aplicação com a sua cara. Tente mudar o layout, cores ou até adicionar novas funcionalidades para ir além! 🚀

---

## 3. Entrega

Após concluir o desafio:

- Enviar a URL do código no GitHub.
- Opcionalmente, publicar um post no LinkedIn compartilhando o aprendizado e contando como foi a experiência.
- Opcionalmente, publicar um print do resultado final e marcar a Rocketseat.

---

## 4. Considerações finais

O intuito de um desafio é impulsionar o aprendizado. Dependendo do desafio, pode ser necessário ir além do que foi discutido em sala de aula.

Ter autonomia para buscar informações extras é uma habilidade importante para praticar durante o desenvolvimento.

Tenha calma: enfrentar desafios faz parte do processo de aprendizado.

---

## Checklist de tarefas

Use este checklist para organizar a entrega:

- [ ] Criar projeto .NET;
- [ ] Habilitar Swagger;
- [ ] Configurar pastas: Controllers, Models, entre outras;
- [ ] Criar modelo `Book` com campos: título, autor, gênero, preço, estoque;
- [ ] Implementar validações básicas (campos obrigatórios, tamanhos, duplicidade);
- [ ] Criar endpoints CRUD;
- [ ] Implementar `POST` para criar livro;
- [ ] Implementar `GET` para listar livros;
- [ ] Implementar `GET` para buscar por ID;
- [ ] Implementar `PUT` para atualizar livro;
- [ ] Implementar `DELETE` para excluir livro;
- [ ] Documentar endpoints no Swagger com exemplos;
- [ ] Testar manualmente todos os cenários (validação, sucesso, erros);
- [ ] Subir o código do Desafio no GitHub para ter um projeto a mais no portfólio;
- [ ] Escrever um README explicando como rodar e visualizar o portfólio.

---

## Detalhes

- **Tipo de projeto:** Desafio prático
- **Status:** Não iniciado

---

## Projetos relacionados

- Gerenciador de livraria — Rocketseat

