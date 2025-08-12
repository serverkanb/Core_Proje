using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class TodoListPanel : ViewComponent
    {
        TodoListManager _todoListManager = new TodoListManager(new EfTodoListDal());
        public IViewComponentResult Invoke()
        {
            var values = _todoListManager.TGetList();
            return View(values);
        }
    }
}
