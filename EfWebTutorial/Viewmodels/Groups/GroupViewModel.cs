using EfWebTutorial.Models;

namespace EfWebTutorial.Viewmodels.Groups
{
    public class GroupViewModel
    {
        public Group Group { get; set; }
       

        public List<Faculty> Faculties { get; set; }
    }
}
