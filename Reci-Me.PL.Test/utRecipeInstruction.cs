using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using Reci_me.PL;

namespace Reci_Me.PL.Test
{
    public class utRecipeInstruction
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
            Assert.AreEqual(22, dc.tblRecipeInstructions.Count()); ;
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
            tblRecipeInstruction newrow = new tblRecipeInstruction();
            newrow.Id = Guid.NewGuid();
            newrow.Recipe_Id = dc.tblRecipes.FirstOrDefault().Id;
            newrow.InstructionNum = -1;
            newrow.Instruction = "Test Instruction";
            newrow.ImagePath = null;

            dc.tblRecipeInstructions.Add(newrow);
            int result = dc.SaveChanges();

            Assert.IsTrue(result > 0);
        }

        [Test]
        public void UpdateTest()
        {
            InsertTest();

            tblRecipeInstruction existingrow = dc.tblRecipeInstructions.FirstOrDefault(c => c.Instruction == "Test Instruction");

            if (existingrow != null)
            {
                existingrow.Instruction = "Test Instruction Update";
                dc.SaveChanges();
            }

            tblRecipeInstruction row = dc.tblRecipeInstructions.FirstOrDefault(c => c.Instruction == "Test Instruction Update");

            Assert.AreEqual(existingrow.Instruction, row.Instruction);
        }

        [Test]
        public void DeleteTest()
        {
            InsertTest();

            tblRecipeInstruction row = dc.tblRecipeInstructions.FirstOrDefault(c => c.Instruction == "Test Instruction Update");

            if (row != null)
            {
                dc.tblRecipeInstructions.Remove(row);
                dc.SaveChanges();
            }

            tblRecipeInstruction deletedrow = dc.tblRecipeInstructions.FirstOrDefault(c => c.Instruction == "Test Instruction Update");

            Assert.IsNull(deletedrow);
        }
    }
}