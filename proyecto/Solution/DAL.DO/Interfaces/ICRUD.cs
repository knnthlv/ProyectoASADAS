using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DO.Interfaces
{
    public interface ICRUD<T>
    {
        void Insert(T t);
        void Update(T t);
        void Delete(T t);

        T GetOneByIdString(string id);
        T GetOneById(int id);

        IEnumerable<T> GetAll();
        Task<T> GetOneByIdAsyncString(string id);
        Task<T> GetOneByIdAsync(int id);

        Task<IEnumerable<T>> GetAllAsync();
    }

}
