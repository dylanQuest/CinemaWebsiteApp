using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Customer.Home
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Film Film { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Film film)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.FilmRepo.Add(film);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
