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
    public class Averia : ICRUD<data.Averia>
    {
        private RepositoryAveria repo;

        public Averia(ADbContext _db)
        {
            repo = new RepositoryAveria(_db);
        }

        public void Delete(data.Averia t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Averia> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Averia>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Averia GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Averia> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public Task<data.Averia> GetOneByIdAsyncString(string id)
        {
            throw new NotImplementedException();
        }

        public data.Averia GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Averia t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Averia t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
