using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Reci_me.PL;

namespace Reci_Me.PL.Test
{
    public class utMeasuringType
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
            Assert.AreEqual(20, dc.tblMeasuringTypes.Count());
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
            tblMeasuringType newrow = new tblMeasuringType();
            newrow.Id = Guid.NewGuid();
            newrow.Name = "Test MeasuringType Insert";
            newrow.Abbreviation = "abrInsert";

            dc.tblMeasuringTypes.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblMeasuringType existingrow = dc.tblMeasuringTypes.FirstOrDefault(c => c.Name == "Test MeasuringType Insert");

            if (existingrow != null)
            {
                existingrow.Name = "Test MeasuringType Update";
                dc.SaveChanges();
            }

            tblMeasuringType row = dc.tblMeasuringTypes.FirstOrDefault(c => c.Name == "Test MeasuringType Update");

            Assert.AreEqual(existingrow.Name, row.Name);
        }

        [Test]
        public void DeleteTest()
        {
            InsertTest();

            tblMeasuringType row = dc.tblMeasuringTypes.FirstOrDefault(c => c.Name == "Test MeasuringType Update");

            if (row != null)
            {
                dc.tblMeasuringTypes.Remove(row);
                dc.SaveChanges();
            }

            tblMeasuringType deletedrow = dc.tblMeasuringTypes.FirstOrDefault(c => c.Name == "Test MeasuringType Update");

            Assert.IsNull(deletedrow);
        }
    }
}