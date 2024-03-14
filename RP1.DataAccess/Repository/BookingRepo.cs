using RP1.Models.Models;
using RP1.DataAccess.Repo;
using RP1.DataAccess.DataAccess;

namespace TP.DataAccess.Repo
{
    public class BookingRepo : Repo<Booking>, IBookingRepo
    {
        private readonly AppDBContext _dbContext;
        public BookingRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }
    }
}
