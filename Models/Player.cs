using System.ComponentModel.DataAnnotations;

namespace comp4870_assignment_1.Models
{
    public class Player
    {
        public string fullName {get; set;}
        public Team currentTeam{ get; set; }
        public int currentAge { get; set; }
        public string nationality { get; set; }
        public Position primaryPosition { get; set; }
    }
}