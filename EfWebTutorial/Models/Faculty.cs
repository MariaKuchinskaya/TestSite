namespace EfWebTutorial.Models
{
    public class Faculty
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        virtual public List<Group> Groups { get; set; }
    }
}
