using Microsoft.AspNetCore.Mvc.Rendering;

namespace CitasMantenimiento.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboAppointmentTimes();

        IEnumerable<SelectListItem> GetComboStatusVehicle();
    }
}
