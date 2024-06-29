using ManosAmigas_Back.Sources.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ManosAmigas_Back
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<VolunteerActivity> VolunteerActivities { get; set; }
        public DbSet<Registration> Registrations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent Api

            #region Tables 
            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<VolunteerActivity>()
                .ToTable("VolunteerActivities");

            modelBuilder.Entity<Registration>()
                .ToTable("Registrations");
            #endregion

            #region Primary Key 
            modelBuilder.Entity<User>()
                .HasKey(users => users.Id);

            modelBuilder.Entity<VolunteerActivity>()
                 .HasKey(activities => activities.Id);

            modelBuilder.Entity<Registration>()
                 .HasKey(registrations => registrations.Id);
            #endregion

            #region Relationships 

            // Relación entre VolunteerActivity y User (Organizer)
            modelBuilder.Entity<VolunteerActivity>()
                .HasOne(va => va.Organizer)
                 .WithMany(u => u.VolunteerActivities)
                 .HasForeignKey(va => va.OrganizerId)
                 .OnDelete(DeleteBehavior.Cascade);

            // Relación entre Registration y User
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.User)
                .WithMany(u => u.Registrations)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Relación entre Registration y VolunteerActivity
            modelBuilder.Entity<Registration>()
                .HasOne(r => r.Activity)
                .WithMany(va => va.Registrations)
                .HasForeignKey(r => r.ActivityId)
                .OnDelete(DeleteBehavior.Restrict);

            // Clave única compuesta para garantizar que un usuario solo pueda registrarse una vez en cada actividad
            modelBuilder.Entity<Registration>()
                .HasIndex(r => new { r.UserId, r.ActivityId })
                .IsUnique();

            #endregion

            #region "Property configuration"


            #region Users
            // Configuración de la entidad User
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(u => u.LastName)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(u => u.Email)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(u => u.Password)
                    .IsRequired();
                entity.Property(u => u.UserType)
                    .IsRequired()
                    .HasMaxLength(20);
            });
            #endregion

            #region VolunteerActivities
            // Configuración de la entidad VolunteerActivity
            modelBuilder.Entity<VolunteerActivity>(entity =>
            {
                entity.HasKey(va => va.Id);
                entity.Property(va => va.Title)
                    .IsRequired()
                    .HasMaxLength(50);
                entity.Property(va => va.Description)
                    .IsRequired()
                    .HasMaxLength(500);
                entity.Property(va => va.StartDate)
                    .IsRequired();
                entity.Property(va => va.EndDate)
                    .IsRequired();
                entity.Property(va => va.Locations)
                    .IsRequired();

            });
            #endregion

            #region Registrations
            // Configuración de la entidad Registration
            modelBuilder.Entity<Registration>(entity =>
            {
                entity.HasKey(r => r.Id);
                entity.Property(r => r.RegistrationDate)
                    .IsRequired();

            });
            #endregion

            #endregion
        }
    }
}
