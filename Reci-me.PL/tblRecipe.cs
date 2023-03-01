using System;
using System.Collections.Generic;

namespace Reci_me.PL;

public partial class tblRecipe
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Servings { get; set; }

    public double TotalTime { get; set; }

    public double PrepTime { get; set; }

    public Guid UserId { get; set; }

    public bool IsHidden { get; set; }

    public string MainImagePath { get; set; } = null!;

    public Guid CategoryId { get; set; }
}
