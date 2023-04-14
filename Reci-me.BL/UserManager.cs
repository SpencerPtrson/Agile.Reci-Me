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
        private const string RowError = "Row doesn't exist.";

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
                        AccessLevel = AccessManager.Load(s.AccessLevelId),
                        FirstName = s.FirstName,
                        LastName = s.LastName,
                    }));
                    return rows;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public static User LoadById(Guid id)
        {
            try
            {
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    tblUser tblUser = dc.tblUsers.Where(c => c.Id == id).FirstOrDefault();
                    if (tblUser != null)
                    {
                        User user = new User
                        {
                            Id = tblUser.Id,
                            Email = tblUser.Email,
                            Password = tblUser.Password,
                            ProfilePicture = tblUser.Picture,
                            ProfileDescription = tblUser.Description,
                            AccessLevel = AccessManager.Load(tblUser.AccessLevelId),
                            FirstName = tblUser.FirstName,
                            LastName = tblUser.LastName
                        };
                        return user;
                    }
                    else
                    {
                        throw new Exception(RowError);
                    }
                }
            }
            catch (Exception ex) { throw ex; }
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
                    row.AccessLevelId = user.AccessLevel.Id;
                    row.FirstName = user.FirstName;
                    row.LastName = user.LastName;

                    dc.tblUsers.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

                    user.Id = row.Id;
                    return results;
                }
            }
            catch (Exception ex) { throw ex; }
        }
        public static int Update(User user, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblUser row = dc.tblUsers.Where(u => u.Id == user.Id).FirstOrDefault();

                    if (row != null)
                    {
                        row.Email = user.Email;
                        if (user.Password != null) row.Password = GetHash(user.Password);
                        row.FirstName = user.FirstName;
                        row.LastName = user.LastName;
                        // Need to implement Profile Picture and Profile Description fields in database
                        row.AccessLevelId = user.AccessLevel.Id;

                        results = dc.SaveChanges();

                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else
                        throw new Exception(RowError);
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }
        public static int Delete(Guid id, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    // Prepare to create a transaction if the function/data will be rolled back
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    // Create a new row that grabs a data row from the table
                    tblUser row = dc.tblUsers.Where(u => u.Id == id).FirstOrDefault();

                    // If fetch was successful, update row data
                    if (row != null)
                    {
                        dc.tblUsers.Remove(row);
                        results = dc.SaveChanges();

                        // Rollback data if condition met
                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else
                        throw new Exception("Row does not exist");
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
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
            catch (Exception ex) { throw ex; }
        }

        private static string GetHash(string password)
        {
            using (var hasher = SHA1.Create())
            {
                var hashbytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(hasher.ComputeHash(hashbytes));
            }
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
                                    user.AccessLevel = AccessManager.Load(tblUser.AccessLevelId);
                                    user.FirstName = tblUser.FirstName;
                                    user.LastName = tblUser.LastName;
                                    user.ProfilePicture = tblUser.Picture;
                                    return true;
                                }
                                else
                                {
                                    throw new LoginFailureException();
                                    // or
                                    throw new LoginFailureException("Incorrect Password");
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
            catch (Exception ex) { throw ex; }
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
                        FirstName = s.FirstName,
                        LastName = s.LastName
                    }));
                    return rows;
                }
            }
            catch (Exception ex) { throw ex; }
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
                        Password = "Agile",
                        FirstName = "Max",
                        LastName = "Wilke",
                        ProfilePicture = "image path"
                    };
                    Insert(user);


                    user = new User
                    {
                        Email = "spencer.peterson0728@fvtc.edu",
                        Password = "Agile",
                        FirstName = "Spencer",
                        LastName = "Peterson",
                        ProfilePicture = "image path"
                    };
                    Insert(user);

                    user = new User
                    {
                        Email = "byron.baker5104@fvtc.edu",
                        Password = "Agile",
                        FirstName = "Byron",
                        LastName = "Baker",
                        ProfilePicture = "image path"
                    };
                    Insert(user);

                    user = new User
                    {
                        Email = "abigail.proudlock0180@fvtc.edu",
                        Password = "Agile",
                        FirstName = "Abby",
                        LastName = "Proudlock",
                        ProfilePicture = "image path"
                    };
                    Insert(user);

                    user = new User
                    {
                        Email = "john.yang9556@fvtc.edu",
                        Password = "Agile",
                        FirstName = "John",
                        LastName = "Yang",
                        ProfilePicture = "image path"
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
