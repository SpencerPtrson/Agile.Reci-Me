using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Reci_me.PL;

namespace Reci_Me.PL.Test
{
    public class utIngredient
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
            Assert.AreEqual(43, dc.tblIngredients.Count());
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
            tblIngredient newrow = new tblIngredient();
            newrow.Id = Guid.NewGuid();
            newrow.Name = "Test Ingredient Insert";
            newrow.IsCommonAllergen = false;

            dc.tblIngredients.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblIngredient existingrow = dc.tblIngredients.FirstOrDefault(c => c.Name == "Test Ingredient Insert");

            if (existingrow != null)
            {
                existingrow.Name = "Test Ingredient Update";
                dc.SaveChanges();
            }

            tblIngredient row = dc.tblIngredients.FirstOrDefault(c => c.Name == "Test Ingredient Update");

            Assert.AreEqual(existingrow.Name, row.Name);
        }

        [Test]
        public void DeleteTest()
        {
            InsertTest();

            tblIngredient row = dc.tblIngredients.FirstOrDefault(c => c.Name == "Test Ingredient Update");

            if (row != null)
            {
                dc.tblIngredients.Remove(row);
                dc.SaveChanges();
            }

            tblIngredient deletedrow = dc.tblIngredients.FirstOrDefault(c => c.Name == "Test Ingredient Update");

            Assert.IsNull(deletedrow);
        }
    }
}