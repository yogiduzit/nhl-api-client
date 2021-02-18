namespace comp4870_assignment_1.Models
{
    public class Player
    {
        public string fullName { get; set; }
        public CurrentTeam currentTeam{ get; set; }
        public int currentAge { get; set; }
        public string nationality { get; set; }
        public PrimaryPosition primaryPosition { get; set; }
    }
}