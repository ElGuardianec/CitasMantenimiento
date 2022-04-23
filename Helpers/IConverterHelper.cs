using CitasMantenimiento.Data.Entities;
using CitasMantenimiento.Models;

namespace CitasMantenimiento.Helpers
{
    public interface IConverterHelper
    {
        Task<Appointment> AddAppointmentAsync(AppointmentViewModel model, bool isNew);
    }
}
