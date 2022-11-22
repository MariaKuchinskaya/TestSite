using EfWebTutorial.Models;

namespace EfWebTutorial.Viewmodels.Students
{
    public class StudentViewModel
    {
        public Student Student { get; set; }
        public List<Group> Groups { get; set; }

        public List<Student> Students { get; set; }

        //public List<Faculty> Faculties { get; set; }
    }
}
