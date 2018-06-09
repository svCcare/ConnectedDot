using System.ComponentModel.DataAnnotations;

namespace ConnectedDot.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Skill name")]
        public string Name { get; set; }

        [Required]
        public bool isKnown { get; set; }

        //[Required]
        //[RegularExpression(@"\d[1-5]{1}", ErrorMessage = "Single digit rating, from 1 to 5.")]
        public int Level { get; set; }

        public Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public ApplicationUser User { get; set; }

        [Required]
        public string UserId { get; set; }

        public string UserName { get; set; }

        public string Notes { get; set; }
    }
}