using RP1.Models.Models;
using RP1.DataAccess.Repo;
using RP1.DataAccess.DataAccess;

namespace TP.DataAccess.Repo
{
    public class TheatreRepo : Repo<Theatre>, ITheatreRepo
    {
        private readonly AppDBContext _dbContext;
        public TheatreRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }
    }
}
