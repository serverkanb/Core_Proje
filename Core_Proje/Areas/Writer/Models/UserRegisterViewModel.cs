using System.ComponentModel.DataAnnotations;

namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [Required(ErrorMessage = "Lütfen Adınızı Giriniz")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Lütfen Soyadınızı Giriniz")]
        public string SurName { get; set; }
        [Required(ErrorMessage ="Lütfen Kullanıcı Adı Giriniz")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Lütfen Şifreyi  Giriniz")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Lütfen ResimUrl Giriniz")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Lütfen Şifreyi tekrar Giriniz")]
        public string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Lütfen Mailinizi Giriniz")]
        public string Mail { get; set; }
    }
}
