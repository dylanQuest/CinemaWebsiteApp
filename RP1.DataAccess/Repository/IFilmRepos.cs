using RP1.Models.Models;
namespace RP1.DataAccess.Repo
{
    public interface IFilmRepo: IRepo<Film>
    {
        void SaveAll();
    }
}
