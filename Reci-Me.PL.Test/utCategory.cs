using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Reci_me.PL;

namespace Reci_Me.PL.Test
{
    public class utCategory
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
            Assert.AreEqual(4, dc.tblRecipeCategories.Count());
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
            tblRecipeCategory newrow = new tblRecipeCategory();
            newrow.Id = Guid.NewGuid();
            newrow.Category = "Test Category Insert";

            dc.tblRecipeCategories.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblRecipeCategory existingrow = dc.tblRecipeCategories.FirstOrDefault(c => c.Category == "Test Category Insert");

            if (existingrow != null)
            {
                existingrow.Category = "Test Category Update";
                dc.SaveChanges();
            }

            tblRecipeCategory row = dc.tblRecipeCategories.FirstOrDefault(c => c.Category == "Test Category Update");

            Assert.AreEqual(existingrow.Category, row.Category);
        }

        [Test]
        public void DeleteTest()
        {
            InsertTest();

            tblRecipeCategory row = dc.tblRecipeCategories.FirstOrDefault(c => c.Category == "Test Category Update");

            if (row != null)
            {
                dc.tblRecipeCategories.Remove(row);
                dc.SaveChanges();
            }

            tblRecipeCategory deletedrow = dc.tblRecipeCategories.FirstOrDefault(c => c.Category == "Test Category Update");

            Assert.IsNull(deletedrow);
        }
    }
}