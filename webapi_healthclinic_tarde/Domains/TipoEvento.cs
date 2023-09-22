using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_event__tarde.Domains
    {
    [Table(nameof(TipoEvento))]
    [Index(nameof(Titulo), IsUnique = true)]
    public class TipoEvento
        {
        [Key]
        public Guid IdTipoEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O título do tipo de evento é obrigatório!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O título do tipo de evento deve ter entre 5 e 100 caracteres!")]
        public string? Titulo { get; set; }
        }
    }
