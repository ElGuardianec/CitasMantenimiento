using System.ComponentModel.DataAnnotations;

namespace CitasMantenimiento.Data.Entities
{
    public class AppointmentTime
    {
        public int Id { get; set; }

        [Display(Name = "Hora")]
        //[DisplayFormat(DataFormatString = "{0:t}")]
        [DataType(DataType.Time)]
        public DateTime Time { get; set; }
    }
}
