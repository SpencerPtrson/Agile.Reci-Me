using System;
using System.Collections.Generic;

namespace Reci_me.PL;

public partial class tblUser
{
    public Guid Id { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Picture { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid AccessLevelId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;
}
