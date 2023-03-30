using Reci_me.BL;
using Reci_me.BL.Models;

namespace Reci_Me.BL.Test
{
    [TestClass]
    public class utUser
    {
        [TestMethod]
        public void LoadTest()
        {
            Assert.AreEqual(5, UserManager.Load().Count);
        }


        // UserManager needs to be altered to only return a single User
        //[TestMethod]
        //public void LoadByIdTest()
        //{
        //    User firstUser = UserManager.Load()[0];
        //    Guid loadedGuid = UserManager.LoadById(firstUser.Id).Id;
        //    Assert.AreEqual(firstUser.Id, loadedGuid);
        //}

        //[TestMethod]
        //public void InsertTest()
        //{
        //    AccessLevel accessLevel = AccessManager.Load()[0];

        //    User user = new User
        //    {
        //        Id = Guid.NewGuid(),
        //        Email = "test",
        //        Password = "test",
        //        FirstName = "test",
        //        LastName = "test",
        //        ProfileDescription = "test",
        //        ProfilePicture = "test",
        //        AccessLevel = accessLevel,
        //    };
        //    Assert.AreEqual(1, UserManager.Insert(user, true));
        //}

        [TestMethod()]
        public void UpdateTest()
        {
            User user = UserManager.Load()[0];
            user.FirstName = "test";

            int results = UserManager.Update(user, true);
            Assert.AreEqual(1, results);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            User user = UserManager.Load()[0];
            Assert.AreEqual(1, UserManager.Delete(user.Id, true));
        }
    }
}