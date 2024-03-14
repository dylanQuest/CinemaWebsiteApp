using RP1.Models.Models;
using Type = RP1.Models.Models.Type;

namespace RP1.DataAccess.Repo
{
    public interface ITypeRepo : IRepo<Type>
    {
        void SaveAll();
    }
}
