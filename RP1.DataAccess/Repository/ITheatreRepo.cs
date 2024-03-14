using RP1.Models.Models;
namespace RP1.DataAccess.Repo
{
    public interface ITheatreRepo: IRepo<Theatre>
    {
        void SaveAll();
    }
}
