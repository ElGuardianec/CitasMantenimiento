using CitasMantenimiento.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CitasMantenimiento.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<AppointmentTime> AppointmentTimes { get; set; }

        public DbSet<StatusVehicle> StatusVehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vehicle>().HasIndex(x => x.Plaque).IsUnique();
            modelBuilder.Entity<AppointmentTime>().HasIndex(x => x.Time).IsUnique();
            modelBuilder.Entity<StatusVehicle>().HasIndex(x => x.Status).IsUnique();

        }
    }
}
