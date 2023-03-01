﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Reci_me.PL;

public partial class ReciMeEntities : DbContext
{
    public ReciMeEntities()
    {
    }

    public ReciMeEntities(DbContextOptions<ReciMeEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblAccessLevel> tblAccessLevels { get; set; }

    public virtual DbSet<tblIngredient> tblIngredients { get; set; }

    public virtual DbSet<tblMeasuringType> tblMeasuringTypes { get; set; }

    public virtual DbSet<tblRecipe> tblRecipes { get; set; }

    public virtual DbSet<tblRecipeIngredient> tblRecipeIngredients { get; set; }

    public virtual DbSet<tblRecipeCategory> tblRecipeCategories { get; set; }

    public virtual DbSet<tblRecipeInstruction> tblRecipeInstructions { get; set; }

    public virtual DbSet<tblUser> tblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Reci-me.DB;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblRecipeCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblRecip__3214EC07148F171E");

            entity.ToTable("tblRecipeCategory");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblAccessLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblAcces__3214EC07458199B5");

            entity.ToTable("tblAccessLevel");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Permissions)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblIngre__3214EC073B1AB8EB");

            entity.ToTable("tblIngredient");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMeasuringType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMeasu__3214EC077CFC063F");

            entity.ToTable("tblMeasuringType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblRecip__3214EC0778B5C51F");

            entity.ToTable("tblRecipe");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.MainImagePath)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblRecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblRecip__3214EC0707A40A8C");

            entity.ToTable("tblRecipeIngredient");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblRecipeInstruction>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblRecip__3214EC077C840630");

            entity.ToTable("tblRecipeInstruction");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.ImagePath)
                .HasMaxLength(250)
                .IsUnicode(false);
            entity.Property(e => e.Instruction)
                .HasMaxLength(600)
                .IsUnicode(false);
            entity.Property(e => e.Recipe_Id).HasColumnName("Recipe Id");
        });

        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC075BE3FE2B");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Picture)
                .HasMaxLength(50)
                .IsUnicode(false);
        });




        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
