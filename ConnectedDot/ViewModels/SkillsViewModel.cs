using ConnectedDot.Models;
using System.Collections.Generic;

namespace ConnectedDot.ViewModels
{
    public class SkillsViewModel
    {
        public IEnumerable<Skill> ListOfSkills { get; set; }
        public bool ShowActions { get; set; }

        public string Name { get; set; }
        public int Level { get; set; }
    }
}