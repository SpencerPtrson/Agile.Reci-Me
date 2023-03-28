using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL.Models
{
    public class AccessLevel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Label { get; set; }
        public int Permissions { get; set; }
    }
}
