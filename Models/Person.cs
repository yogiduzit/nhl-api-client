using System.ComponentModel.DataAnnotations;

namespace comp4870_assignment_1.Models
{
    public class Person
    {
        public int id { get; set; }
        [Display(Name = "Full Name")]
        public string fullName { get; set; }

    }
}