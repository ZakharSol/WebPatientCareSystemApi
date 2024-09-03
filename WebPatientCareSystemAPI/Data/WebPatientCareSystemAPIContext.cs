using Microsoft.EntityFrameworkCore;
using WebPatientCareSystemAPI.Models;

namespace WebPatientCareSystemAPI.Data
{

    public class WebPatientCareSystemAPIContext : DbContext
    {

        public WebPatientCareSystemAPIContext(DbContextOptions<WebPatientCareSystemAPIContext> options)
: base(options)
        {
        }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Specialization> Specializations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cabinet>().ToTable("Cabinets");
            modelBuilder.Entity<District>().ToTable("Districts");
            modelBuilder.Entity<Doctor>().ToTable("Doctors");
            modelBuilder.Entity<Patient>().ToTable("Patients");
            modelBuilder.Entity<Specialization>().ToTable("Specializations");

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Cabinet)
                .WithMany()
                .HasForeignKey(d => d.CabinetId);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.Specialization)
                .WithMany()
                .HasForeignKey(d => d.SpecializationId);

            modelBuilder.Entity<Doctor>()
                .HasOne(d => d.District)
                .WithMany()
                .HasForeignKey(d => d.DistrictId);

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.District)
                .WithMany()
                .HasForeignKey(p => p.DistrictId);
        }
    }
}
