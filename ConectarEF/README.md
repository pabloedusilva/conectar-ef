# ConectarEF

Este é um projeto ASP.NET Core que demonstra como conectar ao MySQL usando Entity Framework Core.

## Pré-requisitos

- .NET 8.0 SDK
- MySQL Server
- Visual Studio Code ou Visual Studio

## Configuração

1. **Instalar dependências:**
   ```bash
   dotnet restore
   ```

2. **Configurar string de conexão:**
   
   Edite o arquivo `appsettings.json` e configure sua string de conexão MySQL:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "server=localhost;database=SeuBancoDeDados;user=SeuUsuario;password=SuaSenha;"
     }
   }
   ```

3. **Executar o projeto:**
   ```bash
   dotnet run
   ```

## Estrutura do Projeto

- `Program.cs` - Ponto de entrada da aplicação e configuração do Entity Framework
- `AppDbContext.cs` - Contexto do Entity Framework para interação com o banco de dados
- `appsettings.json` - Configurações da aplicação incluindo string de conexão

## Pacotes NuGet Utilizados

- `Microsoft.EntityFrameworkCore` - Entity Framework Core
- `Microsoft.EntityFrameworkCore.Design` - Ferramentas de design do EF Core
- `Pomelo.EntityFrameworkCore.MySql` - Provider MySQL para Entity Framework Core

## Próximos Passos

1. Criar suas entidades (modelos) no projeto
2. Adicionar DbSets no `AppDbContext`
3. Executar migrations para criar o banco de dados:
   ```bash
   dotnet ef migrations add InitialCreate
   dotnet ef database update
   ```

## Problemas Corrigidos

✅ **Configuração do DbContext movida para antes de `builder.Build()`**
✅ **Adicionados using statements necessários**
✅ **Corrigido JSON malformado no appsettings.json**
✅ **Adicionadas referências dos pacotes NuGet necessários**
✅ **Formatação e indentação de código corrigidas**
