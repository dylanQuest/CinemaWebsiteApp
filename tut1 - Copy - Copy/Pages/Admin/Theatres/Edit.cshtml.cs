using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Admin.Theatres
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Theatre Theatre { get; set; }
        public void OnGet(int id)
        {
            Theatre = _unitOfWork.TheatreRepo.Get(id);
        }

        public IActionResult OnPost(Theatre theatre)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.TheatreRepo.Update(theatre);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
