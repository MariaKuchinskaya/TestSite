using EfWebTutorial.Models;

namespace EfWebTutorial.Services.Interfaces
{
    public interface IGroupService
    {
        public void CreateNewGroup(Group group);

        public Task<List<Group>> GetAllGroups();

        public Task<bool> DeleteAsync(int? id);
        public Task EditAsync(Group group);

        public Task<Group> GetGroupByIdAsync(int id);



    }
}
