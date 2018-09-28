using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetClinic.DataAccess.Models
{
    public class MedicSkill
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int MedicId { get; set; }

        [Required]
        public int SkillId { get; set; }


        public virtual Medic Medic { get; set; }

        public virtual Skill Skill { get; set; }
    }
}
