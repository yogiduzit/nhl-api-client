using System.Collections.Generic;
using comp4870_assignment_1.Models;
using System.Text.Json;


namespace comp4870_assignment_1.DS
{
    public class PlayerResponseDS
    {
        public string copyright { get; set; }
        public List<RosterItem> roster { get; set; }
    }
}