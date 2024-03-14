using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.Models.Models;
using RP1.DataAccess.DataAccess;
using RP1.Services;

namespace TeamProject.Pages.Admin.Tickets
{
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public RP1.Models.Models.Ticket Ticket { get; set; }
        public void OnGet(int id)
        {
            Ticket = _unitOfWork.TicketRepo.Get(id);
        }

        public IActionResult OnPost(RP1.Models.Models.Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TicketRepo.Delete(ticket);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }

}
