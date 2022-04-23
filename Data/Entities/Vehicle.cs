using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CitasMantenimiento.Data.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }

        [Display(Name = "Placa")]
        [RegularExpression(@"[a-zA-Z]{3}[0-9]{2}[a-zA-Z0-9]", ErrorMessage = "Formato de placa incorrecto.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "El campo {0} debe tener {1} carácteres.")]
        public string Plaque { get; set; }

        //Relacion 1 a varios
        [Display(Name = "Citas")]
        public ICollection<Appointment> Appointments { get; set; }

        [Display(Name = "# Citas")]
        public int AppointmentsNumber => Appointments == null ? 0 : Appointments.Count;
    }
}
