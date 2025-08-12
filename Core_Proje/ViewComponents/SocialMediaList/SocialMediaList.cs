using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace My_Core_Proje_.ViewComponents.SocialMediaList
{
    public class SocialMediaList : ViewComponent
    {
        SocialMediaManager socialMedia = new SocialMediaManager(new EfSocialMediaDal());
        public IViewComponentResult Invoke()
        {
            var values = socialMedia.TGetList();
            return View(values);
        }
    }
}
