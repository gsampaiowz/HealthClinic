using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_event__tarde.Domains
    {
    [Table(nameof(Evento))]
    public class Evento
        {
        [Key]
        public Guid IdEvento { get; set; } = Guid.NewGuid();

        [Column(TypeName = "DATE")]
        [Required(ErrorMessage = "A data do evento é obrigatória!")]
        public DateTime DataEvento { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome do evento é obrigatório!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome  deve ter entre 5 e 100 caracteres!")]
        public string? NomeEvento { get; set; }

        [Column(TypeName = "TEXT")]
        [Required(ErrorMessage = "A descrição do evento é obrigatória!")]
        public string? Descricao { get; set; }

        //CHAVES ESTRANGEIRAS
        [Required (ErrorMessage = "O tipo de evento é obrigatório!")]
        public Guid IdTipoEvento { get; set; }

        [ForeignKey(nameof(IdTipoEvento))]
        public TipoEvento? TipoEvento { get; set; }

        [Required(ErrorMessage = "A instituição é obrigatório!")]
        public Guid IdInstituicao { get; set; }

        [ForeignKey(nameof(IdInstituicao))]
        public Instituicao? Instituicao { get; set; }
        }
    }
