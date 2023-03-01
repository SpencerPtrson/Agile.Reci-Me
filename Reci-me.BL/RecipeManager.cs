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
    public static class RecipeManager
    {
        private const string RowError = "Row doesn't exist.";

        public static List<Recipe> Load(Guid? categoryId = null)
        {
            try
            {
                List<Recipe> rows = new List<Recipe>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    var recipes = (from r in dc.tblRecipes
                                   join rInst in dc.tblRecipeInstructions on r.Id equals rInst.Recipe_Id
                                   join rIng in dc.tblRecipeIngredients on r.Id equals rIng.RecipeId
                                   join ing in dc.tblIngredients on rIng.IngredientId equals ing.Id
                                   join m in dc.tblMeasuringTypes on rIng.MeasuringId equals m.Id
                                   join c in dc.tblRecipeCategories on r.CategoryId equals c.Id
                                   where r.CategoryId == categoryId || categoryId == null
                                   orderby c.Category
                                   select new
                                   {
                                       RecipeId = r.Id,
                                       RecipeName = r.Name,
                                       r.Servings,
                                       r.TotalTime,
                                       r.PrepTime,
                                       r.UserId,
                                       r.IsHidden,
                                       CategoryId = c.Id,
                                   }).ToList();

                    recipes.ForEach(r => rows.Add(new Recipe
                    {
                        Id = r.RecipeId,
                        Name = r.RecipeName,
                        Servings = r.Servings,
                        TotalTime = r.TotalTime,
                        PrepTime = r.PrepTime,
                        UserId = r.UserId,
                        IsHidden = r.IsHidden,
                        CategoryId = r.CategoryId,
                    }));
                }
                return rows;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int Insert(BL.Models.Recipe recipe, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblRecipe row = new tblRecipe();

                    //row.Id = dc.tblRecipes.Any() ? dc.tblRecipes.Max(s => s.Id) + 1 : 1;
                    row.Id = new Guid();
                    row.IsHidden = false;
                    row.UserId = new Guid();
                    row.Servings = 1;
                    row.TotalTime = 20;
                    row.PrepTime = 5;
                    row.Name = "Spaghetti";
                    row.MainImagePath = "Image Path";
                    row.CategoryId = new Guid();

                    recipe.Id = row.Id;

                    dc.tblRecipes.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();
                }

                return results;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int Update(BL.Models.Recipe recipe, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblRecipe row = dc.tblRecipes.Where(s => s.Id == recipe.Id).FirstOrDefault();

                    if (row != null)
                    {
                        row.Servings = recipe.Servings;
                        row.IsHidden = recipe.IsHidden;
                        row.UserId = recipe.UserId;
                        row.Name = recipe.Name;
                        row.TotalTime = recipe.TotalTime;
                        row.PrepTime = recipe.PrepTime;
                        row.MainImagePath = recipe.MainImagePath;

                        results = dc.SaveChanges();

                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception(RowError);
                    }
                }

                return results;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblRecipe row = dc.tblRecipes.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        dc.tblRecipes.Remove(row);
                        results = dc.SaveChanges();

                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else
                    {
                        throw new Exception(RowError);
                    }
                }
                return results;

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}