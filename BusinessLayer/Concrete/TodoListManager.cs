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
    public class TodoListManager : IGenericService<TodoList>
    {
        private readonly ITodoListDal _todoListDal;

        public TodoListManager(ITodoListDal todoListDal)
        {
            _todoListDal = todoListDal;
        }

        public void TAdd(TodoList t)
        {
            _todoListDal.Insert(t);
        }

        public void TDelete(TodoList t)
        {
            _todoListDal.Delete(t);
        }

        public TodoList TGetById(int id)
        {
            return _todoListDal.GetById(id);
        }

        public List<TodoList> TGetList()
        {
            return _todoListDal.GetList();
        }

        public List<TodoList> TGetListByFilter(string p)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(TodoList t)
        {
             _todoListDal.Update(t);
        }
    }
}
