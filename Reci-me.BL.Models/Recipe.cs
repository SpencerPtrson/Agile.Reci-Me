using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Servings { get; set; }

        [DisplayName("Total Time (in minutes)")]
        public double TotalTime { get; set; }

        [DisplayName("Preparation Time (in minutes)")]
        public double PrepTime { get; set; }

        [DisplayName("Thumbnail")]
        public string MainImagePath { get; set; }

        public Guid UserId { get; set; }
        public bool IsHidden { get; set; }
        [DisplayName("Category")]
        public Guid CategoryId { get; set; }
        //public List<Ingredient> Ingredients { get; set; }
        public List<Instruction> Instructions { get; set; }
    }
}
