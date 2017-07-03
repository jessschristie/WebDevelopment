using System.Collections.Generic;

namespace DaysProject5.Repository
{
    public interface IRepository<T>
    {
        List<T> CreateData(T obj);
        List<T> GetData();
        T FindData(int id);
        T EditData(T obj);
        T DeleteData(int id);
        void DestroyData(T obj);
    }
}
