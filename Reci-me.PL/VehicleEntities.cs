using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Reci_me.PL;

public partial class VehicleEntities : DbContext
{
    public VehicleEntities()
    {
    }

    public VehicleEntities(DbContextOptions<VehicleEntities> options)
        : base(options)
    {
    }

    public virtual DbSet<tblAccessLevel> tblAccessLevels { get; set; }

    public virtual DbSet<tblIngredient> tblIngredients { get; set; }

    public virtual DbSet<tblMeasuringType> tblMeasuringTypes { get; set; }

    public virtual DbSet<tblRecipe> tblRecipes { get; set; }

    public virtual DbSet<tblRecipeImage> tblRecipeImages { get; set; }

    public virtual DbSet<tblRecipeIngredient> tblRecipeIngredients { get; set; }

    public virtual DbSet<tblUser> tblUsers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Reci-me.DB;Integrated Security=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<tblAccessLevel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblAcces__3214EC07A0D59736");

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
            entity.HasKey(e => e.Id).HasName("PK__tblIngre__3214EC0735D24104");

            entity.ToTable("tblIngredient");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblMeasuringType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblMeasu__3214EC0724BE02B3");

            entity.ToTable("tblMeasuringType");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblRecipe>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblRecip__3214EC071A69F2A0");

            entity.ToTable("tblRecipe");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Instructions)
                .HasMaxLength(900)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<tblRecipeImage>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblRecip__3214EC075339ECAA");

            entity.ToTable("tblRecipeImage");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Recipe_Id).HasColumnName("Recipe Id");
        });

        modelBuilder.Entity<tblRecipeIngredient>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblRecip__3214EC07963EB549");

            entity.ToTable("tblRecipeIngredient");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<tblUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tblUser__3214EC079939ED27");

            entity.ToTable("tblUser");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(400)
                .IsUnicode(false);
            entity.Property(e => e.Email)
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
