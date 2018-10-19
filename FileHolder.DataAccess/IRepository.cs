using System.Collections.Generic;

namespace FileHolder.DataAccess
{
    public interface IRepository
    {
        int Add<T>(T item);
        int Update<T>(T item);
        void Delete<T>(T item);
        IEnumerable<T> GetAll<T>();
    }
}
