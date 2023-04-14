using System;
using System.Collections.Generic;

namespace Reci_me.PL;

public partial class tblRecipeImage
{
    public Guid Id { get; set; }

    public Guid Recipe_Id { get; set; }

    public bool IsThumbnail { get; set; }
}
