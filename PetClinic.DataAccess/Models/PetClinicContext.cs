using Microsoft.EntityFrameworkCore;

namespace PetClinic.DataAccess.Models
{
    public class PetClinicContext : DbContext
    {
        public DbSet<Medic> Medics { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<MedicSkill> MedicSkills { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentType> AppointmentTypes { get; set; }
        public DbSet<Tariff> Tariffs { get; set; }

        private readonly string _connectionString;

        public PetClinicContext() : base() { }

        public PetClinicContext(DbContextOptions<PetClinicContext> options)
            : base(options)
        { }

        //public PetClinicContext(string connectionString)
        //    : base(GetOptions(connectionString))
        //{
        //    _connectionString = connectionString;
        //}

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-QP53EQL;Initial Catalog=PetClinic;Integrated Security=SSPI;");
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<MedicSkill>(entity =>
            {
                entity.HasOne(e => e.Medic)
                    .WithMany(m => m.MedicSkills)
                    .HasForeignKey(e => e.MedicId)
                    .HasPrincipalKey(m => m.Id);

                entity.HasOne(e => e.Skill)
                    .WithMany(s => s.MedicSkills)
                    .HasForeignKey(e => e.MedicId)
                    .HasPrincipalKey(s => s.Id);
            });

            modelBuilder.Entity<Patient>(entity =>
            {
                entity.HasOne(e => e.Client)
                    .WithMany(c => c.Patients)
                    .HasForeignKey(e => e.ClientId)
                    .HasPrincipalKey(c => c.Id);
            });

            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.HasOne(e => e.AppointmentType)
                    .WithMany(at => at.Appointments)
                    .HasForeignKey(e => e.AppointmentTypeId)
                    .HasPrincipalKey(at => at.Id);
            });

            modelBuilder.Entity<Tariff>(entity =>
            {
                entity.HasOne(e => e.AppointmentType)
                    .WithMany(at => at.Tariffs)
                    .HasForeignKey(e => e.AppointmentTypeId)
                    .HasPrincipalKey(at => at.Id);
            });
        }

    }
}
