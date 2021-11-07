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
    public class Estado : ICRUD<data.Estado>
    {
        private Repository<data.Estado> repo;

        public Estado(ADbContext _db)
        {
            repo = new Repository<data.Estado>(_db);
        }

        public void Delete(data.Estado t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Estado> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Estado>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Estado GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Estado> GetOneByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<data.Estado> GetOneByIdAsyncString(string id)
        {
            throw new NotImplementedException();
        }

        public data.Estado GetOneByIdString(string id)
        {
            throw new NotImplementedException();
        }

        public void Insert(data.Estado t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Estado t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
