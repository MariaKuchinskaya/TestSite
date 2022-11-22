using EfWebTutorial.Models;

namespace EfWebTutorial.Services.Interfaces
{
    public interface IFacultyService
    {
        
            public void CreateNewFaculty(Faculty group);

            public Task<List<Faculty>> GetAllFaculties();

            public Task<bool> DeleteAsync(int? id);

        
    }
}
