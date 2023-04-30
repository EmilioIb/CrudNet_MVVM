using CrudNet_MVVM.Data;
using CrudNet_MVVM.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudNet_MVVM.Pages.Dogs
{
    [BindProperties]
    public class EditModel : PageModel
    {
        public Dog Dog { get; set; }

        private readonly ApplicationDbContext _db;
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int id)
        {
            if(id == 0 || id == null)
            {
                NotFound();
            }

            Dog = _db.Dog.Find(id);

            if(Dog == null)
            {
                NotFound();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if(Dog == null)
            {
                NotFound();
            }

            if (!Dog.Sex.Equals('F') && !Dog.Sex.Equals('M'))
            {
                ModelState.AddModelError("Dog.Sex", "The sex of the dog must be Male of Female");
            }

            if (ModelState.IsValid)
            {
                _db.Dog.Update(Dog);
                await _db.SaveChangesAsync();
                TempData["success"] = "Dog updated successfully";
                return RedirectToPage("Index");
            }

            return Page();
        }
    }
}
