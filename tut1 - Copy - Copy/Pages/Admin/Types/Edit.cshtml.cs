using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;
using Type = RP1.Models.Models.Type;

namespace TeamProject.Pages.Admin.Types
{
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Type Type { get; set; }
        public void OnGet(int id)
        {
            Type = _unitOfWork.TypeRepo.Get(id);
        }


        public IActionResult OnPost(Type type)
        {
            if(ModelState.IsValid)
            {
                _unitOfWork.TypeRepo.Update(type);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
