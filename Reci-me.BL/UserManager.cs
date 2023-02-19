using Castle.Core.Resource;
using Microsoft.EntityFrameworkCore.Storage;
using Reci_me.BL.Models;
using Reci_me.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL
{
    public class LoginFailureException : Exception
    {
        // Two constructors to handle the presence or
        // absence pf a developer thrown message
        public LoginFailureException() : base("Cannot log in with these credentials. Your IP address has been saved.")
        {

        }

        public LoginFailureException(string message) : base(message)
        {

        }
    }
    public static class UserManager
    {
        private static string GetHash(string password)
        {
            using (var hasher = SHA1.Create())
            {
                var hashbytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }

        }

        public static int DeleteAll()
        {
            try
            {
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    dc.tblUsers.RemoveRange(dc.tblUsers.ToList());
                    return dc.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static int Insert(User user, bool rollback = false)
        {
            try
            {
                int results = 0;

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction transaction = null;
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblUser row = new tblUser();

                    row.Id = Guid.NewGuid();
                    row.Email = user.Email;
                    row.Password = GetHash(user.Password);
                    row.Picture = user.ProfilePicture;
                    row.Description = user.ProfileDescription;
                    row.AccessLevelId = user.AccessLevelId;

                    dc.tblUsers.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

                    user.Id = row.Id;
                    return results;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return 0;
        }

        public static List<User> Load()
        {
            try
            {
                List<User> rows = new List<User>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    dc.tblUsers.ToList().ForEach(s => rows.Add(new User
                    {
                        Id = s.Id,
                        Email = s.Email,
                        Password = s.Password,
                        ProfilePicture = s.Picture,
                        ProfileDescription = s.Description,
                        AccessLevelId = s.AccessLevelId,
                    }));
                    return rows;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<User> LoadById(Guid id)
        {
            try
            {
                List<User> rows = new List<User>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    dc.tblUsers.Where(s => s.Id == id).ToList().ForEach(s => rows.Add(new User
                    {
                        Id = s.Id,
                        Email = s.Email,
                        Password= s.Password,
                        ProfilePicture = s.Picture,
                        ProfileDescription = s.Description,
                        AccessLevelId = s.AccessLevelId,
                    }));
                    return rows;
                }
            }
            catch (Exception)
            {

                throw;
            }
            //try
            //{
            //    using (ReciMeEntities dc = new ReciMeEntities())
            //    {
            //        tblUser tblUser = dc.tblUsers.Where(c => c.Id == id).FirstOrDefault();
            //        User user = new User();

            //        if (tblUser != null)
            //        {
            //            // Put the table row values into the object.
            //            user.Id = tblUser.Id;
            //            user.Email = tblUser.Email;
            //            user.Password = tblUser.Password;
            //            user.ProfilePicture = tblUser.Picture;
            //            user.ProfileDescription = tblUser.Description;
            //            user.AccessLevelId = tblUser.AccessLevelId;
            //            return user;
            //        }
            //        else
            //        {
            //            throw new Exception("Could not find the row");
            //        }
            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }
        public static bool Login(User user)
        {
            try
            {
                if (!string.IsNullOrEmpty(user.Email))
                {
                    if (!string.IsNullOrEmpty(user.Password))
                    {
                        using (ReciMeEntities dc = new ReciMeEntities())
                        {
                            tblUser tblUser = dc.tblUsers.FirstOrDefault(u => u.Email == user.Email);

                            if (tblUser != null)
                            {
                                // valid userid
                                if (tblUser.Password == GetHash(user.Password))
                                {
                                    // login happened
                                    user.Id = tblUser.Id;
                                    user.ProfileDescription = tblUser.Description;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException();
                                }

                            }
                            else
                            {
                                // invalid userid
                                throw new Exception("User Name could not be found.");
                            }
                        }
                    }
                    else
                    {
                        throw new Exception("Password was not set.");
                    }
                }
                else
                {
                    throw new Exception("User Name was not set.");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static List<User> LoadContact()
        {
            try
            {
                List<User> rows = new List<User>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    dc.tblUsers.ToList().ForEach(s => rows.Add(new User
                    {
                        Id = s.Id,
                        Email = s.Email,
                        Password = s.Password,
                        ProfilePicture = s.Picture,
                        ProfileDescription = s.Description,
                        AccessLevelId = s.AccessLevelId
                    }));
                    return rows;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static void Seed()
        {
            using (ReciMeEntities dc = new ReciMeEntities())
            {
                if (!dc.tblUsers.Any())
                {
                    User user = new User
                    {
                        Email = "maxwell.wilke3555@fvtc.edu",
                        Password = "Agile"
                    };
                    Insert(user);


                    user = new User
                    {
                        Email = "spencer.peterson0728@fvtc.edu",
                        Password = "Agile"
                    };
                    Insert(user);

                    user = new User
                    {
                        Email = "byron.baker5104@fvtc.edu",
                        Password = "Agile"
                    };
                    Insert(user);

                    user = new User
                    {
                        Email = "abigail.proudlock0180@fvtc.edu",
                        Password = "Agile"
                    };
                    Insert(user);

                    user = new User
                    {
                        Email = "john.yang9556@fvtc.edu",
                        Password = "Agile"
                    };
                    Insert(user);


                    //user = new User
                    //{
                    //    UserName = "bfoote",
                    //    FirstName = "Brian",
                    //    LastName = "Foote",
                    //    Password = "maple"
                    //};
                    //Insert(user);
                }
            }
        }
    }
}
