using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webapi_event__tarde.Domains
    {
    [Table(nameof(Instituicao))]
    [Index(nameof(CNPJ), IsUnique = true)]
    public class Instituicao
        {
        [Key]
        public Guid IdInstituicao { get; set; } = Guid.NewGuid();

        [Column(TypeName = "CHAR(14)")]
        [Required(ErrorMessage = "O CNPJ da instituição é obrigatório!")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "O CNPJ deve ter 14 caracteres!")]
        public string? CNPJ { get; set; }

        [Column(TypeName = "VARCHAR(200)")]
        [Required(ErrorMessage = "O endereço da instituição é obrigatório!")]
        [StringLength(200, MinimumLength = 5, ErrorMessage = "O endereço deve ter entre 5 e 200 caracteres!")]
        public string? Endereco { get; set; }

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "O nome fantasia da instituição é obrigatório!")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "O nome fantasia deve ter entre 5 e 100 caracteres!")]
        public string? NomeFantasia { get; set; }
        }
    }
