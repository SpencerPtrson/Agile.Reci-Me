using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.BL.Test
{
    [TestClass]
    public class utRecipe
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(4, RecipeManager.Load().Count);
        }

        [TestMethod]
        public void LoadByIdTest()
        {
            Recipe firstRecipe = RecipeManager.Load()[0];
            Guid loadedGuid = RecipeManager.LoadById(firstRecipe.Id).Id;
            Assert.AreEqual(firstRecipe.Id, loadedGuid);
        }

        [TestMethod]
        public void LoadByNameTest()
        {
            Guid nameId = RecipeManager.LoadByName("Stuffed Peppers").Id;
            Guid firstId = RecipeManager.Load()[0].Id;
            Assert.AreEqual(nameId, firstId);
        }

        [TestMethod]
        public void InsertTest()
        {
            Recipe recipe = new Recipe
            {
                Id = Guid.NewGuid(),
                Name = "test",
                Servings = 1,
                TotalTime = 1,
                PrepTime = 1,
                MainImagePath = "img.png",
                UserId = UserManager.Load()[0].Id,
                IsHidden = true,
                CategoryId = CategoryManager.Load()[0].Id,
            };
            Assert.AreEqual(1, RecipeManager.Insert(recipe, true));
        }

        [TestMethod()]
        public void UpdateTest()
        {
            Recipe recipe = RecipeManager.Load()[0];
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
                UserId = Guid.NewGuid(),
                IsHidden = true,
                CategoryId = Guid.NewGuid(),
                //Ingredients = new List<Ingredient> { }
            };
            RecipeManager.Insert(recipe);

            Assert.AreEqual(1, RecipeManager.Delete(recipe.Id));
        }
    }
}