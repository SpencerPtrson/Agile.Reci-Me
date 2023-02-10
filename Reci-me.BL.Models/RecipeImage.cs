using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL.Models
{
    public class RecipeImage
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public bool IsThumbnail { get; set; }
    }
}
