# AtividadeEF

Este projeto é um exemplo de aplicação .NET 8 utilizando Entity Framework Core com MySQL para persistência de dados.

## Estrutura
- `Program.cs`: Ponto de entrada da aplicação.
- `data/`: Contém os modelos, contexto do banco (`AppDbContext`) e a fábrica de contexto para migrações (`DesignTimeDbContextFactory`).
- `Migrations/`: Migrações geradas pelo Entity Framework Core.
- `appsettings.json`: Configurações gerais da aplicação.
- `appsettings.Development.json`: Configurações específicas para ambiente de desenvolvimento.

## Como executar o projeto

1. **Pré-requisitos:**
   - .NET 8 SDK instalado
   - MySQL Server rodando localmente
   - Usuário e senha configurados conforme o `AppDbContext` (exemplo: usuário `root`, senha `1234`, banco `meudatabase`)

2. **Restaurar pacotes:**
   ```powershell
   dotnet restore
   ```

3. **Aplicar migrações ao banco de dados:**
   ```powershell
   dotnet ef database update
   ```
   > Certifique-se que o MySQL está rodando e o banco existe ou será criado.

4. **Executar a aplicação:**
   ```powershell
   dotnet run
   ```
   A aplicação estará disponível em `http://localhost:5000` (ou porta configurada).

## Testando as migrações
- As migrações estão na pasta `Migrations/`.
- Para criar novas migrações:
  ```powershell
  dotnet ef migrations add NomeDaMigracao
  ```
- Para atualizar o banco:
  ```powershell
  dotnet ef database update
  ```

## Observações
- O contexto está configurado para MySQL, mas o projeto possui dependências para SQL Server também (não utilizadas).
- Modifique a string de conexão conforme necessário em `AppDbContext.cs` e `DesignTimeDbContextFactory.cs`.

## Contato
Dúvidas ou sugestões, entre em contato com o autor do projeto.
