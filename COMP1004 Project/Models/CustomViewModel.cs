namespace COMP1004_Project.Models
{
    // this model merges multiple models into one for the purpose of designing a character,
    // as well as outputing properties of multiple models in a single view
    public class CustomViewModel
    {
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Class>? Classes { get; set; }
        public IEnumerable<Race>? Races { get; set; }
        public Character Character { get; set; }
        public Class Class { get; set; }
        public Race Race { get; set; }

        public string TotalHD => $"{Character.Level}D{Class.Hitdie}";
    }
}
