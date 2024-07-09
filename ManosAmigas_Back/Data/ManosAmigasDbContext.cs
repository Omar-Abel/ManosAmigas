using System;
using System.Collections.Generic;
using ManosAmigas_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace ManosAmigas_Back.Data;

public partial class ManosAmigasDbContext : DbContext
{
    public ManosAmigasDbContext()
    {
    }

    public ManosAmigasDbContext(DbContextOptions<ManosAmigasDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=OMAR-LAPTOPWORK\\SQLEXPRESS;Database=ManosAmigasDB;Trusted_Connection=True;MultipleActiveResultSets=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
