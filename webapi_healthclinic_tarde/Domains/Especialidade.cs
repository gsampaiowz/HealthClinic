using System;
using System.Collections.Generic;

namespace webapi_healthclinic_tarde.Domains;

public partial class Especialidade
{
    public Guid IdEspecialidade { get; set; } = Guid.NewGuid();

    public string NomeEspecialidade { get; set; } = null!;

    public virtual ICollection<Medico>? Medicos { get; set; } = new List<Medico>();
}
