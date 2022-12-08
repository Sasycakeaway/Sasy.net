using System;
using System.Collections.Generic;

namespace SvelteKitSample.Model
{
    public partial class RecoveryPassword
    {
        public Guid? Uuid { get; set; }
        public string FkEmail { get; set; } = null!;

        public virtual Utenti FkEmailNavigation { get; set; } = null!;
    }
}
