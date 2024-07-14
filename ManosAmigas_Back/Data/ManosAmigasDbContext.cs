using System;
using System.Collections.Generic;
using ManosAmigas_Back.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ManosAmigas_Back.Data
{
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
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Cargar la configuración desde el archivo appsettings.json
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                // Obtener el connection string
                var connectionString = configuration.GetConnectionString("DefaultConnection");

                // Configurar el contexto para usar SQL Server con el connection string
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
