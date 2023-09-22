using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_event__tarde.Domains
    {
    [Table(nameof(ComentarioEvento))]
    public class ComentarioEvento
        {
        [Key]
        public Guid IdComentarioEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "O texto do comentário é obrigatório!")]
        public string? Texto { get; set; }

        [Column(TypeName = "BIT")]
        [Required(ErrorMessage = "A situação do comentário é obrigatória!")]
        public bool Exibe { get; set; }

        //CHAVES ESTRANGEIRAS
        [Required(ErrorMessage = "O evento é obrigatório!")]
        public Guid IdEvento { get; set; }

        [ForeignKey(nameof(IdEvento))]
        public Evento? Evento { get; set; }

        [Required(ErrorMessage = "O usuário é obrigatório!")]
        public Guid IdUsuario { get; set; }

        [ForeignKey(nameof(IdUsuario))]
        public Usuario? Usuario { get; set; }
        }
    }
