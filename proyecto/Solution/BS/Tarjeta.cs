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
    public class Tarjeta : ICRUD<data.Tarjeta>
    {
        private readonly ADbContext db;

        public Tarjeta(ADbContext _db)
        {
            db = _db;
        }

        public void Delete(data.Tarjeta t)
        {
            new DAL.Tarjeta(db).Delete(t);
        }

        public IEnumerable<data.Tarjeta> GetAll()
        {
            return new DAL.Tarjeta(db).GetAll();
        }

        public Task<IEnumerable<data.Tarjeta>> GetAllAsync()
        {
            return new DAL.Tarjeta(db).GetAllAsync();
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
            return new DAL.Tarjeta(db).GetOneByIdAsyncString(id);
        }

        public data.Tarjeta GetOneByIdString(string id)
        {
            return new DAL.Tarjeta(db).GetOneByIdString(id);
        }

        public void Insert(data.Tarjeta t)
        {
            new DAL.Tarjeta(db).Insert(t);
        }

        public void Update(data.Tarjeta t)
        {
            new DAL.Tarjeta(db).Update(t);
        }
    }
}
