using System.ComponentModel.DataAnnotations;

namespace comp4870_assignment_1.Models
{
    public class Team
    {
        [Display(Name = "ID")]
        public int id { get; set; }
        public string name { get; set; }
        public string locationName { get; set; }
        public string abbreviation { get; set; }
    }
}