# 🎓 ATIVIDADE SENAI - Entity Framework Core com MySQL

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%208.0-512BD4)](https://docs.microsoft.com/en-us/ef/)
[![MySQL](https://img.shields.io/badge/MySQL-8.0-4479A1?logo=mysql&logoColor=white)](https://www.mysql.com/)

## 📋 OBJETIVO DA ATIVIDADE

Desenvolver uma aplicação web .NET 8.0 com Entity Framework Core e MySQL, implementando:
- Aplicação web ASP.NET Core
- Configuração do AppDbContext
- ConnectionString no appsettings.json
- Serviços MySQL no Program.cs
- Packages Entity Framework

## ✅ REQUISITOS OBRIGATÓRIOS

- **Framework**: .NET 8.0
- **Tipo**: Web Application
- **Banco**: MySQL
- **ORM**: Entity Framework Core
- **Configuração**: appsettings.json + Program.cs

## 🛠️ PRÉ-REQUISITOS

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server 8.0+](https://dev.mysql.com/downloads/mysql/)
- [MySQL Workbench](https://dev.mysql.com/downloads/workbench/)
- [Visual Studio Code](https://code.visualstudio.com/)

## 🚀 PASSO A PASSO

### 1. Criar Projeto Web
```powershell
dotnet new web -n AtividadeEF
cd AtividadeEF
```

### 2. Instalar Packages
```powershell
dotnet add package Microsoft.EntityFrameworkCore --version 8.0.18
dotnet add package Microsoft.EntityFrameworkCore.Design --version 8.0.18
dotnet add package Pomelo.EntityFrameworkCore.MySql --version 8.0.3
dotnet restore
```

### 3. Configurar appsettings.json
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

### 4. Configurar Program.cs
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

### 5. Criar AppDbContext (data/AppDbContext.cs)
```csharp
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Curso> Cursos { get; set; }
}
```

### 6. Criar Entidades
**data/Aluno.cs**:
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

**data/Curso.cs**:
```csharp
using System.ComponentModel.DataAnnotations;

public class Curso
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
}
```

### 7. Criar e Aplicar Migração
```powershell
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 8. Executar Aplicação
```powershell
dotnet run
```

## 🎯 CRITÉRIOS DE AVALIAÇÃO

- ✅ Framework .NET 8.0
- ✅ Projeto Web criado
- ✅ AppDbContext configurado
- ✅ ConnectionString no appsettings.json
- ✅ Serviços MySQL no Program.cs
- ✅ Packages Entity Framework instalados
- ✅ Banco criado com `dotnet ef database update`

## 🔍 VALIDAÇÃO

1. **Verificar .NET**: `dotnet --version`
2. **Verificar Packages**: `dotnet list package`
3. **Verificar Migração**: `dotnet ef database update`
4. **Verificar no MySQL Workbench**: tabelas `Alunos` e `Cursos`

## 🚨 PROBLEMAS COMUNS

- **"dotnet ef não encontrado"**: `dotnet tool install --global dotnet-ef`
- **"MySQL não conecta"**: Verificar se MySQL Server está rodando
- **"Tabela não existe"**: `dotnet ef database update`

## 📋 ENTREGA

### Estrutura Final:
```
AtividadeEF/
├── data/
│   ├── Aluno.cs
│   ├── Curso.cs
│   └── AppDbContext.cs
├── Migrations/
├── Program.cs
├── appsettings.json
└── AtividadeEF.csproj
```

### Checklist:
- [ ] Projeto .NET 8.0 funcional
- [ ] AppDbContext configurado
- [ ] ConnectionString em appsettings.json
- [ ] Serviços MySQL no Program.cs
- [ ] Banco criado com migrações
- [ ] Aplicação executando

---

**Desenvolvido por**: Pablo Eduardo Silva  
**GitHub**: [@pabloedusilva](https://github.com/pabloedusilva)  
**Projeto**: Atividade Entity Framework SENAI
