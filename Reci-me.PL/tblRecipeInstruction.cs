using System;
using System.Collections.Generic;

namespace Reci_me.PL;

public partial class tblRecipeInstruction
{
    public Guid Id { get; set; }

    public Guid Recipe_Id { get; set; }

    public int InstructionNum { get; set; }

    public string Instruction { get; set; } = null!;

    public string? ImagePath { get; set; }
}
