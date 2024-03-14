using RP1.Models.Models;
using RP1.DataAccess.Repo;
using RP1.DataAccess.DataAccess;

namespace TP.DataAccess.Repo
{
    public class FilmRepo : Repo<Film>, IFilmRepo
    {
        private readonly AppDBContext _dbContext;
        public FilmRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }
    }
}
