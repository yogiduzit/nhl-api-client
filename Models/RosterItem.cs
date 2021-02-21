using System.ComponentModel.DataAnnotations;

namespace comp4870_assignment_1.Models
{
    public class RosterItem
    {
        public Person person { get; set; }

        [Display(Name="Jersey Number")]
        public string jerseyNumber { get; set; }
        public Position position { get; set; }
    }
}