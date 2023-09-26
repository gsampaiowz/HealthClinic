using System;
using System.Collections.Generic;

namespace webapi_healthclinic_tarde.Domains;

public partial class Situacao
{
    public Guid IdSituacao { get; set; }

    public string TituloSituacao { get; set; } = null!;

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();
}
