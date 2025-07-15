using System.ComponentModel.DataAnnotations;

public class Curso
{
    [Key]
    public int Id { get; set; }
    public string Nome { get; set; }
}