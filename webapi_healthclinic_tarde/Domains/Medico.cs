﻿using System;
using System.Collections.Generic;

namespace webapi_healthclinic_tarde.Domains;

public partial class Medico
{
    public Guid IdMedico { get; set; }

    public Guid IdUsuario { get; set; }

    public Guid IdEspecialidade { get; set; }

    public Guid IdClinica { get; set; }

    public string Crm { get; set; } = null!;

    public virtual ICollection<Consulta> Consulta { get; set; } = new List<Consulta>();

    public virtual Clinica IdClinicaNavigation { get; set; } = null!;

    public virtual Especialidade IdEspecialidadeNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
