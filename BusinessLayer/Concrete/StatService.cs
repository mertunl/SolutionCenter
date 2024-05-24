using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class StatService(IStatDAL statDAL) : IStatService
    {
        private readonly IStatDAL _statDAL= statDAL;
        public Stat TAdd(Stat entity)
        {
            throw new NotImplementedException();
        }

        public void TDelete(Stat entity)
        {
            throw new NotImplementedException();
        }

        public Stat TGetByID(Guid id)
        {
            return _statDAL.GetByID(id);

        }

        public List<Stat> TGetListAll()
        {
            return _statDAL.GetAll();
        }

        public void TUpdate(Stat entity)
        {
            _statDAL.Update(entity);
            
        }
    }
}
