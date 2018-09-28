using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.DataAccess.Models
{
    public class Tariff
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Species { get; set; }

        [Required]
        public int AppointmentTypeId { get; set; }

        [Required]
        public double Value { get; set; }


        public virtual AppointmentType AppointmentType { get; set; }
    }
}
