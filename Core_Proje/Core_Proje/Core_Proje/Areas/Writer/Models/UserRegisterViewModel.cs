using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;


namespace Core_Proje.Areas.Writer.Models
{
    public class UserRegisterViewModel
    {
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Adınızı Girin.")]
        public string Name { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Soy Adınızı Girin.")]
        public string SurName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Resim Yolu Girin.")]
        public string ImageUrl { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Kullanıcı Adını Girin.")]
        public string UserName { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifreyi Girin.")]
        public string Password { get; set; }

        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Şifreyi Tekrar Girin.")]
        [Compare("Password",ErrorMessage = "Şifreler Uyumlu Değil.")]
        public string ConfirmPassword { get; set; }
        [System.ComponentModel.DataAnnotations.Required(ErrorMessage = "Lütfen Mail Girin.")]
        public string Mail { get; set; }
    }
}
