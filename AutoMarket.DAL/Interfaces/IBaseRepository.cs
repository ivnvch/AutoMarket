namespace AutoMarket.DAL.Interfaces
{
    public interface IBaseRepository<T>
    {
        bool Create(T entity);
        T Get(int id);
        public Task<List<T>> Select();
        bool Delete(T entity);
    }
}
