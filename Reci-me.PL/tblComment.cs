using System;
using System.Collections.Generic;

namespace Reci_me.PL;

public partial class tblComment
{
    public Guid Id { get; set; }

    public Guid RecipeId { get; set; }

    public Guid UserId { get; set; }

    public string Review { get; set; } = null!;

    public int Rating { get; set; }
}
