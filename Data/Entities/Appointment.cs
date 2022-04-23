using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CitasMantenimiento.Data.Entities
{
    public class Appointment
    {
        public int Id { get; set; }

        [Display(Name = "Fecha")]
        //[DisplayFormat(DataFormatString = "{MMMM d, yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [JsonIgnore]
        public Vehicle Vehicle { get; set; }

        [Display(Name = "Hora")]
        //[DisplayFormat(DataFormatString = "{0:t}")]
        [DataType(DataType.Time)]
        public AppointmentTime AppointmentTime { get; set; }

        [Display(Name = "Estado")]
        public StatusVehicle statusVehicle { get; set; }
    }
}
