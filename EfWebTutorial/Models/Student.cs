namespace EfWebTutorial.Models
{
    public class Student
    {
        public Student()
        {
            this.Subjects = new HashSet<Subject>();
        }

        public int Id { get; set; }    
        public string Name { get; set; }

        public string Surname { get; set; }

        public int Age { get; set; }    

        public int? GroupId { get; set; }    

        virtual public Group Group { get; set; }

        public int? FacultyId { get; set; }  

        virtual public Faculty Faculty { get; set; }

        /// <summary>
        /// ICollection вызыывает фуункцию Add
        /// </summary>
        public ICollection<Subject> Subjects { get; } 
    }
}
