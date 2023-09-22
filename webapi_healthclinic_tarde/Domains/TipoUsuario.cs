using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_event__tarde.Domains
    {
    [Table(nameof(TipoUsuario))]
    [Index(nameof(Titulo), IsUnique = true)]
    public class TipoUsuario
        {
        [Key]
        public Guid IdTipoUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O título do tipo de usuário é obrigatório!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O título do tipo de usuário deve ter entre 5 e 100 caracteres!")]
        public string? Titulo { get; set; }
        }
    }
