using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Admin.Films
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EditModel(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }
        public Film Film { get; set; }
        public void OnGet(int id)
        {
            Film = _unitOfWork.FilmRepo.Get(id);
        }

        public IActionResult OnPost()
        {
            string wwwRootFolder = _webHostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            var filmFromDB = _unitOfWork.FilmRepo.Get(Film.Id);

            if (files.Count > 0)
            {
                string new_filename = Guid.NewGuid().ToString();

                var upload = Path.Combine(wwwRootFolder, @"Images\Films");

                var extension = Path.GetExtension(files[0].FileName);
                if (filmFromDB != null)
                {
                    var oldFile = Path.Combine(wwwRootFolder,filmFromDB.ImageName.TrimStart('\\'));
                    if (System.IO.File.Exists(oldFile))
                    {
                        System.IO.File.Delete(oldFile);
                    }
                }
                using (var fileStream = new FileStream(Path.Combine(upload, new_filename + extension), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }

                filmFromDB.ImageName = @"\Images\Films\" + new_filename + extension;
            }

            if (ModelState.IsValid)
            {
                Film = filmFromDB;
                _unitOfWork.FilmRepo.Update(filmFromDB);
                _unitOfWork.Save();
            }
            return RedirectToPage("Index");
        }
    }
}
