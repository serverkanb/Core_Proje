using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterUserManager : IWriterUserService
    {
        IWriterUserDal _writerUserDal;

        public WriterUserManager(IWriterUserDal writerUserDal)
        {
            _writerUserDal = writerUserDal;
        }

        public void TAdd(WriterUser t)
        {
           _writerUserDal.Insert(t);
        }

        public void TDelete(WriterUser t)
        {
            _writerUserDal.Delete(t);
        }

        public WriterUser TGetById(int id)
        {
          return _writerUserDal.GetById(id);
        }

        public List<WriterUser> TGetList()
        {
            return _writerUserDal.GetList();
        }

        public List<WriterUser> TGetListByFilter(string p)
        {
            return _writerUserDal.GetbyFilter(x => x.Name.Contains(p));
        }

        public void TUpdate(WriterUser t)
        {
            _writerUserDal.Update(t);
        }
    }
}
