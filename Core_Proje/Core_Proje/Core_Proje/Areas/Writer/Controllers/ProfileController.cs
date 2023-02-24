using Core_Proje.Areas.Writer.Models;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Core_Proje.Areas.Writer.Controllers
{
    [Area("Writer")]
    [Route("Writer/[controller]/[action]")]
    public class ProfileController : Controller
    {
       
        private readonly UserManager<WriterUser> _usermanager;

        public ProfileController(UserManager<WriterUser> usermanager)
        {
            _usermanager = usermanager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _usermanager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel model = new UserEditViewModel();
            model.Name = values.Name;
            model.SurName = values.SurName;
            model.PictureUrl = values.ImageUrl;

            return View(model);
        }
        // profil güncelleme
        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel p)
        {
            var user = await _usermanager.FindByNameAsync(User.Identity.Name);
         
            if(p.Picture != null) 
            {
                var resource=Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.Picture.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimage/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.Picture.CopyToAsync(stream);
                user.ImageUrl = imagename;
            }
            user.Name= p.Name;
            user.SurName = p.SurName;
            user.PasswordHash = _usermanager.PasswordHasher.HashPassword(user, p.Password);
            var result=await _usermanager.UpdateAsync(user);
            if(result.Succeeded) 
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
    }
}
