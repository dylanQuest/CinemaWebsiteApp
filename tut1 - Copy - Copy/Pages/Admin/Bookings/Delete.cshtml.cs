using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.Models.Models;
using RP1.DataAccess.DataAccess;
using RP1.Services;

namespace TeamProject.Pages.Admin.Bookings
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
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
            if (ModelState.IsValid)
            {
                _unitOfWork.BookingRepo.Delete(booking);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }

}
