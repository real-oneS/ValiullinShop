using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ValiullinShop.Models;

public partial class ValiullinShopDBContext : DbContext
{
    public ValiullinShopDBContext()
    {
    }

    public ValiullinShopDBContext(DbContextOptions<ValiullinShopDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ValiullinShopDB> ValiullinShopDBs { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=COMPUTER;Database=ValiullinShopDB;Trusted_Connection=true; Encrypt=false"/*"Server=server46;Database=ValiullinShopDB;User Id=stud;Password=stud;Encrypt=false"*/);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ValiullinShopDB>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Valiulli__3214EC0797042333");

            entity.ToTable("ValiullinShopDB");

            entity.Property(e => e.Image)
                .HasMaxLength(100)
                .IsUnicode(false);
        });
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users"); // Указываем, что сущность User связана с таблицей Users
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
