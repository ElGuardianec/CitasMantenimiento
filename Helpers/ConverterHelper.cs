using CitasMantenimiento.Data;
using CitasMantenimiento.Data.Entities;
using CitasMantenimiento.Models;

namespace CitasMantenimiento.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        private readonly DataContext _context;

        public ConverterHelper(DataContext context)
        {
            _context = context;
        }

        public async Task<Appointment> AddAppointmentAsync(AppointmentViewModel model, bool isNew)
        {
            return new Appointment
            {
                Vehicle = await _context.Vehicles.FindAsync(model.VehicleId),
                Id = isNew ? 0 : model.Id,
                Date = model.Date,
                AppointmentTime = await _context.AppointmentTimes.FindAsync(model.AppointmentTimeId),
                statusVehicle = await _context.StatusVehicles.FindAsync(model.StatusVehicleId)
            };
        }
    }
}
