using EfWebTutorial.Models;
using EfWebTutorial.Repositories;
using EfWebTutorial.Services.Interfaces;

namespace EfWebTutorial.Services
{
    public class FacultyService : IFacultyService
    {
        FacultyRepository _facultyRepository;
        GroupRepository _groupRepository;

        public FacultyService(FacultyRepository facultyRepository, GroupRepository groupRepository)
        {
            _facultyRepository = facultyRepository;
            _groupRepository = groupRepository; 
        }

        public async void CreateNewFaculty(Faculty faculty)
        {
            await _facultyRepository.CreateAsync(faculty);

        }

        public async Task<List<Faculty>> GetAllFaculties()
        {
            var res = await _facultyRepository.GetAllItemsAsync();
            return res;
        }

        public async Task<bool> DeleteAsync(int? id)
        {
            await _groupRepository.DeleteByFacultyIdAsync(id);
            await _facultyRepository.DeleteAsync(id);

            return true;
        }

    }
}
