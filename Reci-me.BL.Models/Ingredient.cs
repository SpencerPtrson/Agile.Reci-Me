using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL.Models
{
    public class Ingredient
    {
        [DisplayName("Ingredient")]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsCommonAllergen { get; set; }
    }
}
