using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebEco.Models.Entity;

public partial class TruongVanPhatContext : DbContext
{
    public TruongVanPhatContext()//contructor mặc định
    {
    }

    public TruongVanPhatContext(DbContextOptions<TruongVanPhatContext> options)
        : base(options)//contructor có chuỗi kết nối
    {
    }

    public virtual DbSet<Product> Products { get; set; }//Dbset ánh xạ qua table,[product] la cái model mình viết

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("name=WebEco");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_Productt");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
