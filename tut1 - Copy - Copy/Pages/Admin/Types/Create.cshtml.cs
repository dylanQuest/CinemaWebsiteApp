using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Admin.Types
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public RP1.Models.Models.Type Type { get; set; }
        public void OnGet()
        {
        }
        public IActionResult OnPost(RP1.Models.Models.Type type)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.TypeRepo.Add(type);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
