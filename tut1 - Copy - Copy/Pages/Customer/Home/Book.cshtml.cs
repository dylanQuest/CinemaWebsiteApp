using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.Models.Models;
using RP1.Services;
using Type = RP1.Models.Models.Type;

namespace tut1.Pages.Customer.Home
{
    public class BookModel : PageModel
    {
		private readonly IUnitOfWork _unitOfWork;


		public Screening Screening { get; set; }

		public Booking Booking { get; set; }

		public Type Type { get; set; }

		public IEnumerable<Type> listOfTypes { get; set; }

		public Ticket Ticket { get; set; }

		public BookModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void OnGet()
        {
			listOfTypes = _unitOfWork.TypeRepo.GetAll();
        }

	}
}
