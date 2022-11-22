using EfWebTutorial.Exceptions;
using EfWebTutorial.Interfaces;
using EfWebTutorial.Models;
using EfWebTutorial.Services;
using EfWebTutorial.Services.Interfaces;
using EfWebTutorial.Viewmodels.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EfWebTutorial.Controlles
{
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly IGroupService _groupService;
        private readonly IFacultyService _facultyService;
        public StudentController(IStudentService studentService, IGroupService groupService, IFacultyService facultyService)
        {
            _groupService = groupService;
            _studentService = studentService;
            _facultyService = facultyService;
        }



        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var students = await _studentService.GetAllStudents();
                return View(students);
            }
            catch (Exception ex) {
                ViewBag.Message = ex.Message;
                return View();
            }
            //var students = await _studentService.GetAllStudents();
            //return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> GetSortedStudentsByName()
        {
            var viewModel = new StudentViewModel();
            var students = await _studentService.GetAllStudentsSorted();
            viewModel.Students = students;
              


            return View(viewModel);

        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new StudentViewModel();
            var groups = await _groupService.GetAllGroups();
            viewModel.Groups = groups;
            //var faculties = await _facultyService.GetAllFaculties();
            //viewModel.Faculties = faculties;    


            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(StudentViewModel studentViewModel)
        {
            _studentService.CreateNewStudent(studentViewModel.Student);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
               await _studentService.DeleteAsync(id);
               return RedirectToAction("Index");
            }
            return NotFound();
        }


        public async Task <IActionResult> Edit(int Id)
        {
            var viewModel = new StudentViewModel();
            var student = await _studentService.GetStudentByIdAsync(Id);
            var groups = await _groupService.GetAllGroups();
            viewModel.Student = student;
            viewModel.Groups = groups;

            return View(viewModel);
        }

        [HttpPost]
        public async Task <IActionResult> Edit (Student student)
        {
            try
            {
                await _studentService.EditAsync(student);

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
        }


    }
}
