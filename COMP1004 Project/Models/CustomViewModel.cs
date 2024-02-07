namespace COMP1004_Project.Models
{
    public class CustomViewModel
    {
        public IEnumerable<Character> Characters { get; set; }
        public IEnumerable<Class> Classes { get; set; }
        public Character Character { get; set; }
        public Class Class { get; set; }
    }
}
