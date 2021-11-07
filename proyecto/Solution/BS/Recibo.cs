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
    public class Recibo : ICRUD<data.Recibo>
    {
        private readonly ADbContext db;

        public Recibo(ADbContext _db)
        {
            db = _db;
        }

        public void Delete(data.Recibo t)
        {
            new DAL.Recibo(db).Delete(t);
        }

        public IEnumerable<data.Recibo> GetAll()
        {
            return new DAL.Recibo(db).GetAll();
        }

        public Task<IEnumerable<data.Recibo>> GetAllAsync()
        {
            return new DAL.Recibo(db).GetAllAsync();
        }

        public data.Recibo GetOneById(int id)
        {
            return new DAL.Recibo(db).GetOneById(id);
        }

        public Task<data.Recibo> GetOneByIdAsync(int id)
        {
            return new DAL.Recibo(db).GetOneByIdAsync(id);
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
            new DAL.Recibo(db).Insert(t);
        }

        public void Update(data.Recibo t)
        {
            new DAL.Recibo(db).Update(t);
        }
    }
}
