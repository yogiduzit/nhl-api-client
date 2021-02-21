using System.ComponentModel.DataAnnotations;

namespace comp4870_assignment_1.Models
{
    public class Team
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Location Name")]
        public string locationName { get; set; }

        [Display(Name = "Abbreviation")]
        public string abbreviation { get; set; }
    }
}