using Microsoft.EntityFrameworkCore.Storage;
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
                                      orderby c.Category
                                      select new
                                      {
                                          c.Id,
                                          c.Category
                                      }).ToList();

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
            catch (Exception ex) { throw ex; }
        }

        public static int Insert(Category category, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblRecipeCategory row = new tblRecipeCategory();
                    row.Id = Guid.NewGuid();
                    row.Category = category.Name;
                    category.Id = row.Id;

                    dc.tblRecipeCategories.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Update(Category category, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblRecipeCategory row = dc.tblRecipeCategories.Where(c => c.Id == category.Id).FirstOrDefault(); ;

                    if (row != null)
                    {
                        row.Category = category.Name;
                        results = dc.SaveChanges();
                    }
                    else
                        throw new Exception("Row does not exist");

                    if (rollback) dbContextTransaction.Rollback();
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Delete(Category category, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblRecipeCategory row = dc.tblRecipeCategories.Where(c => c.Id == category.Id).FirstOrDefault(); ;

                    if (row != null)
                    {
                        dc.tblRecipeCategories.Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else
                        throw new Exception("Row does not exist");

                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
