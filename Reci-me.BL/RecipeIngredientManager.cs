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
    public static class RecipeIngredientManager
    {
        private const string RowError = "Row doesn't exist.";

        public static List<Ingredient> Load(Guid? recipeId = null)
        {
            try
            {
                List<Ingredient> rows = new List<Ingredient>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    var ingredients = (from r in dc.tblRecipes
                                       join ri in dc.tblRecipeIngredients on r.Id equals ri.RecipeId
                                       join i in dc.tblIngredients on ri.IngredientId equals i.Id
                                       where ri.RecipeId == recipeId || recipeId == null
                                       orderby ri.IngredientId
                                       select new
                                       {
                                           r.Id,
                                           i.Name,
                                           i.IsCommonAllergen
                                       }).Distinct().ToList();

                    ingredients.ForEach(r => rows.Add(new Ingredient
                    {
                        Id = r.Id,
                        Name = r.Name,
                        IsCommonAllergen = r.IsCommonAllergen
                    }));
                }
                return rows;
            }
            catch (Exception ex) { throw ex; }
        }

        public static RecipeIngredient LoadById(Guid id)
        {
            try
            {
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    tblRecipeIngredient tblRecipeIngredient = dc.tblRecipeIngredients.Where(c => c.Id == id).FirstOrDefault();
                    if (tblRecipeIngredient != null)
                    {
                        RecipeIngredient recipeingredient = new RecipeIngredient
                        {
                            Id = tblRecipeIngredient.Id,
                            RecipeId = tblRecipeIngredient.RecipeId,
                            IngredientId = tblRecipeIngredient.IngredientId,
                            Quantity = (double)tblRecipeIngredient.Quantity,
                            MeasuringId = tblRecipeIngredient.MeasuringId,
                            IsOptional = tblRecipeIngredient.IsOptional
                        };
                        return recipeingredient;
                    }
                    else throw new Exception(RowError);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Insert(RecipeIngredient recipeIngredient, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblRecipeIngredient row = new tblRecipeIngredient();

                    row.Id = Guid.NewGuid();
                    row.RecipeId = recipeIngredient.RecipeId;
                    row.IngredientId = recipeIngredient.IngredientId;
                    row.Quantity = recipeIngredient.Quantity;
                    row.MeasuringId = recipeIngredient.MeasuringId;
                    row.IsOptional = (bool)recipeIngredient.IsOptional;

                    recipeIngredient.Id = row.Id;

                    dc.tblRecipeIngredients.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Update(RecipeIngredient recipeIngredient, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblRecipeIngredient row = dc.tblRecipeIngredients.Where(s => s.Id == recipeIngredient.Id).FirstOrDefault();

                    if (row != null)
                    {
                        row.RecipeId = recipeIngredient.RecipeId;
                        row.IngredientId = recipeIngredient.IngredientId;
                        row.Quantity = recipeIngredient.Quantity;
                        row.MeasuringId = recipeIngredient.MeasuringId;
                        row.IsOptional = recipeIngredient.IsOptional;

                        results = dc.SaveChanges();

                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else throw new Exception(RowError);
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

                    tblRecipeIngredient row = dc.tblRecipeIngredients.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        dc.tblRecipeIngredients.Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else throw new Exception(RowError);
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}