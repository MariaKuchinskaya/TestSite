using EfWebTutorial.Interfaces;
using EfWebTutorial.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace EfWebTutorial.Repositories
{
    public class GroupRepository : IBaseRepository<Group>
    {
        private readonly ApplicationContext _db;

        public GroupRepository(ApplicationContext db)
        {
            _db = db;
        }
        public async Task CreateAsync(Group item)
        {
            _db.Groups.Add(item);
            _db.SaveChanges();
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            if (id != null)
            {
                var group = await _db.Groups.FirstOrDefaultAsync(p => p.Id == id);
                if (group != null)
                {
                    _db.Groups.Remove(group);
                    await _db.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }

    

        public async Task<List<Group>> GetAllItemsAsync()
        {
            var res = await _db.Groups
                .Include(x => x.Faculty)
                .ToListAsync();

            return res;
        }

    
        public async Task<Group> GetOneItemAsync(int id)
        {
            var res = await _db.Groups.FirstOrDefaultAsync(x => x.Id == id);
            return res;
        }

        [HttpPost]
        public async Task EditAsync(Group group)
        {
            var dbGroup = await _db.Groups.FirstOrDefaultAsync(x => x.Id == group.Id);
            if (dbGroup != null)
            {
                dbGroup.Name = group.Name;
                dbGroup.FacultyId = group.FacultyId;
            }

            _db.SaveChanges();
        }



        public async Task DeleteByFacultyIdAsync(int? facultyId)
        {
            if (facultyId != null)
            {
                var groups =  _db.Groups.Where(p => p.FacultyId == facultyId);
               
                    _db.Groups.RemoveRange(groups);
                    await _db.SaveChangesAsync();
                    
                
            }

           
        }

        public Task<List<Group>> GetAllItemsSortedAsync()
        {
            throw new NotImplementedException();
        }
    }
}
