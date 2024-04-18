namespace COMP1004_Project.Models
{

    //Similarly to the character model, it contains properties as per the rules of dnd
    // in the future the features property will be an array

    public class Class
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Hitdie { get; set; }
        public int Level { get; set; }
        public string Features { get; set; }

        public Class()
        {

        }
    }
}
