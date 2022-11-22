using EfWebTutorial.Models;
using EfWebTutorial.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfWebTutorial.Controlles
{
    public class FacultyController : Controller
    {
        private readonly IFacultyService _facultyService;    
        public FacultyController(IFacultyService facultyService)
        {
            _facultyService = facultyService;
        }

        public async Task<IActionResult> Index()
        {
            var faculty = await _facultyService.GetAllFaculties();
 
            return View(faculty);
        }
        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> Create(Faculty faculty)
        {
            _facultyService.CreateNewFaculty(faculty);
            return RedirectToAction("Index");


        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            
             await _facultyService.DeleteAsync(id);
            return RedirectToAction("Index");


        }
    }
}

