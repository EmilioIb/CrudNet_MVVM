using CrudNet_MVVM.Data;
using CrudNet_MVVM.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CrudNet_MVVM.Pages.Dogs
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        public Dog Dog { get; set; }

        private readonly ApplicationDbContext _db;
        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet(int id)
        {
            if (id == 0 || id == null)
            {
                NotFound();
            }

            Dog = _db.Dog.Find(id);

            if (Dog == null)
            {
                NotFound();
            }
        }

        public async Task<IActionResult> OnPost()
        {
            if (Dog != null)
            {
                _db.Dog.Remove(Dog);
                await _db.SaveChangesAsync();
                TempData["success"] = "Dog deleted successfully";
                return RedirectToPage("Index");
            }

            return Page();

        }
    }
}
