using EfWebTutorial.Interfaces;
using EfWebTutorial.Models;
using EfWebTutorial.Repositories;

namespace EfWebTutorial.Services
{
    public class StudentService : IStudentService
    {
        StudentRepository _studentRepository;


        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async void CreateNewStudent(Student student)
        {
            await _studentRepository.CreateAsync(student);
        }

        public async Task<List<Student>> GetAllStudents()
        {
            var res = await _studentRepository.GetAllItemsAsync();
            return res;
        }

        public async Task<List<Student>> GetAllStudentsSorted()
        {
            var res = await _studentRepository.GetAllItemsSortedAsync();
            return res;
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            var res = await _studentRepository.DeleteAsync(id);
            return res;
        }


        public async Task EditAsync(Student student)
        {
            await _studentRepository.EditAsync(student);
        }

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _studentRepository.GetOneItemAsync(id);
            return student;
        }
    }
}
