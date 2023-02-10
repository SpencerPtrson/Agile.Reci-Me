using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL.Models
{
    public class RecipeImage
    {
        public int Id { get; set; }
        public int RecipeId { get; set; }
        public bool IsThumbnail { get; set; }
    }
}
