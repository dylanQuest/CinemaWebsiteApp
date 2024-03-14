using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Admin.Theatres
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Theatre Theatre { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Theatre theatre)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TheatreRepo.Add(theatre);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
