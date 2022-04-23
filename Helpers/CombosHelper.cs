using CitasMantenimiento.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CitasMantenimiento.Helpers
{
    public class CombosHelper : ICombosHelper
    {
        private readonly DataContext _context;

        public CombosHelper(DataContext context)
        {
            _context = context;
        }


        public IEnumerable<SelectListItem> GetComboAppointmentTimes()
        {
            List<SelectListItem> list = _context.AppointmentTimes.Select(t => new SelectListItem
            {
                Text = t.Time.TimeOfDay.ToString(),
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Horario...]",
                Value = "0"
            });

            return list;
        }

        public IEnumerable<SelectListItem> GetComboStatusVehicle()
        {
            List<SelectListItem> list = _context.StatusVehicles.Select(t => new SelectListItem
            {
                Text = t.Status,
                Value = $"{t.Id}"
            })
                .OrderBy(t => t.Text)
                .ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "[Seleccione un Estado...]",
                Value = "0"
            });

            return list;
        }
    }

}
