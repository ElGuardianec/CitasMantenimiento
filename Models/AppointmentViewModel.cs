using CitasMantenimiento.Data.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CitasMantenimiento.Models
{
    public class AppointmentViewModel: Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Vehiculo")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione Vehiculo.")]
        [Required]
        public int VehicleId { get; set; }

        [Display(Name = "Hora")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione uno de nuestros horarios validos.")]
        public int AppointmentTimeId { get; set; }

        public IEnumerable<SelectListItem>? AppointmentTimes { get; set; }

        [Display(Name = "Estado")]
        [Range(1, int.MaxValue, ErrorMessage = "Seleccione uno de nuestros estados.")]
        public int StatusVehicleId { get; set; }

        public IEnumerable<SelectListItem>? StatusVehicles { get; set; }
    }
}
