using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.Models.Models;
using RP1.Services;

namespace tut1.Pages.Customer.Home
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Film Film { get; set; }
        public IEnumerable<Screening> listOfScreenings { get; set; }

        public void OnGet(int id)
        {
            Film = _unitOfWork.FilmRepo.Get(id);

            listOfScreenings = _unitOfWork.ScreeningRepo.GetAll();

            listOfScreenings = listOfScreenings.Where(p => p.filmId == Film.Id); //where screening(p)s film id matches the posted films id
        }
    }
}
