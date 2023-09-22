using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_event__tarde.Domains
    {
    [Table(nameof(PresencaEvento))]
    public class PresencaEvento
        {
        [Key]
        public Guid IdPresencaEvento { get; set; } = Guid.NewGuid();

        [Required (ErrorMessage = "A situação da presença é obrigatória!")]
        [Column(TypeName = "BIT")]
        public bool Situacao { get; set; }

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
