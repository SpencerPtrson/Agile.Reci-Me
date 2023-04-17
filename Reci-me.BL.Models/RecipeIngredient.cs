using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL.Models
{
    public class RecipeIngredient
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public Guid IngredientId { get; set; }
        public Nullable<double> Quantity { get; set; }
        public Guid MeasuringId { get; set; }
        public bool IsOptional { get; set; }

        public RecipeIngredient()
        {
            Quantity = null;
        }
    }
}
