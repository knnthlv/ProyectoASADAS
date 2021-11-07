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
    public class Marca : ICRUD<data.Marca>
    {
        private readonly ADbContext db;

        public Marca(ADbContext _db)
        {
            db = _db;
        }

        public void Delete(data.Marca t)
        {
            new DAL.Marca(db).Delete(t);
        }

        public IEnumerable<data.Marca> GetAll()
        {
            return new DAL.Marca(db).GetAll();
        }

        public Task<IEnumerable<data.Marca>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public data.Marca GetOneById(int id)
        {
            return new DAL.Marca(db).GetOneById(id);
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
            new DAL.Marca(db).Insert(t);
        }

        public void Update(data.Marca t)
        {
            new DAL.Marca(db).Update(t);
        }
    }
}
