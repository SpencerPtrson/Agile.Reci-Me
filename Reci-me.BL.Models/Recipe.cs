using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Servings { get; set; }
        public string Instructions { get; set; }
        public double TotalTime { get; set; }
        public double PrepTime { get; set; }
        public int UserId { get; set; }
        public bool IsHidden { get; set; }
    }
}
