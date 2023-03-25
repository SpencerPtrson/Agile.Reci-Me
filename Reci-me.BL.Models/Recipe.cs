﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public double TotalTime { get; set; }
        public double PrepTime { get; set; }
        [DisplayName("Thumbnail")]
        public string MainImagePath { get; set; }
        public Guid UserId { get; set; }
        public bool IsHidden { get; set; }
        [DisplayName("Category")]
        public Guid CategoryId { get; set; }
        //public List<Ingredient> Ingredients { get; set; }
    }
}
