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
    public class Medidor : ICRUD<data.Medidor>
    {
        private RepositoryMedidor repo;

        public Medidor(ADbContext _db)
        {
            repo = new RepositoryMedidor(_db);
        }

        public void Delete(data.Medidor t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Medidor> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Medidor>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Medidor GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Medidor> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public Task<data.Medidor> GetOneByIdAsyncString(string id)
        {
            throw new NotImplementedException();
        }

        public data.Medidor GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Medidor t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Medidor t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
