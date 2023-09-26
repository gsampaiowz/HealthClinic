using System;
using System.Collections.Generic;

namespace webapi_healthclinic_tarde.Domains;

public partial class TipoDeUsuario
{
    public Guid IdTipoDeUsuario { get; set; }

    public string NomeTipoDeUsuario { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
