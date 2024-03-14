using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Admin.Bookings
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Booking Booking { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(Booking booking)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.BookingRepo.Add(booking);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
