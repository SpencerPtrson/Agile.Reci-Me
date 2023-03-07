using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.BL.Test
{
    [TestClass]
    public class utRecipe
    {
        [TestMethod]
        public void InsertTest()
        {
            Recipe recipe = new Recipe
            {
                Id = new Guid(),
                Name = "test",
                Servings = 1,
                TotalTime= 1,
                PrepTime= 1,
                MainImagePath = "img.png",
                UserId = new Guid(),
                IsHidden = true,
                CategoryId = new Guid()
            };
            Assert.AreEqual(1, RecipeManager.Insert(recipe, true));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Guid guid = new Guid("7c6c25a1-2223-4869-b157-1aea3acc9823");
            Recipe recipe = RecipeManager.LoadById(guid);
            recipe.Name = "test";

            int results = RecipeManager.Update(recipe, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            Recipe recipe = new Recipe
            {
                Name = "test",
                Servings = 1,
                TotalTime = 1,
                PrepTime = 1,
                MainImagePath = "img.png",
                UserId = new Guid(),
                IsHidden = true,
                CategoryId = new Guid(),
                //Ingredients = new List<Ingredient> { }
            };
            RecipeManager.Insert(recipe);

            Assert.AreEqual(1, RecipeManager.Delete(recipe.Id));
        }
    }
}