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
    public class TestimOnialManager : IGenericService<TestimOnial>
    {
        private readonly ITestimOnialDal _testimonialDal;

        public TestimOnialManager(ITestimOnialDal testimonialDal)
        {
            _testimonialDal = testimonialDal;
        }

        public void TAdd(TestimOnial t)
        {
            _testimonialDal.Insert(t);
        }

        public void TDelete(TestimOnial t)
        {
            _testimonialDal.Delete(t);
        }

        public TestimOnial TGetById(int id)
        {
            return _testimonialDal.GetById(id);
        }

        public List<TestimOnial> TGetList()
        {
           return _testimonialDal.GetList();
        }

        public void TUpdate(TestimOnial t)
        {
           _testimonialDal.Update(t);
        }
    }
}
