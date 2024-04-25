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
			Screening = _unitOfWork.ScreeningRepo.Get(screeningId);
			listOfTypesItems = _unitOfWork.TypeRepo.GetAll().Select(i => new SelectListItem()
			{
				Text = i.TypeName,
				Value = i.Id.ToString(),
			});
			listOfTypes = _unitOfWork.TypeRepo.GetAll();
		}

		//when user submits booking the necessary tickets are created in the onpost and saved to DB along with booking
		public IActionResult OnPost(Booking booking)
		{
			if (ModelState.IsValid)
			{
				_unitOfWork.BookingRepo.Add(booking);
				_unitOfWork.Save();

                for (int i = 0; i < adultTicCount; i++)
				{
					Ticket ticket = new Ticket();
					ticket.bookingId = booking.Id;
					ticket.typeId = GetAdultTicketTypeId();
					ticket.screeningId = ScreeningId;        
					_unitOfWork.TicketRepo.Add(ticket);
                    _unitOfWork.ScreeningRepo.Get(ScreeningId).seatsRemaining -= 1; //take seats away from a screening per num of tickets
                }

				for (int i = 0; i < childTicCount; i++)
				{
					Ticket ticket = new Ticket();
					ticket.bookingId = booking.Id;
					ticket.typeId = GetChildTicketTypeId();
					ticket.screeningId = ScreeningId;	
					_unitOfWork.TicketRepo.Add(ticket);
                    _unitOfWork.ScreeningRepo.Get(ScreeningId).seatsRemaining -= 1; //take seats away from a screening per num of tickets
                }

				_unitOfWork.Save();
			}
            EmailSender emailSender = new EmailSender();
            //emailSender.SendEmail(booking.Email,booking.Id,booking.Cost).Wait();
            return RedirectToPage("BookingMade");
		}

		//current iteration if system requires their only be adult and cild tickets
		private int GetAdultTicketTypeId()
		{
			// Retrieve the ticket type ID based on its name
			var adultType = listOfTypes.FirstOrDefault(t => t.TypeName == "Adult" || t.TypeName == "adult");
			return adultType?.Id ?? 0; // Return 0 if  not found
		}

		private int GetChildTicketTypeId()
		{
			var childType = listOfTypes.FirstOrDefault(t => t.TypeName == "Child" || t.TypeName == "child");
			return childType?.Id ?? 0;
		}

	}
}
