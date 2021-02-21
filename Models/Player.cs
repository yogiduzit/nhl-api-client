using System.ComponentModel.DataAnnotations;

namespace comp4870_assignment_1.Models
{
    public class Player
    {
        [Display(Name="Full name")]
        public string fullName {get; set;}

        [Display(Name="Current team")]
        public Team currentTeam{ get; set; }

        [Display(Name="Current age")]
        public int currentAge { get; set; }

        [Display(Name="Nationality")]
        public string nationality { get; set; }

        [Display(Name="Primary posiition")]
        public Position primaryPosition { get; set; }
    }
}