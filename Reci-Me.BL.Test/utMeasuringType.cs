using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.BL.Test
{
    [TestClass]
    public class utMeasuringType
    {
        [TestMethod]
        public void LoadTest()
        {
            List<MeasuringType> categories = MeasuringTypeManager.Load();
            Assert.AreEqual(20, categories.Count);
        }

        [TestMethod]
        public void InsertTest()
        {
            MeasuringType measuringType = new MeasuringType
            {
                Id = Guid.NewGuid(),
                Name = "Name Test",
                Abbreviation = "Abr. Test",
            };
            Assert.AreEqual(1, MeasuringTypeManager.Insert(measuringType, true));
        }

        [TestMethod]
        public void UpdateTest()
        {
            MeasuringType measuringType = MeasuringTypeManager.Load()[0];
            measuringType.Name = "Update Test";
            int results = MeasuringTypeManager.Update(measuringType, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod]
        public void DeleteTest()
        {
            MeasuringType measuringType = MeasuringTypeManager.Load()[0];
            int results = MeasuringTypeManager.Delete(measuringType, true);
            Assert.AreEqual(1, results);
        }
    }
}