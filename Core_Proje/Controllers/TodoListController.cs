using Microsoft.AspNetCore.Authorization;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TodoListController : Controller
    {
        TodoListManager _todoListManager = new TodoListManager(new EfTodoListDal());

        [HttpPost]
        public IActionResult AddTodo(TodoList todoList)
        {
            if (!string.IsNullOrWhiteSpace(todoList.Content))
            {
                todoList.Status = false;
                _todoListManager.TAdd(todoList);
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult ChangeStatus(int id)
        {
            var value = _todoListManager.TGetById(id);
            if (value != null)
            {
                value.Status = !value.Status;
                _todoListManager.TUpdate(value);
            }
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult DeleteTodo(int id)
        {
            var value = _todoListManager.TGetById(id);
            if (value != null)
            {
                _todoListManager.TDelete(value);
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
