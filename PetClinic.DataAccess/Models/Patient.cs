using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.DataAccess.Models
{
    public class Patient
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Name { get; set; }
        
        public string Species { get; set; }
        
        public string Race { get; set; }

        public double Weight { get; set; }

        public DateTime DateOfBirth { get; set; }

        public byte[] Photo { get; set; }

        [Required]
        public int ClientId { get; set; }


        public virtual Client Client { get; set; }
    }
}
