using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace webapi_healthclinic_tarde.Domains;

public partial class Paciente
{
    public Guid IdPaciente { get; set; } = Guid.NewGuid();

    public Guid IdUsuario { get; set; }

    public DateOnly DataNascimento { get; set; }

    public string Telefone { get; set; } = null!;

    public string Rg { get; set; } = null!;

    public string Cpf { get; set; } = null!;

    public string Cep { get; set; } = null!;

    public string Endereco { get; set; } = null!;

    public virtual ICollection<Consulta>? Consulta { get; set; } = new List<Consulta>();

    public virtual Usuario? IdUsuarioNavigation { get; set; } = null!;
}
