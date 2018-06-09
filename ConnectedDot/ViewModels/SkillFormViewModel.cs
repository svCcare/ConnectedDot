using ConnectedDot.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ConnectedDot.ViewModels
{
    public class SkillFormViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Category { get; set; }

        [Required]
        public IEnumerable<Category> Categories { get; set; }

        public bool isKnown { get; set; }

        //[Required]
        //[RegularExpression(@"\d[1-5]{1}", ErrorMessage = "Single digit rating, from 1 to 5.")]
        public int Level { get; set; }

        public string Notes { get; set; }
    }
}