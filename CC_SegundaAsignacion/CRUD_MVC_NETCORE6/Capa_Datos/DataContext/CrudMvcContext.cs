using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Capa_Datos.DataContext;

public partial class CrudMvcContext : DbContext
{
    public CrudMvcContext()
    {
    }

    public CrudMvcContext(DbContextOptions<CrudMvcContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Ingeniero> Ingenieros { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("server=localhost; database=crud_mvc; integrated security=true; Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Ingeniero>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ingenier__3213E83F6E6015A9");

            entity.ToTable("ingenieros");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Altura)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("altura");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.FechaNac)
                .HasColumnType("date")
                .HasColumnName("fecha_nac");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
