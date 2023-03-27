using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using Reci_me.BL.Models;
using Reci_me.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL
{
    public class CategoryManager
    {
        public static List<Category> Load()
        {
            // SELECT * FROM tblRecipeCategory

            try
            {
                List<Category> rows = new List<Category>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    // Read database and select data list from tblPrograms and tblDegreeTypes
                    // Store each row into an array
                    var categories = (from c in dc.tblRecipeCategories
                                    join r in dc.tblRecipes
                                    on c.Id equals r.CategoryId
                                    orderby c.Category
                                    select new
                                    {
                                        c.Id,
                                        c.Category
                                    }).Distinct().ToList();

                    // Create a program instance for each array item, then add to rows (Load()'s return list)
                    foreach (var category in categories)
                    {
                        Category c = new Category();
                        c.Id = category.Id;
                        c.Name = category.Category;
                        rows.Add(c);
                    }
                    return rows;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
