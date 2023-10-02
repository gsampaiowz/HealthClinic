using System;
using System.Collections.Generic;

namespace webapi_healthclinic_tarde.Domains;

public partial class Usuario
{
    public Guid IdUsuario { get; set; } = Guid.NewGuid();

    public Guid IdTipoDeUsuario { get; set; }

    public string NomeUsuario { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public virtual TipoDeUsuario? IdTipoDeUsuarioNavigation { get; set; } = null!;

    public virtual Medico? Medico { get; set; }

    public virtual Paciente? Paciente { get; set; }
}
