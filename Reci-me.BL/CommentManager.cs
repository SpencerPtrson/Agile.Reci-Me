using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.VisualStudio.Web.CodeGeneration.Design;
using Reci_me.BL.Models;
using Reci_me.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL
{
    public class CommentManager
    {
        public static List<Comment> Load(Guid id)
        {
            // SELECT * FROM tblRecipeComment

            try
            {
                List<Comment> rows = new List<Comment>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    // Read database and select data list from tblPrograms and tblDegreeTypes
                    // Store each row into an array
                    var comments = (from c in dc.tblComments
                                    join u in dc.tblUsers on c.UserId equals u.Id
                                    where c.RecipeId == id
                                      orderby c.UserId
                                      select new
                                      {
                                          c.Id,
                                          c.Review,
                                          c.Rating,
                                          c.UserId,
                                          u.FirstName, 
                                          u.LastName
                                      }).ToList();

                    // Create a program instance for each array item, then add to rows (Load()'s return list)
                    foreach (var comment in comments)
                    {
                        Comment c = new Comment();
                        c.Id = comment.Id;
                        c.Review = comment.Review;
                        c.Rating = comment.Rating;
                        c.UserId = comment.UserId;
                        c.Username = comment.FirstName + " " + comment.LastName;
                        rows.Add(c);
                    }
                    return rows;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Insert(Guid recipeId, Comment comment, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblComment row = new tblComment();
                    row.Id = Guid.NewGuid();
                    row.Review = comment.Review;
                    row.Rating = comment.Rating;
                    row.UserId = comment.UserId;
                    row.RecipeId = recipeId;
                    comment.Id = row.Id;

                    dc.tblComments.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Update(Comment comment, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblComment row = dc.tblComments.Where(c => c.Id == comment.Id).FirstOrDefault(); ;

                    if (row != null)
                    {
                        row.Review = comment.Review;
                        row.Rating = comment.Rating;
                        results = dc.SaveChanges();
                    }
                    else
                        throw new Exception("Row does not exist");

                    if (rollback) dbContextTransaction.Rollback();
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Delete(Comment comment, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblComment row = dc.tblComments.Where(c => c.Id == comment.Id).FirstOrDefault(); ;

                    if (row != null)
                    {
                        dc.tblComments.Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else
                        throw new Exception("Row does not exist");

                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
