using System.ComponentModel.DataAnnotations;
namespace comp4870_assignment_1.Models
{
    public class Position
    {
        public string code { get; set; }
        [Display(Name = "Position Name")]
        public string name { get; set; }
        public string type { get; set; }
        public string abbreviation { get; set; }

    }
}