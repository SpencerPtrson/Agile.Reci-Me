using System;
using System.Collections.Generic;

namespace Reci_me.PL;

public partial class tblAccessLevel
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string Permissions { get; set; } = null!;
}
