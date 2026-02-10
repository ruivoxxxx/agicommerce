using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Produto
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; } = string.Empty;

    [MaxLength(500)]
    public string? Descricao { get; set; }

    [Required]
    [Range(0.01, double.MaxValue)]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    public int Estoque { get; set; }

    [Required]
    public string Categoria { get; set; } = string.Empty;

    public string? ImagemUrl { get; set; }

    public bool Ativo { get; set; } = true;

    public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
}