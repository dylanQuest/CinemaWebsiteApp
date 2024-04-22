namespace RP1.DataAccess.Repo
{
    public interface IRepo<T> where T : class
    {
        //interface to define methods to be implemented in repo
        void Add(T obj);
        void Update(T obj);
        void Delete(T obj);
        IEnumerable<T> GetAll();
        T? Get(int id);
    }
}
