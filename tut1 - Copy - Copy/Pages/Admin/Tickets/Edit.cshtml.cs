using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RP1.DataAccess.DataAccess;
using RP1.DataAccess;
using RP1.Models.Models;
using RP1.Services;
using Type = RP1.Models.Models.Type;

namespace TeamProject.Pages.Admin.Tickets
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public RP1.Models.Models.Ticket Ticket { get; set; }

        public Type Type { get; set; }
        public IEnumerable<SelectListItem> TypeList { get; set; }

        public Booking Booking { get; set; }
        public IEnumerable<SelectListItem> BookingList { get; set; }

        public Screening Screening { get; set; }
        public IEnumerable<SelectListItem> ScreeningList { get; set; }
        public void OnGet(int id)
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

        public IActionResult OnPost(Screening screening)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.ScreeningRepo.Update(screening);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
