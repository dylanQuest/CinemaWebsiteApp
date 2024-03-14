using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Customer.Home
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Film Film { get; set; }
        public void OnGet(int id)
        {
            Film = _unitOfWork.FilmRepo.Get(id);
        }

        public IActionResult OnPost(Film film)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.FilmRepo.Update(film);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
