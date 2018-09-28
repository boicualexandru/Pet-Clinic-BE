using System.ComponentModel.DataAnnotations;

namespace PetClinic.Models
{
    public class MedicDto
    {
        [Required]
        [RegularExpression(@"^[\s]*[a-zA-Z]+[a-zA-Z|\s]*$", ErrorMessage = "Use only letters and spaces please")]
        public string Name { get; set; }
        public string Contact { get; set; }
    }
    // abc
}
