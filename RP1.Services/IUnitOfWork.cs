using RP1.DataAccess.Repo;
namespace RP1.Services
{
    public interface IUnitOfWork :IDisposable
    {
        IFilmRepo FilmRepo { get; }
        void Save();
        IScreeningRepo ScreeningRepo { get; }
        ITheatreRepo TheatreRepo { get; }
        ITypeRepo TypeRepo { get; }

        IBookingRepo BookingRepo { get; }
        ITicketRepo TicketRepo { get; }
    }
}