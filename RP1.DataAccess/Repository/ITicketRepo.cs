using RP1.Models.Models;
using Type = RP1.Models.Models.Ticket;

namespace RP1.DataAccess.Repo
{
    public interface ITicketRepo : IRepo<Ticket>
    {
        void SaveAll();
    }
}
