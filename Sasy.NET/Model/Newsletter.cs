using System;
using System.Collections.Generic;

namespace Sasy.NET.Model;

public partial class Newsletter
{
    public string FkEmail { get; set; } = null!;

    public Guid PkToken { get; set; }

    public virtual Utenti FkEmailNavigation { get; set; } = null!;
}
