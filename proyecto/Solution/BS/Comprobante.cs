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
    public class Comprobante : ICRUD<data.Comprobante>
    {
        private readonly ADbContext db;

        public Comprobante(ADbContext _db)
        {
            db = _db;
        }

        public void Delete(data.Comprobante t)
        {
            new DAL.Comprobante(db).Delete(t);
        }

        public IEnumerable<data.Comprobante> GetAll()
        {
            return new DAL.Comprobante(db).GetAll();
        }

        public Task<IEnumerable<data.Comprobante>> GetAllAsync()
        {
            return new DAL.Comprobante(db).GetAllAsync();
        }

        public data.Comprobante GetOneById(int id)
        {
            return new DAL.Comprobante(db).GetOneById(id);
        }

        public Task<data.Comprobante> GetOneByIdAsync(int id)
        {
            return new DAL.Comprobante(db).GetOneByIdAsync(id);
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
            new DAL.Comprobante(db).Insert(t);
        }

        public void Update(data.Comprobante t)
        {
            new DAL.Comprobante(db).Update(t);
        }
    }
}
