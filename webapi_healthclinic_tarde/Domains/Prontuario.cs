using System;
using System.Collections.Generic;

namespace webapi_healthclinic_tarde.Domains;

public partial class Prontuario
{
    public Guid IdProntuario { get; set; } = Guid.NewGuid();

    public Guid IdConsulta { get; set; }

    public string Descricao { get; set; } = null!;

    public virtual Consulta? IdConsultaNavigation { get; set; } = null!;
}
