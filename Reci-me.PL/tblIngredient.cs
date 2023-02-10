using System;
using System.Collections.Generic;

namespace Reci_me.PL;

public partial class tblIngredient
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public bool IsCommonAllergen { get; set; }
}
