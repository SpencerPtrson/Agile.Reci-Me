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
    public class MeasuringTypeManager
    {
        public static List<MeasuringType> Load()
        {
            // SELECT * FROM tblRecipeMeasuringType

            try
            {
                List<MeasuringType> rows = new List<MeasuringType>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    // Read database and select data list from tblPrograms and tblDegreeTypes
                    // Store each row into an array
                    var measuringtypes = (from mt in dc.tblMeasuringTypes
                                      orderby mt.Name
                                      select new
                                      {
                                          mt.Id,
                                          mt.Name,
                                          mt.Abbreviation
                                      }).ToList();

                    // Create a program instance for each array item, then add to rows (Load()'s return list)
                    foreach (var measuringType in measuringtypes)
                    {
                        MeasuringType mt = new MeasuringType();
                        mt.Id = measuringType.Id;
                        mt.Name = measuringType.Name;
                        mt.Abbreviation = measuringType.Abbreviation;
                        rows.Add(mt);
                    }
                    return rows;
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Insert(MeasuringType measuringType, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblMeasuringType row = new tblMeasuringType();
                    row.Id = Guid.NewGuid();
                    row.Name = measuringType.Name;
                    row.Abbreviation = measuringType.Abbreviation;
                    
                    // Backfill the Id
                    measuringType.Id = row.Id;

                    dc.tblMeasuringTypes.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Update(MeasuringType measuringType, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblMeasuringType row = dc.tblMeasuringTypes.Where(c => c.Id == measuringType.Id).FirstOrDefault(); ;

                    if (row != null)
                    {
                        row.Name = measuringType.Name;
                        row.Abbreviation = measuringType.Abbreviation;
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

        public static int Delete(MeasuringType measuringType, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) { dbContextTransaction = dc.Database.BeginTransaction(); }

                    tblMeasuringType row = dc.tblMeasuringTypes.Where(c => c.Id == measuringType.Id).FirstOrDefault(); ;

                    if (row != null)
                    {
                        dc.tblMeasuringTypes.Remove(row);
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
