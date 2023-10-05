using System;
using System.Collections.Generic;

namespace webapi_healthclinic_tarde.Domains;

public partial class Consulta
{
    public Guid IdConsulta { get; set; } = Guid.NewGuid();

    public Guid IdMedico { get; set; }

    public Guid IdPaciente { get; set; }

    public Guid IdSituacao { get; set; }

    public DateOnly Data { get; set; }

    public TimeOnly Horario { get; set; }

    public virtual ICollection<Comentario>? Comentarios { get; set; } = new List<Comentario>();

    public virtual Medico? IdMedicoNavigation { get; set; } = null!;

    public virtual Paciente? IdPacienteNavigation { get; set; } = null!;

    public virtual Situacao? IdSituacaoNavigation { get; set; } = null!;

    public virtual Prontuario? Prontuario { get; set; }
}
