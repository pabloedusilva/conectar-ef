using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    // DbSets personalizados
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Curso> Cursos { get; set; } // Nova tabela
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