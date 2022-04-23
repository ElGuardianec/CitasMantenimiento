using CitasMantenimiento.Data.Entities;
using System;

namespace CitasMantenimiento.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();
            await CheckAppointmentTimeTypeAsync();
            await CheckAppointmentStatusVehicleTypeAsync();

        }

        private async Task CheckAppointmentTimeTypeAsync()
        {
            if (!_context.AppointmentTimes.Any())
            {
                _context.AppointmentTimes.Add(new AppointmentTime { Time = DateTime.Parse("08:30") });
                _context.AppointmentTimes.Add(new AppointmentTime { Time = DateTime.Parse("09:00") });
                _context.AppointmentTimes.Add(new AppointmentTime { Time = DateTime.Parse("09:30") });
                _context.AppointmentTimes.Add(new AppointmentTime { Time = DateTime.Parse("10:00") });
                await _context.SaveChangesAsync();
            }
        }

        private async Task CheckAppointmentStatusVehicleTypeAsync()
        {
            if (!_context.StatusVehicles.Any())
            {
                _context.StatusVehicles.Add(new StatusVehicle { Status = "ATENDIDA" });
                _context.StatusVehicles.Add(new StatusVehicle { Status = "PROGRAMADA" });
                await _context.SaveChangesAsync();
            }
        }
    }
}
