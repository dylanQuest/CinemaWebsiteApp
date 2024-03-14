using RP1.DataAccess.DataAccess;
using RP1.Models.Models;

namespace RP1.DataAccess.Repo
{
    public class ScreeningRepo : Repo<Screening>, IScreeningRepo
    {
        private readonly AppDBContext _dbContext;
        public ScreeningRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }
    }
}
