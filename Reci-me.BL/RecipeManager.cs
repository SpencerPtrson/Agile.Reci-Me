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
                    row.Instructions = "Do stuff";
                    row.IsHidden = false;
                    row.UserId = new Guid();
                    row.Servings = 1;
                    row.TotalTime = 20;
                    row.Name = "Spaghetti";
                    row.PrepTime = 5;

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

        public static List<BL.Models.Recipe> Load()
        {
            try
            {
                List<BL.Models.Recipe> rows = new List<BL.Models.Recipe>();
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    dc.tblRecipes.ToList().ForEach(s => rows.Add(new BL.Models.Recipe
                    {
                        Id = s.Id,
                        PrepTime = s.PrepTime,
                        Name = s.Name,
                        TotalTime= s.TotalTime,
                        Instructions= s.Instructions,
                        IsHidden= s.IsHidden,
                        UserId = new Guid(),
                        Servings = s.Servings
                    }));
                    return rows;
                }


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
                        row.Instructions = recipe.Instructions;
                        row.IsHidden = recipe.IsHidden;
                        row.UserId = recipe.UserId;
                        row.Name = recipe.Name;
                        row.TotalTime = recipe.TotalTime;
                        row.PrepTime = recipe.PrepTime;

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
