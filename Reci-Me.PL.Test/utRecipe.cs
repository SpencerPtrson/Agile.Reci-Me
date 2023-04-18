using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Reci_me.PL;

namespace Reci_Me.PL.Test
{
    public class utRecipe
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
            Assert.AreEqual(4, dc.tblRecipes.Count());
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
            tblRecipe newrow = new tblRecipe();
            newrow.Id = Guid.NewGuid();
            newrow.Name = "Test Name";
            newrow.Servings = -1;
            newrow.TotalTime = -1.0;
            newrow.PrepTime = -1.0;
            newrow.UserId = dc.tblUsers.FirstOrDefault().Id;
            newrow.IsHidden = false;
            newrow.MainImagePath = "Test Image Path";
            newrow.CategoryId = dc.tblRecipeCategories.FirstOrDefault().Id;

            dc.tblRecipes.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblRecipe existingrow = dc.tblRecipes.FirstOrDefault(c => c.Name == "Test Name");

            if (existingrow != null)
            {
                existingrow.Name = "Test Name Update";
                dc.SaveChanges();
            }

            tblRecipe row = dc.tblRecipes.FirstOrDefault(c => c.Name == "Test Name Update");

            Assert.AreEqual(existingrow.Name, row.Name);
        }

        [Test]
        public void DeleteTest()
        {
            InsertTest();

            tblRecipe row = dc.tblRecipes.FirstOrDefault(c => c.Name == "Test Name Update");

            if (row != null)
            {
                dc.tblRecipes.Remove(row);
                dc.SaveChanges();
            }

            tblRecipe deletedrow = dc.tblRecipes.FirstOrDefault(c => c.Name == "Test Name Update");

            Assert.IsNull(deletedrow);
        }
    }
}