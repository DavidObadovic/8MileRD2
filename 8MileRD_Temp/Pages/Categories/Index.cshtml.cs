using _8MileRD_Temp.Data;
using _8MileRD_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace _8MileRD_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public List<Category> CategoriesList { get; set; }
        public IndexModel(ApplicationDbContext db)
        {
            _context = db;
        }
        public void OnGet()
        {
            CategoriesList=_context.Categories.ToList();
        }
    }
}
