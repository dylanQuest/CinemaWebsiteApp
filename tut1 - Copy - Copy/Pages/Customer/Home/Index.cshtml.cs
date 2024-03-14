using System.Drawing.Drawing2D;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Customer.Home
{
	public class IndexModel : PageModel
	{
		private readonly IUnitOfWork _unitOfWork;

		public IndexModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public IEnumerable<Film> listOfFilms { get; set; }

		[BindProperty(SupportsGet = true)]

		public string? SearchString { get; set; }

		public void OnGet()
		{
			listOfFilms = _unitOfWork.FilmRepo.GetAll();
			if (!string.IsNullOrEmpty(SearchString))
			{
				listOfFilms = listOfFilms.Where(p => p.FilmName.Contains(SearchString, StringComparison.OrdinalIgnoreCase));
			}
		}
	}
}
