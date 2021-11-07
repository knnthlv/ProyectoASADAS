using System;
using System.Collections.Generic;
using System.Text;
using data = DAL.DO.Objects;
using DAL.DO.Interfaces;
using DAL.EF;
using DAL.Repository;
using System.Threading.Tasks;

namespace DAL
{
    public class Marca : ICRUD<data.Marca>
    {
        private Repository<data.Marca> repo;

        public Marca(ADbContext _db)
        {
            repo = new Repository<data.Marca>(_db);
        }

        public void Delete(data.Marca t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Marca> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Marca>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Marca GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Marca> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Marca> GetOneByIdAsyncString(string id)
        {
            throw new NotImplementedException();
        }

        public data.Marca GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Marca t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Marca t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
