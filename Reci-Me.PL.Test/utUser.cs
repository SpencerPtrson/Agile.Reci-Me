using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Reci_me.PL;

namespace Reci_Me.PL.Test
{
    public class utUser
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
            Assert.AreEqual(5, dc.tblUsers.Count());
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
            tblUser newrow = new tblUser();
            newrow.Id = Guid.NewGuid();
            newrow.Email = "Test Email";
            newrow.Password = "Test Password";
            newrow.Picture = "Test Picture Path";
            newrow.Description = "Test Description";
            newrow.FirstName = "Test First Name";
            newrow.LastName = "Test Last Name";
            newrow.AccessLevelId = dc.tblAccessLevels.FirstOrDefault().Id;

            dc.tblUsers.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblUser existingrow = dc.tblUsers.FirstOrDefault(c => c.Email == "Test Email");

            if (existingrow != null)
            {
                existingrow.Email = "Test Email Update";
                dc.SaveChanges();
            }

            tblUser row = dc.tblUsers.FirstOrDefault(c => c.Email == "Test Email Update");

            Assert.AreEqual(existingrow.Email, row.Email);
        }

        [Test]
        public void DeleteTest()
        {
            InsertTest();

            tblUser row = dc.tblUsers.FirstOrDefault(c => c.Email == "Test Email Update");

            if (row != null)
            {
                dc.tblUsers.Remove(row);
                dc.SaveChanges();
            }

            tblUser deletedrow = dc.tblUsers.FirstOrDefault(c => c.Email == "Test Email Update");

            Assert.IsNull(deletedrow);
        }
    }
}