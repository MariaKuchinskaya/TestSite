using EfWebTutorial.Models;

namespace EfWebTutorial.Interfaces
{
    public interface IStudentService
    {
        public void CreateNewStudent(Student student);

        public Task<List<Student>> GetAllStudents();
        public Task<List<Student>> GetAllStudentsSorted();



        public Task<bool> DeleteAsync(int? id);

        public Task EditAsync(Student student);

        public Task<Student> GetStudentByIdAsync(int id);


    }
}