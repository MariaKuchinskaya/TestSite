using EfWebTutorial.Interfaces;
using EfWebTutorial.Models;
using EfWebTutorial.Services;
using EfWebTutorial.Services.Interfaces;
using EfWebTutorial.Viewmodels.Groups;
using EfWebTutorial.Viewmodels.Students;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfWebTutorial.Controlles
{
    public class GroupController : Controller
    {
        private readonly IGroupService _groupService;
        private readonly IFacultyService _facultyService;
        public GroupController(IGroupService groupService, IFacultyService facultyService)
        {

            _groupService = groupService;
            _facultyService = facultyService;   
        }

        public async Task<IActionResult> Index()
        {
            var group = await _groupService.GetAllGroups();

            return View(group);
        }
        public async Task<IActionResult> Create()
        {
            var viewModel = new GroupViewModel();
            var faculties = await _facultyService.GetAllFaculties();
            viewModel.Faculties = faculties;


            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Create(GroupViewModel groupViewModel)
        {
            _groupService.CreateNewGroup(groupViewModel.Group);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                await _groupService.DeleteAsync(id);
                    return RedirectToAction("Index");
                
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int Id)
        {
            var viewModel = new GroupViewModel();
            var groups = await _groupService.GetGroupByIdAsync(Id); 
            var faculties = await _facultyService.GetAllFaculties();

            viewModel.Group = groups;
            viewModel.Faculties = faculties;


            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Group group)
        {
            try
            {
                await _groupService.EditAsync(group);

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

