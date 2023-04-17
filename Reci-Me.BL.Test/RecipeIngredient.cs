using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.BL.Test
{
    [TestClass]
    public class utRecipeIngredient
    {
        [TestMethod]
        public void LoadTest()
        {
            List<RecipeIngredient> recipeIngredients = RecipeIngredientManager.Load();
            Assert.AreEqual(44, recipeIngredients.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            RecipeIngredient recipeIngredient = new RecipeIngredient
            {
                Id = Guid.NewGuid(),
                RecipeId = RecipeManager.Load()[0].Id,
                IngredientId = IngredientManager.Load()[0].Id,
                Quantity = 5,
                MeasuringId = MeasuringTypeManager.Load()[0].Id,
                IsOptional = true
            };
            Assert.AreEqual(1, RecipeIngredientManager.Insert(recipeIngredient, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            RecipeIngredient recipeIngredient = RecipeIngredientManager.Load()[0];
            recipeIngredient.Quantity = -1;
            int results = RecipeIngredientManager.Update(recipeIngredient, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            RecipeIngredient recipeIngredient = RecipeIngredientManager.Load()[0];
            int results = RecipeIngredientManager.Delete(recipeIngredient.Id, true);
            Assert.AreEqual(1, results);
        }
    }
}