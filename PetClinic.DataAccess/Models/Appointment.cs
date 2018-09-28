using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.DataAccess.Models
{
    public class Appointment
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public DateTime TimeStart { get; set; }

        [Required]
        public DateTime TimeEnd { get; set; }

        [Required]
        public int MedicId { get; set; }

        [Required]
        public int PatientId { get; set; }

        [Required]
        public int AppointmentTypeId { get; set; }
        
        public double? Cost { get; set; }

        public string MedicNotes { get; set; }

        public string ClientNotes { get; set; }

        public string Review { get; set; }


        public virtual AppointmentType AppointmentType { get; set; }
    }
}
