using System;
using System.Collections.Generic;

namespace Reci_me.PL;

public partial class tblRecipeIngredient
{
    public Guid Id { get; set; }

    public Guid RecipeId { get; set; }

    public Guid IngredientId { get; set; }

    public double Quantity { get; set; }

    public Guid MeasuringId { get; set; }
}
