using System;
using System.Collections.Generic;

namespace webapi_healthclinic_tarde.Domains;

public partial class Clinica
{
    public Guid IdClinica { get; set; }

    public string Endereco { get; set; } = null!;

    public string Unidade { get; set; } = null!;

    public string Cnpj { get; set; } = null!;

    public TimeSpan HoraAbertura { get; set; }

    public TimeSpan HoraEncerramento { get; set; }

    public virtual ICollection<Medico> Medicos { get; set; } = new List<Medico>();
}
