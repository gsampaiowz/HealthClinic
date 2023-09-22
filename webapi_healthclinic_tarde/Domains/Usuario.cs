using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_event__tarde.Domains
    {
    [Table(nameof(Usuario))]
    [Index(nameof(Email), IsUnique = true)]
    public class Usuario
        {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do usuário é obrigatório!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome deve ter entre 5 e 100 caracteres!")]
        public string? Nome { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [EmailAddress(ErrorMessage = "Digite um e-mail válido!")]
        [Required(ErrorMessage = "O e-mail do usuário é obrigatório!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O e-mail deve ter entre 5 e 100 caracteres!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")]
        [Required(ErrorMessage = "A senha do usuário é obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "A senha deve ter entre 6 e 60 caracteres!")]
        public string? Senha { get; set; }

        //CHAVES ESTRANGEIRAS
        [Required(ErrorMessage = "O tipo de usuário é obrigatório!")]
        public Guid IdTipoUsuario { get; set; }
        
        [ForeignKey(nameof(IdTipoUsuario))]
        public TipoUsuario? TipoUsuario { get; set; }
        }
    }
