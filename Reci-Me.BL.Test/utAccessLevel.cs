using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.BL.Test
{
    [TestClass]
    public class utAccessLevel
    {
        [TestMethod]
        public void LoadTest()
        {
            List<AccessLevel> accessLevels = AccessManager.Load();
            Assert.AreEqual(2, accessLevels.Count);
        }
    }
}