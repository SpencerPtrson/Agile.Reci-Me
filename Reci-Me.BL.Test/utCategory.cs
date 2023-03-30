using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.BL.Test
{
    [TestClass]
    public class utCategory
    {
        [TestMethod]
        public void LoadTest()
        {
            List<Category> categories = CategoryManager.Load();
            Assert.AreEqual(4, categories.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            Category category = new Category
            {
                Id = Guid.NewGuid(),
                Name = "Test",
            };
            Assert.AreEqual(1, CategoryManager.Insert(category, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            Category category = CategoryManager.Load()[0];
            category.Name = "Test";
            int results = CategoryManager.Update(category, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            Category category = CategoryManager.Load()[0];
            int results = CategoryManager.Delete(category, true);
            Assert.AreEqual(1, results);
        }
    }
}