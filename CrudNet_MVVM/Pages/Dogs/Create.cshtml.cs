using CrudNet_MVVM.Data;
using CrudNet_MVVM.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudNet_MVVM.Pages.Dogs
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        public Dog Dog { get; set; }

        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if(!Dog.Sex.Equals('F') && !Dog.Sex.Equals('M'))
            {
                ModelState.AddModelError("Dog.Sex", "The sex of the dog must be Male of Female");
            }

            if(ModelState.IsValid)
            {
                await _db.Dog.AddAsync(Dog);
                await _db.SaveChangesAsync();
                TempData["success"] = "Dog created successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
