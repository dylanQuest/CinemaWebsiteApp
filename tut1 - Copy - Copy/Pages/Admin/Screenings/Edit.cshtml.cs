using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RP1.DataAccess.DataAccess;
using RP1.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Admin.Screenings
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Screening Screening { get; set; }
        public IEnumerable<SelectListItem> FilmList { get; set; }
        public IEnumerable<SelectListItem> TheatreList { get; set; }
        public void OnGet(int id)
        {
            Screening = _unitOfWork.ScreeningRepo.Get(id);

            FilmList = _unitOfWork.FilmRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.FilmName,
                Value = i.Id.ToString(),
            });

            TheatreList = _unitOfWork.TheatreRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.TheatreNum.ToString(),
                Value = i.Id.ToString(),
            });
        }

        public IActionResult OnPost(Screening screening)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.ScreeningRepo.Update(screening);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
