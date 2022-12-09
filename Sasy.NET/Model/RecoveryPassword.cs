using System;
using System.Collections.Generic;

namespace Sasy.NET.Model;

public partial class RecoveryPassword
{
    public Guid? Uuid { get; set; }

    public string FkEmail { get; set; } = null!;

    public virtual Utenti FkEmailNavigation { get; set; } = null!;
}
