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
    public class Recibo : ICRUD<data.Recibo>
    {
        private RepositoryRecibo repo;

        public Recibo(ADbContext _db)
        {
            repo = new RepositoryRecibo(_db);
        }

        public void Delete(data.Recibo t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Recibo> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Recibo>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Recibo GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Recibo> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public Task<data.Recibo> GetOneByIdAsyncString(string id)
        {
            throw new NotImplementedException();
        }

        public data.Recibo GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Recibo t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Recibo t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
