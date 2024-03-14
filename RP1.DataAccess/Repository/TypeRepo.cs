using RP1.DataAccess.DataAccess;
using RP1.Models.Models;
using Type = RP1.Models.Models.Type;

namespace RP1.DataAccess.Repo
{
    public class TypeRepo : Repo<Type>, ITypeRepo
    {
        private readonly AppDBContext _dbContext;
        public TypeRepo(AppDBContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveAll()
        {
            _dbContext.SaveChanges();
        }
    }
}
