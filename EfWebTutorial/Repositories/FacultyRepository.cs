using EfWebTutorial.Interfaces;
using EfWebTutorial.Models;
using Microsoft.EntityFrameworkCore;

namespace EfWebTutorial.Repositories
{
    public class FacultyRepository : IBaseRepository<Faculty>
    {
        private readonly ApplicationContext _db;

        public FacultyRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Faculty item)
        {
            _db.Faculties.Add(item);
            _db.SaveChanges();
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id != null)
            {
                var faculty = await _db.Faculties.FirstOrDefaultAsync(p => p.Id == id);
                if (faculty != null)
                {
                    _db.Faculties.Remove(faculty); ;
                    await _db.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

        public async Task EditAsync(Faculty item)
        {

            _db.Faculties.Update(item);
            await _db.SaveChangesAsync();
        }

        public async Task<List<Faculty>> GetAllItemsAsync()
        {
            var res = await _db.Faculties.ToListAsync();
            return res;
        }

        public Task<List<Faculty>> GetAllItemsSortedAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Faculty> GetOneItemAsync(int id)
        {
            var res = await _db.Faculties.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }
    }
}

