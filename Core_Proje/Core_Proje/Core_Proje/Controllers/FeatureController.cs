using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace Core_Proje.Controllers
{
    public class FeatureController : Controller
    {
        FeatureManager featureManager = new FeatureManager(new EfFeatureDal());
        [HttpGet]
        public IActionResult Index()
        {      
            var values = featureManager.TGetByID(1);
            return View(values);
        }
       
        [HttpPost]
        public IActionResult Index(Feature p) 
        {
            featureManager.TUpdate(p);
            return RedirectToAction("Index","Default");
        }
    }
}
