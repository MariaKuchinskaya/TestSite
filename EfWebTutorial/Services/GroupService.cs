using EfWebTutorial.Models;
using EfWebTutorial.Repositories;
using EfWebTutorial.Services.Interfaces;

namespace EfWebTutorial.Services
{
    public class GroupService: IGroupService
    {
        GroupRepository _groupRepository;
        StudentRepository _studentRepository;  

        public GroupService(GroupRepository groupRepository, StudentRepository studentRepository)
        {
            _groupRepository = groupRepository;
            _studentRepository = studentRepository; 
        }

        public async void CreateNewGroup(Group group)
        {
            await _groupRepository.CreateAsync(group);
        }

        public async Task<List<Group>> GetAllGroups()
        {
            var res = await _groupRepository.GetAllItemsAsync();
            return res;
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            await _studentRepository.UnassignStudentsFromGroup(id);


            var res = await _groupRepository.DeleteAsync(id);
            return res;
        }

        public async Task EditAsync(Group group)
        {
            await _groupRepository.EditAsync(group);
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            var group = await _groupRepository.GetOneItemAsync(id);
            return group;
        }

    }
}
