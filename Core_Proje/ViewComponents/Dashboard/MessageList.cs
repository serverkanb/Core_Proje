using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.ViewComponents.Dashboard
{
    public class MessageList : ViewComponent
    {
        //UserMessageManager _userMessageManager = new UserMessageManager(new EfUserMessageDal(new DataAccessLayer.Concrete.Context()));
        public IViewComponentResult Invoke()
        {
            //var values = _userMessageManager.TGetUserMessagesWithUser();
            return View();
        }
    }
}
