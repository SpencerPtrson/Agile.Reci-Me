using System;
using System.Collections.Generic;

namespace Reci_me.PL;

public partial class tblAccessLevel
{
    public Guid Id { get; set; }

    public string Description { get; set; } = null!;

    public string Label { get; set; } = null!;

    public int Permissions { get; set; }
}
