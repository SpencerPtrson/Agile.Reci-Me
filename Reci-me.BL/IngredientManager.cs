using Microsoft.EntityFrameworkCore.Storage;
using Reci_me.BL.Models;
using Reci_me.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL
{
    public class IngredientManager
    {
        public static List<Ingredient> Load()
        {
            try
            {
                List<Ingredient> rows = new List<Ingredient>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    // Store each row into an array
                    var ingredients = (from i in dc.tblIngredients
                                       select new
                                       {
                                           i.Id,
                                           i.Name,
                                           i.IsCommonAllergen
                                       }).ToList();

                    foreach (var ingredient in ingredients)
                    {
                        Ingredient i = new Ingredient();
                        i.Id = ingredient.Id;
                        i.Name = ingredient.Name;
                        i.IsCommonAllergen = ingredient.IsCommonAllergen;
                        rows.Add(i);
                    }
                    return rows;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        //public static List<Ingredient> Load(Guid? recipeId = null)
        //{
        //    try
        //    {
        //        List<Ingredient> rows = new List<Ingredient>();

        //        using (ReciMeEntities dc = new ReciMeEntities())
        //        {
        //            var ingredients = (from r in dc.tblRecipes
        //                               join ri in dc.tblRecipeIngredients on r.Id equals ri.RecipeId
        //                               join i in dc.tblIngredients on ri.IngredientId equals i.Id
        //                               where ri.RecipeId == recipeId || recipeId == null
        //                               orderby ri.IngredientId
        //                               select new
        //                               {
        //                                   r.Id,
        //                                   i.Name,
        //                                   i.IsCommonAllergen
        //                               }).Distinct().ToList();

        //            ingredients.ForEach(r => rows.Add(new Ingredient
        //            {
        //                Id = r.Id,
        //                Name = r.Name,
        //                IsCommonAllergen = r.IsCommonAllergen
        //            }));
        //        }
        //        return rows;
        //    }
        //    catch (Exception ex) { throw ex; }
        //}

        public static int Insert(Ingredient ingredient, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblIngredient row = new tblIngredient();
                    row.Id = Guid.NewGuid();
                    row.Name = ingredient.Name;
                    row.IsCommonAllergen = ingredient.IsCommonAllergen;

                    dc.tblIngredients.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Update(Ingredient ingredient, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblIngredient row = dc.tblIngredients.Where(i => i.Id == ingredient.Id).FirstOrDefault(); ;

                    if (row != null)
                    {
                        row.Name = ingredient.Name;
                        row.IsCommonAllergen = ingredient.IsCommonAllergen;
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

        public static int Delete(Ingredient ingredient, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblIngredient row = dc.tblIngredients.Where(i => i.Id == ingredient.Id).FirstOrDefault(); ;

                    if (row != null)
                    {
                        dc.tblIngredients.Remove(row);
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
