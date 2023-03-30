using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.BL.Test
{
    [TestClass]
    public class utIngredient
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Ingredient> ingredients = IngredientManager.Load();
            Assert.AreEqual(43, ingredients.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Ingredient ingredient = new Ingredient
            {
                Id = Guid.NewGuid(),
                Name = "Test",
                IsCommonAllergen = true,
            };
            Assert.AreEqual(1, IngredientManager.Insert(ingredient, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            Ingredient ingredient = IngredientManager.Load()[0];
            ingredient.Name = "Test";
            int results = IngredientManager.Update(ingredient, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Ingredient ingredient = IngredientManager.Load()[0];
            int results = IngredientManager.Delete(ingredient, true);
            Assert.AreEqual(1, results);
        }
    }
}