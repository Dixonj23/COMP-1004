namespace COMP1004_Project.Models
{
    //once again like class and character, race has properties as per the rules of dnd
    //the properties abilities, proficiencies, languages, skills and traits will all become arrays at a later date

    public class Race
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public string Size  { get; set; }
        public string? Abilities  { get; set; }
        public string? Proficiencies { get; set; }
        public string? Languages { get; set; }
        public string? Skills { get; set; }
        public string Traits { get; set; }

        public Race()
        {
            
        }
    }
}
