using DAL.DO.Interfaces;
using data = DAL.DO.Objects;
using System;
using System.Collections.Generic;
using System.Text;
using DAL.EF;
using DAL;
using System.Threading.Tasks;

namespace BS
{
    public class Estado : ICRUD<data.Estado>
    {
        private readonly ADbContext db;

        public Estado(ADbContext _db)
        {
            db = _db;
        }

        public void Delete(data.Estado t)
        {
            new DAL.Estado(db).Delete(t);
        }

        public IEnumerable<data.Estado> GetAll()
        {
            return new DAL.Estado(db).GetAll();
        }

        public Task<IEnumerable<data.Estado>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Estado GetOneById(int id)
        {
            return new DAL.Estado(db).GetOneById(id);
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
            new DAL.Estado(db).Insert(t);
        }

        public void Update(data.Estado t)
        {
            new DAL.Estado(db).Update(t);
        }
    }
}
