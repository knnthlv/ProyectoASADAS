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
    public class Tarjeta : ICRUD<data.Tarjeta>
    {
        private RepositoryTarjeta repo;

        public Tarjeta(ADbContext _db)
        {
            repo = new RepositoryTarjeta(_db);
        }

        public void Delete(data.Tarjeta t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Tarjeta> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Tarjeta>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Tarjeta GetOneById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Tarjeta> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Tarjeta> GetOneByIdAsyncString(string id)
        {
            return repo.GetOneByIdAsyncString(id);
        }

        public data.Tarjeta GetOneByIdString(string id)
        {
            return repo.GetOnebyIDString(id);
        }

        public void Insert(data.Tarjeta t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Tarjeta t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
