using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.Models.Models;
using RP1.Services;
using System.Drawing.Drawing2D;

namespace tut1.Pages.Customer.Home
{
    public class OrderModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;
		public OrderModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public IEnumerable<Screening> listOfScreenings { get; set; }
		public Film Film { get; set; }
		public Screening Screening { get; set; }
		public IEnumerable<Film> listOfFilms { get; set; }
		public void OnGet(int Id)
        {
			Film = _unitOfWork.FilmRepo.Get(Id);
			listOfFilms = _unitOfWork.FilmRepo.GetAll();
			listOfScreenings = _unitOfWork.ScreeningRepo.GetAll();

			listOfScreenings = listOfScreenings.Where(p => p.filmId == Film.Id);
		}
    }
}
