using Microsoft.EntityFrameworkCore.Storage;
using Reci_me.BL.Models;
using Reci_me.PL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reci_me.BL
{
    public enum Permission : int
    {
        EditUsers = 0,
        Write = 1
    }
    public class AccessManager
    {
        public bool CheckPermission(int alPermissions, Permission permission)
        {
            //Divides to remove any leading digits that aren't the permission being checked
            int returnval = (int)(alPermissions / Math.Pow(10, alPermissions));
            //Checks if the last digit is a 1 or a 0
            return int.IsOddInteger(returnval);
        }
        public bool CheckPermission(Guid id, Permission permission)
        {
            try
            {
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    tblAccessLevel tblAccessLevel = dc.tblAccessLevels.Where(c => c.Id == id).FirstOrDefault();

                    if (tblAccessLevel != null)
                    {
                        return CheckPermission(tblAccessLevel.Permissions, permission);
                    }
                    else
                    {
                        throw new Exception("Could not find the row");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<bool> Load(int alPermissions)
        {
            List<bool> bools = new List<bool>();
            foreach (Permission permission in Enum.GetValues(typeof(Permission)).Cast<Permission>())
            {
                bools.Add(CheckPermission(alPermissions, permission));
            }
            return bools;
        }
        public static List<AccessLevel> Load()
        {
            try
            {
                List<AccessLevel> rows = new List<AccessLevel>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    (from ac in dc.tblAccessLevels
                     select new
                     {
                         ac.Id,
                         ac.Description,
                         ac.Label,
                         ac.Permissions
                     }).Distinct().ToList()
                     .ForEach(ac => rows.Add(new AccessLevel
                     {
                         Id = ac.Id,
                         Description = ac.Description,
                         Label = ac.Label,
                         Permissions = ac.Permissions
                     }));
                }
                return rows;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<bool> Load(Guid id)
        {
            try
            {
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    tblAccessLevel tblAccessLevel = dc.tblAccessLevels.Where(c => c.Id == id).FirstOrDefault();

                    if (tblAccessLevel != null)
                    {
                        return Load(tblAccessLevel.Permissions);
                    }
                    else
                    {
                        throw new Exception("Could not find the row");
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async static Task<bool> Insert(string name, int permissions, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    if (rollback) transaction = dc.Database.BeginTransaction();

                    tblAccessLevel newrow = new tblAccessLevel();
                    newrow.Id = Guid.NewGuid();
                    newrow.Description = name;
                    newrow.Label = name;
                    newrow.Permissions = permissions;


                    dc.tblAccessLevels.Add(newrow);
                    int results = dc.SaveChanges();

                    if (rollback) transaction.Rollback();

                    return results == 1;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async static Task<int> Update(string name, int permissions, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    tblAccessLevel row = dc.tblAccessLevels.FirstOrDefault(c => c.Description == name);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();
                        row.Permissions = permissions;

                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();

                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async static Task<int> Delete(string name, bool rollback = false)
        {
            try
            {
                IDbContextTransaction transaction = null;
                using (ReciMeEntities dc = new ReciMeEntities())
                {

                    tblAccessLevel row = dc.tblAccessLevels.FirstOrDefault(c => c.Description == name);
                    int results = 0;
                    if (row != null)
                    {
                        if (rollback) transaction = dc.Database.BeginTransaction();

                        dc.tblAccessLevels.Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) transaction.Rollback();

                    }
                    else
                    {
                        throw new Exception("Row was not found.");
                    }
                    return results;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
