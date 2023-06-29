using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CRUDApplication.Models;

public partial class TrainingDbContext : DbContext
{
    public TrainingDbContext()
    {
    }

    public TrainingDbContext(DbContextOptions<TrainingDbContext> options)
        : base(options)
    {
    }


    public virtual DbSet<Employee> Employees { get; set; }

   

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Due to security reason im not providing connection string here");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.ToTable("Employee");

            entity.Property(e => e.Desgnation).HasMaxLength(50);
            entity.Property(e => e.Mob).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
