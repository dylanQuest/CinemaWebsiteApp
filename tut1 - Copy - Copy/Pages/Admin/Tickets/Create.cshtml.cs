using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;
using Type = RP1.Models.Models.Type;

namespace TeamProject.Pages.Admin.Tickets
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _unitOfWork = unitOfWork;
        }
        public RP1.Models.Models.Ticket Ticket { get; set; }

        public Type Type { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }

        public Booking Booking { get; set; }
        public IEnumerable<SelectListItem> BookingList { get; set; }

        public Screening Screening { get; set; }
        public IEnumerable<SelectListItem> ScreeningList { get; set; }

        public void OnGet()
        {
            TypeList = _unitOfWork.TypeRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.TypeName,
                Value = i.Id.ToString(),
            });

            BookingList = _unitOfWork.BookingRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Id.ToString(),
                Value = i.Id.ToString(),
            });

            ScreeningList = _unitOfWork.ScreeningRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.Id.ToString(),
                Value = i.Id.ToString(),
            });
        }
        public IActionResult OnPost(RP1.Models.Models.Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TicketRepo.Add(ticket);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
