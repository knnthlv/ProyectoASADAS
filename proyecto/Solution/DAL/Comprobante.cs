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
    public class Comprobante : ICRUD<data.Comprobante>
    {
        private RepositoryComprobante repo;

        public Comprobante(ADbContext _db)
        {
            repo = new RepositoryComprobante(_db);
        }

        public void Delete(data.Comprobante t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Comprobante> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Comprobante>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Comprobante GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Comprobante> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public Task<data.Comprobante> GetOneByIdAsyncString(string id)
        {
            throw new NotImplementedException();
        }

        public data.Comprobante GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Comprobante t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Comprobante t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
