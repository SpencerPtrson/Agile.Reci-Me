using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL.Models
{
    public class Instruction
    {
        public Guid Id { get; set; }
        public Guid RecipeId { get; set; }
        public int InstructionNum { get; set; }
        public string Text { get; set; }
        public string? ImagePath { get; set; }
    }
}
