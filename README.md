# 🎓 ATIVIDADE SENAI - Entity Framework Core com MySQL

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%208.0-512BD4)](https://docs.microsoft.com/en-us/ef/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0-4479A1?logo=mysql&logoColor=white)](https://www.mysql.com/)

## 📋 SITUAÇÃO DE APRENDIZAGEM - TESTE DE BACK-END

### 🎯 Objetivo da Atividade

Desenvolver uma aplicação web em .NET 8.0 utilizando Entity Framework Core para conexão com MySQL, demonstrando a implementação de:
- Aplicação web ASP.NET Core
- Configuração do AppDbContext
- Configuração de ConnectionString no appsettings.json
- Integração com banco de dados MySQL
- Instalação e configuração dos packages necessários

### 📋 Requisitos Obrigatórios

✅ **Framework**: .NET 8.0  
✅ **Tipo de Projeto**: Web Application  
✅ **Banco de Dados**: MySQL  
✅ **ORM**: Entity Framework Core  
✅ **Configuração**: appsettings.json  
✅ **Serviços**: Program.cs configurado  

### 🛠️ Tecnologias Utilizadas

- **Framework**: .NET 8.0
- **Tipo de Projeto**: ASP.NET Core Web Application
- **ORM**: Entity Framework Core 8.0.18
- **Banco de Dados**: MySQL 8.0
- **Provider**: Pomelo.EntityFrameworkCore.MySql 8.0.3
- **Ferramentas**: Entity Framework Tools

## 📁 Estrutura do Projeto

```
AtividadeEF/
├── 📁 data/                          # Camada de dados (Entity Framework)
│   ├── 📄 Aluno.cs                   # Entidade Aluno
│   ├── 📄 Curso.cs                   # Entidade Curso
│   ├── 📄 AppDbContext.cs            # Contexto do Entity Framework ⭐
│   └── 📄 DesignTimeDbContextFactory.cs # Fábrica para migrações
├── 📁 Migrations/                    # Migrações do banco de dados
│   ├── 📄 20250714115736_InitialCreate.cs
│   ├── 📄 20250714115736_InitialCreate.Designer.cs
│   └── 📄 AppDbContextModelSnapshot.cs
├── 📁 Properties/                    # Configurações da aplicação
│   └── 📄 launchSettings.json
├── 📄 Program.cs                     # Configuração dos serviços ⭐
├── 📄 AtividadeEF.csproj            # Packages instalados ⭐
├── 📄 appsettings.json              # Configurações (ConnectionString) ⭐
└── 📄 appsettings.Development.json  # Configurações de desenvolvimento
```

### 🎯 Arquivos Principais da Atividade

⭐ **AppDbContext.cs**: Contexto do Entity Framework  
⭐ **Program.cs**: Configuração dos serviços do MySQL  
⭐ **appsettings.json**: String de conexão com o banco  
⭐ **AtividadeEF.csproj**: Packages do Entity Framework instalados  

## 🚀 PASSO A PASSO - CONFIGURAÇÃO DO PROJETO

### 📋 Pré-requisitos (OBRIGATÓRIOS)

Antes de iniciar, certifique-se de ter instalado:

- ✅ **[.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)** - Kit de desenvolvimento
- ✅ **[MySQL Server 8.0+](https://dev.mysql.com/downloads/mysql/)** - Servidor de banco de dados
- ✅ **[MySQL Workbench](https://dev.mysql.com/downloads/workbench/)** - Para validação do banco
- ✅ **[Visual Studio Code](https://code.visualstudio.com/)** - Editor recomendado

### �️ ETAPA 1: Criação do Projeto Web

```powershell
# Criar aplicação web .NET 8
dotnet new web -n AtividadeEF
cd AtividadeEF

# Verificar se é .NET 8.0
dotnet --version
# Deve retornar: 8.x.x
```

### 📦 ETAPA 2: Instalação dos Packages Necessários

```powershell
# Instalar Entity Framework Core
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.18

# Instalar Entity Framework Tools para migrações
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.18

# Instalar Provider MySQL (Pomelo)
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.3

# Instalar Provider SQL Server (opcional, para compatibilidade)
dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 8.0.18

# Restaurar packages
dotnet restore
```

### 🔧 ETAPA 3: Configuração do AppDbContext.cs

Criar o arquivo `data/AppDbContext.cs`:

```csharp
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    // DbSets para as entidades
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql(
                "server=localhost;database=meudatabase;user=root;password=1234",
                new MySqlServerVersion(new Version(8, 0, 34))
            );
        }
    }
}
```

### ⚙️ ETAPA 4: Configuração do appsettings.json

Editar o arquivo `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;database=meudatabase;user=root;password=1234"
  }
}
```

### 🔗 ETAPA 5: Configuração do Program.cs

Editar o arquivo `Program.cs`:

```csharp
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar o serviço do MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 34))
    ));

var app = builder.Build();

app.MapGet("/", () => "Hello World! - Entity Framework configurado!");

app.Run();
```

### � ETAPA 6: Criação das Entidades

Criar o arquivo `data/Aluno.cs`:

```csharp
using System.ComponentModel.DataAnnotations;

public class Aluno
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; } = string.Empty;
}
```

Criar o arquivo `data/Curso.cs`:

```csharp
using System.ComponentModel.DataAnnotations;

public class Curso
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}
```

### 🔧 ETAPA 7: Configuração para Migrações

Criar o arquivo `data/DesignTimeDbContextFactory.cs`:

```csharp
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        optionsBuilder.UseMySql(
            "server=localhost;database=meudatabase;user=root;password=1234",
            new MySqlServerVersion(new Version(8, 0, 34))
        );
        return new AppDbContext(optionsBuilder.Options);
    }
}
```

### 🗄️ ETAPA 8: Criação do Banco de Dados

```powershell
# Instalar EF Tools globalmente
dotnet tool install --global dotnet-ef

# Criar primeira migração
dotnet ef migrations add InitialCreate

# Aplicar migração (criar banco)
dotnet ef database update
```

### ▶️ ETAPA 9: Execução da Aplicação

```powershell
# Executar aplicação
dotnet run

# Ou executar com watch (hot reload)
dotnet watch run
```

## ✅ CRITÉRIOS DE AVALIAÇÃO

### 🎯 Será Avaliado:

- ✅ **Framework 8.0**: Projeto utilizando .NET 8.0
- ✅ **Projeto Web**: Criado com `dotnet new web`
- ✅ **AppDbContext**: Configurado corretamente
- ✅ **appsettings.json**: ConnectionString configurada
- ✅ **Program.cs**: Serviço MySQL adicionado
- ✅ **Packages**: Entity Framework instalado
- ✅ **Banco de Dados**: Criado com `dotnet ef database update`

### 🔍 Validação dos Requisitos:

1. **Verificar .NET 8.0**:
   ```powershell
   dotnet --version
   ```

2. **Verificar Packages**:
   ```powershell
   dotnet list package
   ```

3. **Verificar Migração**:
   ```powershell
   dotnet ef database update
   ```

4. **Verificar Banco no MySQL Workbench**:
   - Conectar ao MySQL
   - Verificar se existe database `meudatabase`
   - Verificar tabelas `Alunos` e `Cursos`

## 🚨 Solução de Problemas Comuns

### ❌ Erro: "dotnet ef não encontrado"
```powershell
dotnet tool install --global dotnet-ef
```

### ❌ Erro: "MySQL não conecta"
- Verificar se MySQL Server está rodando
- Confirmar usuário e senha
- Testar conexão: `mysql -u root -p`

### ❌ Erro: "Tabela não existe"
```powershell
dotnet ef database update
```

### ❌ Erro: "Package não encontrado"
```powershell
dotnet restore
```

## � Packages Utilizados

| Package | Versão | Função |
|---------|--------|--------|
| `Microsoft.EntityFrameworkCore` | 8.0.18 | ORM principal |
| `Microsoft.EntityFrameworkCore.Design` | 8.0.18 | Ferramentas para migrações |
| `Microsoft.EntityFrameworkCore.SqlServer` | 8.0.18 | Provider SQL Server |
| `Pomelo.EntityFrameworkCore.MySql` | 8.0.3 | Provider MySQL |

## � Comandos Importantes

```powershell
# Criar projeto web
dotnet new web -n AtividadeEF

# Instalar packages
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.18
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.18
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.3

# Gerenciar migrações
dotnet ef migrations add InitialCreate
dotnet ef database update
dotnet ef migrations remove

# Executar aplicação
dotnet run
dotnet watch run
```

## � ENTREGA DA ATIVIDADE

### 📁 Estrutura Final Esperada

```
AtividadeEF/
├── 📁 data/
│   ├── 📄 Aluno.cs                   ✅ Entidade criada
│   ├── 📄 Curso.cs                   ✅ Entidade criada
│   ├── 📄 AppDbContext.cs            ✅ Contexto configurado
│   └── 📄 DesignTimeDbContextFactory.cs ✅ Factory configurada
├── 📁 Migrations/
│   ├── 📄 *_InitialCreate.cs         ✅ Migração criada
│   ├── 📄 *_InitialCreate.Designer.cs ✅ Designer gerado
│   └── 📄 AppDbContextModelSnapshot.cs ✅ Snapshot criado
├── 📄 Program.cs                     ✅ Serviços configurados
├── 📄 AtividadeEF.csproj            ✅ Packages instalados
├── 📄 appsettings.json              ✅ ConnectionString configurada
└── 📄 appsettings.Development.json  ✅ Configurações de dev
```

### 🎯 Checklist de Entrega

- [ ] Projeto .NET 8.0 criado
- [ ] Tipo de projeto: Web Application
- [ ] AppDbContext.cs configurado
- [ ] ConnectionString em appsettings.json
- [ ] Serviços MySQL adicionados no Program.cs
- [ ] Packages Entity Framework instalados
- [ ] Migração criada e aplicada
- [ ] Banco de dados criado localmente
- [ ] Aplicação executando sem erros

### � Resultados/Entregas Esperados

1. **Projeto funcional** executando `dotnet run`
2. **Banco de dados criado** com comando `dotnet ef database update`
3. **Tabelas criadas** no MySQL (Alunos e Cursos)
4. **Aplicação acessível** via navegador

### 🔍 Validação no MySQL Workbench

Para validar se tudo está funcionando:

1. Abrir **MySQL Workbench**
2. Conectar ao servidor local
3. Verificar se existe o database `meudatabase`
4. Verificar se existem as tabelas:
   - `Alunos` (com colunas: Id, Nome, DataNascimento, Email)
   - `Cursos` (com colunas: Id, Nome)

## 🏆 Dicas para Aprovação

### ✅ Pontos Importantes:

1. **Use .NET 8.0**: Verifique com `dotnet --version`
2. **Configure corretamente**: appsettings.json com ConnectionString
3. **Serviços no Program.cs**: AddDbContext configurado
4. **Packages corretos**: Entity Framework 8.0.18
5. **Migração aplicada**: `dotnet ef database update` executado com sucesso

### ⚠️ Erros Comuns a Evitar:

- ❌ Não configurar ConnectionString no appsettings.json
- ❌ Não adicionar serviços no Program.cs
- ❌ Não instalar packages necessários
- ❌ Não aplicar migrações
- ❌ Usar versão errada do .NET

## 🎓 Sobre o SENAI

Este projeto foi desenvolvido como atividade prática do curso de **Desenvolvimento de Sistemas** do SENAI, demonstrando:

- Configuração de ambientes de desenvolvimento
- Implementação de ORM com Entity Framework
- Conexão com banco de dados MySQL
- Aplicação de padrões de desenvolvimento .NET

**Curso**: Desenvolvimento de Sistemas  
**Instituição**: SENAI  
**Módulo**: Back-End com .NET  
**Tecnologias**: .NET 8.0, Entity Framework Core, MySQL

---

## 👥 Desenvolvido por

**Nome**: Pablo Eduardo Silva  
**GitHub**: [@pabloedusilva](https://github.com/pabloedusilva)  
**Projeto**: Atividade Entity Framework SENAI

---

⭐ **Atividade SENAI - Entity Framework Core com MySQL**  
📚 **Demonstração prática de implementação de ORM em .NET 8.0**
