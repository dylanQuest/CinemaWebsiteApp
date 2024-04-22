using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using RP1.Services;

namespace TeamProject.Pages.Admin.Screenings
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
        public Screening Screening { get; set; }
        public IEnumerable<SelectListItem> FilmList { get; set; }

        public Theatre Theatre { get; set; }
        public IEnumerable<SelectListItem> TheatreList { get; set; }

        public void OnGet()
        {
            FilmList = _unitOfWork.FilmRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.FilmName,
                Value = i.Id.ToString(),
            });

            TheatreList = _unitOfWork.TheatreRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.TheatreNum.ToString(),
                Value = i.Id.ToString(),
            });
        }
        public IActionResult OnPost(Screening screening)
        {
            if (ModelState.IsValid)
            {
                var film = _unitOfWork.FilmRepo.Get(screening.filmId);
                var filmLength = film.Duration;

                bool check = false; //check refers to whether or nott a screening overlaps with new screening time

                var screenings = _unitOfWork.ScreeningRepo.GetAll();

                foreach (var item in screenings) //checks the new screening against old ones
                {
                    if (item.theatreId == screening.theatreId)
                    {
						var itemFilm = _unitOfWork.FilmRepo.Get(item.filmId);
						var itemfFilmLength = itemFilm.Duration;
						if (item.Date < screening.Date.AddMinutes(filmLength) && item.Date.AddMinutes(itemfFilmLength) > screening.Date) //if their times overlap the new screening is rejected
                        {
                            ModelState.AddModelError("", "The selected theatre is already booked at the selected time.");
                            FilmList = _unitOfWork.FilmRepo.GetAll().Select(i => new SelectListItem()
                            {
                                Text = i.FilmName,
                                Value = i.Id.ToString(),
                            });

                            TheatreList = _unitOfWork.TheatreRepo.GetAll().Select(i => new SelectListItem()
                            {
                                Text = i.TheatreNum.ToString(),
                                Value = i.Id.ToString(),
                            });
                            return Page();
                        }
                    }
                }
                screening.seatsRemaining = _unitOfWork.TheatreRepo.Get(screening.theatreId).Capacity;

                _unitOfWork.ScreeningRepo.Add(screening);
                _unitOfWork.Save();
                return RedirectToPage("Index");

            }
            // repopulate the dropdown lists in case of screening time validation errors
            FilmList = _unitOfWork.FilmRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.FilmName,
                Value = i.Id.ToString(),
            });

            TheatreList = _unitOfWork.TheatreRepo.GetAll().Select(i => new SelectListItem()
            {
                Text = i.TheatreNum.ToString(),
                Value = i.Id.ToString(),
            });

            // return the current page to display screening validation errors
            return Page();
        }
    }
}
