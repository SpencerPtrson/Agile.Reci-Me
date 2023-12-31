﻿using Microsoft.EntityFrameworkCore.Storage;
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
                                       r.MainImagePath
                                   }).Distinct().ToList();

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
                        MainImagePath = r.MainImagePath,
                    }));
                }
                return rows;
            }
            catch (Exception ex) { throw ex; }
        }

        public static Recipe LoadById(Guid id)
        {
            try
            {
                List<Recipe> rows = new List<Recipe>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    tblRecipe tblRecipe = dc.tblRecipes.Where(c => c.Id == id).FirstOrDefault();
                    if (tblRecipe != null)
                    {
                        Recipe recipe = new Recipe
                        {
                            Id = tblRecipe.Id,
                            Servings = tblRecipe.Servings,
                            IsHidden = tblRecipe.IsHidden,
                            UserId = tblRecipe.UserId,
                            Name = tblRecipe.Name,
                            TotalTime = tblRecipe.TotalTime,
                            PrepTime = tblRecipe.PrepTime,
                            MainImagePath = tblRecipe.MainImagePath,
                            Instructions = RecipeInstructionManager.Load(tblRecipe.Id).OrderBy(c => c.InstructionNum).ToList(),
                            Ingredients = RecipeIngredientManager.Load(tblRecipe.Id).OrderBy(c => c.Name).ToList(),
                            Comments = CommentManager.Load(tblRecipe.Id).ToList()
                        };
                        return recipe;
                    }
                    else
                    {
                        throw new Exception(RowError);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static Recipe LoadByName(string name)
        {
            try
            {
                List<Recipe> rows = new List<Recipe>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    tblRecipe tblRecipe = dc.tblRecipes.Where(c => c.Name == name).FirstOrDefault();
                    if (tblRecipe != null)
                    {
                        Recipe recipe = new Recipe
                        {
                            Id = tblRecipe.Id,
                            Servings = tblRecipe.Servings,
                            IsHidden = tblRecipe.IsHidden,
                            UserId = tblRecipe.UserId,
                            Name = tblRecipe.Name,
                            TotalTime = tblRecipe.TotalTime,
                            PrepTime = tblRecipe.PrepTime,
                            MainImagePath = tblRecipe.MainImagePath,
                            Instructions = RecipeInstructionManager.Load(tblRecipe.Id).OrderBy(c => c.InstructionNum).ToList(),
                            Ingredients = RecipeIngredientManager.Load(tblRecipe.Id).OrderBy(c => c.Name).ToList()
                        };
                        return recipe;
                    }
                    else
                    {
                        throw new Exception(RowError);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int Insert(Recipe recipe, bool rollback = false)
        {
            try
            {
                List<User> users = UserManager.Load();

                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblRecipe row = new tblRecipe();

                    row.Id = Guid.NewGuid();
                    row.IsHidden = false;
                    row.UserId = users[0].Id;
                    row.Servings = recipe.Servings;
                    row.TotalTime = recipe.TotalTime;
                    row.PrepTime = recipe.PrepTime;
                    row.Name = recipe.Name;
                    row.MainImagePath = recipe.MainImagePath;
                    row.CategoryId = recipe.CategoryId;

                    recipe.Id = row.Id;

                    dc.tblRecipes.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();
                }

                return results;
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Update(Recipe recipe, bool rollback = false)
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
            catch (Exception ex) { throw ex; }
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
            catch (Exception ex) { throw ex; }
        }
    }
}