namespace COMP1004_Project.Models
{
    //this model represents the basics of the game objects and will be used to display each game and its menus individually 

    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Image { get; set; }
        public string URL { get; set; }
        public Game()
        {
                
        }
    }
}
