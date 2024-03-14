using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Admin.Bookings
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Booking Booking { get; set; }
        public void OnGet(int id)
        {
            Booking = _unitOfWork.BookingRepo.Get(id);
        }

        public IActionResult OnPost(Booking booking)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.BookingRepo.Update(booking);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
