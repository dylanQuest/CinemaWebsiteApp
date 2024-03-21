using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
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

		public IEnumerable<SelectListItem> listOfTypesItems { get; set; }
		public IEnumerable<Type> listOfTypes { get; set; }

		public Ticket Ticket { get; set; }

		[BindProperty]
		public int ticketCount { get; set; }
		public int adultTicCount { get; set; }
		public int childTicCount { get; set; }
		public IEnumerable<Type> listOfTIckets { get; set; }

		public BookModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}
		public void OnGet()
        {

			//listOfTypes = _unitOfWork.TypeRepo.GetAll();
			listOfTypesItems = _unitOfWork.TypeRepo.GetAll().Select(i => new SelectListItem()
			{
				Text = i.TypeName,
				Value = i.Id.ToString(),
			});

			listOfTypes = _unitOfWork.TypeRepo.GetAll();
		}

		public IActionResult OnPost(Booking booking)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.BookingRepo.Add(booking);
				_unitOfWork.Save();

				//Type = _unitOfWork.TypeRepo.Get(booking.TypeId);
				//Screening = _unitOfWork.ScreeningRepo.Get(booking.ScreeningId);

				for (int i = 0; i < ticketCount; i++)
				{
					Ticket ticket = new Ticket();
					ticket.bookingId = booking.Id;
					//Type = _unitOfWork.TypeRepo.Get(1); //Type.Id       use getall, put into ienumerable, get page to count adult and child tics, for loop for each of these 
					ticket.typeId = 1; //Type.Id
					ticket.screeningId = 1; //Screening.Id				get the screening using the screening id from the page
					_unitOfWork.TicketRepo.Add(ticket);
				}

				_unitOfWork.Save();
			}
			return RedirectToPage("BookingMade");
		}

	}
}
