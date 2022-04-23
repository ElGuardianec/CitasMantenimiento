using System.ComponentModel.DataAnnotations;

namespace CitasMantenimiento.Data.Entities
{
    public class StatusVehicle
    {
        public int Id { get; set; }

        [Display(Name = "Estado")]
        [MaxLength(15, ErrorMessage = "El campo {0} no puede tener más de {1} carácteres.")]
        [Required(ErrorMessage = "El campo {0} es obligatorio.")]
        public string Status { get; set; }
    }
}
