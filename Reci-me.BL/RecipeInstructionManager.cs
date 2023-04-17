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
    public static class RecipeInstructionManager
    {
        private const string RowError = "Row doesn't exist.";

        public static List<Instruction> Load(Guid? recipeId = null)
        {
            try
            {
                List<Instruction> rows = new List<Instruction>();

                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    var instructions = (from ri in dc.tblRecipeInstructions
                                   join r in dc.tblRecipes on ri.Recipe_Id equals r.Id
                                   where ri.Recipe_Id == recipeId || recipeId == null
                                   orderby ri.InstructionNum
                                   select new
                                   {
                                       ri.Id,
                                       RecipeNum = r.Id,
                                       ri.InstructionNum,
                                       ri.Instruction,
                                       ri.ImagePath,
                                   }).Distinct().ToList();

                    instructions.ForEach(r => rows.Add(new Instruction
                    {
                        Id = r.Id,
                        RecipeId = r.RecipeNum,
                        InstructionNum = r.InstructionNum,
                        Text = r.Instruction,
                        ImagePath = r.ImagePath,
                    }));
                }
                return rows;
            }
            catch (Exception ex) { throw ex; }
        }

        public static Instruction LoadById(Guid id)
        {
            try
            {
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    tblRecipeInstruction tblRecipeInstruction = dc.tblRecipeInstructions.Where(c => c.Id == id).FirstOrDefault();
                    if (tblRecipeInstruction != null)
                    {
                        Instruction instruction = new Instruction
                        {
                            Id = tblRecipeInstruction.Id,
                            RecipeId = tblRecipeInstruction.Recipe_Id,
                            InstructionNum = tblRecipeInstruction.InstructionNum,
                            Text = tblRecipeInstruction.Instruction,
                            ImagePath = tblRecipeInstruction.ImagePath
                        };
                        return instruction;
                    }
                    else throw new Exception(RowError);
                }
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Insert(Instruction instruction, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblRecipeInstruction row = new tblRecipeInstruction();

                    row.Id = Guid.NewGuid();
                    row.Recipe_Id = instruction.RecipeId;
                    row.Instruction = instruction.Text;
                    row.ImagePath = instruction.ImagePath;

                    instruction.Id = row.Id;

                    dc.tblRecipeInstructions.Add(row);
                    results = dc.SaveChanges();

                    if (rollback) dbContextTransaction.Rollback();
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }

        public static int Update(Instruction instruction, bool rollback = false)
        {
            try
            {
                int results = 0;
                using (ReciMeEntities dc = new ReciMeEntities())
                {
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblRecipeInstruction row = dc.tblRecipeInstructions.Where(s => s.Id == instruction.Id).FirstOrDefault();

                    if (row != null)
                    {
                        row.InstructionNum = instruction.InstructionNum;
                        row.Instruction = instruction.Text;
                        row.ImagePath = instruction.ImagePath;

                        results = dc.SaveChanges();

                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else throw new Exception(RowError);
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
                    IDbContextTransaction dbContextTransaction = null;
                    if (rollback) dbContextTransaction = dc.Database.BeginTransaction();

                    tblRecipeInstruction row = dc.tblRecipeInstructions.Where(s => s.Id == id).FirstOrDefault();

                    if (row != null)
                    {
                        dc.tblRecipeInstructions.Remove(row);
                        results = dc.SaveChanges();
                        if (rollback) dbContextTransaction.Rollback();
                    }
                    else throw new Exception(RowError);
                }
                return results;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}