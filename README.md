# FornecedoresProdutoApp

FornecedoresProdutoApp é um projeto que permite realizar operações CRUD (Create, Read, Update, Delete) de forma integrada entre fornecedores e produtos. Este projeto utiliza Entity Framework (code first) para o acesso ao banco de dados e segue o padrão de arquitetura DDD (Domain-Driven Design). 

## Tecnologias Utilizadas

- .NET 8
- Entity Framework Core
- Padrão DDD (Domain-Driven Design)

## Configuração

### Connection String

Antes de iniciar o projeto, não se esqueça de configurar a connection string no arquivo `appsettings.json` para conectar ao banco de dados corretamente. Aqui está um exemplo de como a configuração pode se parecer:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=your_server;Database=your_database;User Id=your_username;Password=your_password;"
  }
}
