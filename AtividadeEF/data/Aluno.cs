
using System;
using System.ComponentModel.DataAnnotations;

public class Aluno
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; } = string.Empty;
}
