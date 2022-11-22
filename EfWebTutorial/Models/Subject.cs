namespace EfWebTutorial.Models
{
    public class Subject
    {
        public Subject()
        {
            this.Students = new HashSet<Student>();
        }
        public int Id { get; set; } 
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
