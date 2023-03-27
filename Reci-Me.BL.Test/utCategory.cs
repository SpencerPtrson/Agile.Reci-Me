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
    }
}