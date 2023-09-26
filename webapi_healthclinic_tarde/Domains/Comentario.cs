using System;
using System.Collections.Generic;

namespace webapi_healthclinic_tarde.Domains;

public partial class Comentario
{
    public Guid IdComentario { get; set; }

    public Guid IdConsulta { get; set; }

    public Guid IdPaciente { get; set; }

    public string Descricao { get; set; } = null!;

    public bool Exibe { get; set; }

    public virtual Consulta IdConsultaNavigation { get; set; } = null!;

    public virtual Paciente IdPacienteNavigation { get; set; } = null!;
}
