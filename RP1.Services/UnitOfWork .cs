using RP1.DataAccess.DataAccess;
using RP1.DataAccess.Repo;
using TP.DataAccess.Repo;

namespace RP1.Services
{
    //unitofwork class which acts as interface to repo class in page models
    public class UnitOfWork : IUnitOfWork
    {
        public readonly AppDBContext _dbcontext;
        public IFilmRepo FilmRepo { get; private set; }

        public IScreeningRepo ScreeningRepo { get; private set; }

        public ITheatreRepo TheatreRepo { get; private set; }

        public ITypeRepo TypeRepo { get; private set; }

        public IBookingRepo BookingRepo { get; private set; }
        public ITicketRepo TicketRepo { get; private set; }
        public UnitOfWork(AppDBContext dbcontext)
        {
            _dbcontext = dbcontext;
            FilmRepo = new FilmRepo(_dbcontext);
            ScreeningRepo = new ScreeningRepo(_dbcontext);
            TheatreRepo = new TheatreRepo(_dbcontext);
            TypeRepo = new TypeRepo(_dbcontext);
            BookingRepo = new BookingRepo(_dbcontext);
            TicketRepo = new TicketRepo(_dbcontext);
        }

        public void Dispose()
        {
            _dbcontext.Dispose();
        }

        public void Save()
        {
            _dbcontext.SaveChanges();
        }

     
    }
}
