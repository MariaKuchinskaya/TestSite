using EfWebTutorial.Exceptions;
using EfWebTutorial.Interfaces;
using EfWebTutorial.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfWebTutorial.Repositories
{
    public class StudentRepository : IBaseRepository<Student>
    {
        private readonly ApplicationContext _db;

        public StudentRepository(ApplicationContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Student item)
        {
            _db.Students.AddAsync(item);
            _db.SaveChangesAsync();
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id != null)
            {
                var student = await _db.Students.FirstOrDefaultAsync(p => p.Id == id);
                if (student != null)
                {
                    _db.Students.Remove(student);
                    await _db.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public async Task<List<Student>> GetAllItemsAsync()
        {
            var res1 = await _db.Students.ToListAsync();
            if (res1.Count == 0)
            {
                throw new NotFoundException ("Add students to database");
            }
            else {

                var res = await _db.Students
                .Include(x => x.Group)
                .Include(x => x.Group.Faculty)

                .ToListAsync();

                return res;

            }
            
                    
            //return res;
        }

        public async Task<List<Student>> GetAllItemsSortedAsync()
        {
            var res1 = await _db.Students.ToListAsync();
            if (res1.Count == 0)
            {
                throw new NotFoundException("Add students to database");
            }
            else
            {

                var res = await _db.Students
                .OrderBy(x => x.Name)
                .ToListAsync();

                return res;

            }


            //return res;
        }



        public async Task<Student> GetOneItemAsync(int id)
        {
            var res = await _db.Students.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }

        [HttpPost]
        public async Task EditAsync(Student student)
        {
            var dbStudent = await _db.Students.FirstOrDefaultAsync(x => x.Id == student.Id);  
            if (dbStudent != null)
            {
                dbStudent.Name = student.Name;  
                dbStudent.Surname = student.Surname;
                dbStudent.GroupId = student.GroupId;
            }
           
            _db.SaveChanges();
        }



        public async Task UnassignStudentsFromGroup (int? groupId)
        {
            var students = await GetAllItemsAsync();

            var studdentsInGroup = students.Where(student => student.GroupId == groupId);

            foreach (var student in studdentsInGroup)
            {
                student.GroupId = null;
            }

            _db.SaveChanges();
        }
    }
}
