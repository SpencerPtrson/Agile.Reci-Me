using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.BL.Test
{
    [TestClass]
    public class utRecipeInstruction
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Instruction> instructions = RecipeInstructionManager.Load();
            Assert.AreEqual(22, instructions.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Instruction instruction = new Instruction
            {
                Id = Guid.NewGuid(),
                RecipeId = RecipeManager.Load()[0].Id,
                InstructionNum = -1,
                Text = "Insert Test",
                ImagePath = "TestImage"
            };
            Assert.AreEqual(1, RecipeInstructionManager.Insert(instruction, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            Instruction instruction = RecipeInstructionManager.Load()[0];
            instruction.Text = "Update Test";
            int results = RecipeInstructionManager.Update(instruction, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Instruction instruction = RecipeInstructionManager.Load()[0];
            int results = RecipeInstructionManager.Delete(instruction.Id, true);
            Assert.AreEqual(1, results);
        }
    }
}