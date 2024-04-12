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


		[BindProperty]
		public int ScreeningId { get; set; }


		public Screening Screening { get; set; }

		public Booking Booking { get; set; }

		public Type Type { get; set; }

		public IEnumerable<SelectListItem> listOfTypesItems { get; set; }
		public IEnumerable<Type> listOfTypes { get; set; }

		public Ticket Ticket { get; set; }

		[BindProperty]
		public int ticketCount { get; set; }
		[BindProperty]
		public int adultTicCount { get; set; }
		[BindProperty]
		public int childTicCount { get; set; }
		public IEnumerable<Type> listOfTIckets { get; set; }

		public BookModel(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			listOfTypes = _unitOfWork.TypeRepo.GetAll();
		}
		public void OnGet(int screeningId)
        {
			ScreeningId = screeningId;
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
                for (int i = 0; i < adultTicCount; i++)
				{
					Ticket ticket = new Ticket();
					ticket.bookingId = booking.Id;
					//Type = _unitOfWork.TypeRepo.Get(1); //Type.Id       use getall, put into ienumerable, get page to count adult and child tics, for loop for each of these 
					ticket.typeId = GetAdultTicketTypeId();
					ticket.screeningId = ScreeningId;               //maybe get the screening using the screening id from the page
					_unitOfWork.TicketRepo.Add(ticket);
                    _unitOfWork.ScreeningRepo.Get(ScreeningId).seatsRemaining -= 1;
                }

				for (int i = 0; i < childTicCount; i++)
				{
					Ticket ticket = new Ticket();
					ticket.bookingId = booking.Id;
					//Type = _unitOfWork.TypeRepo.Get(1); //Type.Id       use getall, put into ienumerable, get page to count adult and child tics, for loop for each of these 
					ticket.typeId = GetChildTicketTypeId();
					ticket.screeningId = ScreeningId;				//maybe get the screening using the screening id from the page
					_unitOfWork.TicketRepo.Add(ticket);
                    _unitOfWork.ScreeningRepo.Get(ScreeningId).seatsRemaining -= 1;
                }

				_unitOfWork.Save();
			}
			return RedirectToPage("BookingMade");
		}

		private int GetAdultTicketTypeId()
		{
			// Retrieve the adult ticket type ID based on its name
			var adultType = listOfTypes.FirstOrDefault(t => t.TypeName == "Adult");
			return adultType?.Id ?? 0; // Return 0 if adult ticket type is not found
		}

		// Placeholder method to retrieve the child ticket type ID
		private int GetChildTicketTypeId()
		{
			// Retrieve the child ticket type ID based on its name
			var childType = listOfTypes.FirstOrDefault(t => t.TypeName == "Child");
			return childType?.Id ?? 0; // Return 0 if child ticket type is not found
		}

	}
}
