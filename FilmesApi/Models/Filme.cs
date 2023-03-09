using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models;

public class Filme
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required(ErrorMessage = "Título é obrigatório.")]
    [StringLength(30)]
    public string Titulo { get; set; }

    [Required(ErrorMessage = "Gênero é obrigatório.")]
    [MaxLength(50, ErrorMessage = "50 caracteres é o máximo.")]
    public string Genero { get; set; }

    [Required(ErrorMessage = "Duração é obrigatório.")]
    [Range(70,600, ErrorMessage = "A duração deve ter 70 e 600 minutos.")]
    public int Duracao { get; set; }
}
