using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.Models.Models;
using RP1.DataAccess.DataAccess;
using RP1.Services;

namespace TeamProject.Pages.Admin.Screenings
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Screening Screening { get; set; }
        public void OnGet(int id)
        {
            Screening = _unitOfWork.ScreeningRepo.Get(id);
        }

        public IActionResult OnPost(Screening screening)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.ScreeningRepo.Delete(screening);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }

}
