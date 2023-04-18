using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Reci_me.PL;

namespace Reci_Me.PL.Test
{
    public class utRecipeIngredient
    {
        protected ReciMeEntities dc;
        protected IDbContextTransaction transaction;

        [SetUp]
        public void Setup()
        {
            dc = new ReciMeEntities();
            transaction = dc.Database.BeginTransaction();
        }

        [Test]
        public void LoadTest()
        {
            Assert.AreEqual(44, dc.tblRecipeIngredients.Count()); ;
            //Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            transaction.Rollback();
            transaction = null;
        }

        [Test]
        public void InsertTest()
        {
            tblRecipeIngredient newrow = new tblRecipeIngredient();
            newrow.Id = Guid.NewGuid();
            newrow.RecipeId = dc.tblRecipes.FirstOrDefault().Id;
            newrow.IngredientId = dc.tblIngredients.FirstOrDefault().Id;
            newrow.Quantity = -1;
            newrow.MeasuringId = dc.tblMeasuringTypes.FirstOrDefault().Id;
            newrow.IsOptional = false;

            dc.tblRecipeIngredients.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblRecipeIngredient existingrow = dc.tblRecipeIngredients.FirstOrDefault(c => c.Quantity == -1);

            if (existingrow != null)
            {
                existingrow.Quantity = -10;
                dc.SaveChanges();
            }

            tblRecipeIngredient row = dc.tblRecipeIngredients.FirstOrDefault(c => c.Quantity == -10);

            Assert.AreEqual(existingrow.Quantity, row.Quantity);
        }

        [Test]
        public void DeleteTest()
        {
            InsertTest();

            tblRecipeIngredient row = dc.tblRecipeIngredients.FirstOrDefault(c => c.Quantity == -10);

            if (row != null)
            {
                dc.tblRecipeIngredients.Remove(row);
                dc.SaveChanges();
            }

            tblRecipeIngredient deletedrow = dc.tblRecipeIngredients.FirstOrDefault(c => c.Quantity == -10);

            Assert.IsNull(deletedrow);
        }
    }
}