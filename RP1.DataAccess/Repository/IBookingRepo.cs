using RP1.Models.Models;
namespace RP1.DataAccess.Repo
{
    public interface IBookingRepo: IRepo<Booking>
    {
        void SaveAll();
    }
}
