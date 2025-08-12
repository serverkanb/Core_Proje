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
    public class AnnoucementManager : IAnnoucementService
    {
        private readonly IAnnouncementDal _announcementDal;

        public AnnoucementManager(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public void TAdd(Annoucement t)
        {
            _announcementDal.Insert(t);
        }

        public void TDelete(Annoucement t)
        {
            _announcementDal.Delete(t);
        }

        public Annoucement TGetById(int id)
        {
            return _announcementDal.GetById(id);
        }

        public List<Annoucement> TGetList()
        {
            return _announcementDal.GetList();
        }

        public List<Annoucement> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Annoucement t)
        {
            _announcementDal.Update(t);
        }
    }
}
