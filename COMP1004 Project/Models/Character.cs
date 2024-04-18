namespace COMP1004_Project.Models
{


    // This model represents a character in the dnd game
    // As such it contains the properties it requires to function as a character as per the games rules
    // it also uses the race and classes properties to refer to other models

    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Classes { get; set; }
        public int Level { get; set; }
        public string? Image { get; set; }
        public Character()
        {
            Level = 0;
        }
    }
}
