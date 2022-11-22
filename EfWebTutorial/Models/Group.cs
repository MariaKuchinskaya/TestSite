namespace EfWebTutorial.Models
{
    public class Group
    {
        public int Id { get; set; } 
        public string Name { get; set; }

        public int? FacultyId { get; set; }

        virtual public Faculty Faculty { get; set; }
    }
}
