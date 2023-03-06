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
                Name = "test",
                Servings = 1,
                TotalTime= 1,
                PrepTime= 1,
                MainImagePath = "img.png",
                UserId = new Guid(),
                IsHidden= true,
                CategoryId= new Guid(),
                //Ingredients = new List<Ingredient> { }
            };
            Assert.AreEqual(1, RecipeManager.Insert(recipe, true));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Recipe recipe = RecipeManager.LoadById(new Guid());
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

            Assert.AreEqual(1, RecipeManager.Delete(recipe.Id, true));
        }
    }
}