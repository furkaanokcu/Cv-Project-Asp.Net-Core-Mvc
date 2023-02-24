using Core_Proje_Api.DAL.ApiContext;
using Core_Proje_Api.DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace Core_Proje_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult CategoryList()
        {
           using var c = new Context();
            return Ok(c.categories.ToList());
        }
        [HttpGet("ID")]
        public IActionResult GetAction(int id) 
        {
          using var c = new Context();
           var value= c.categories.Find(id);
            if (value==null)
            {
                return NotFound();
            }
            else
            {
                return Ok(value);
            }
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category p)
        {
            using var c = new Context();
            c.Add(p);
            c.SaveChanges();
            return Created("", p);
        }
        [HttpDelete]
        public IActionResult CategoryDelete(int id) 
        {
            using var c=new Context();
            var values=c.categories.Find(id);

            if(values==null)
            {
                return NotFound();
            }
            else
            {
                c.Remove(values);
                c.SaveChanges();
                return NoContent();
            }

        }
        [HttpPut]
        public IActionResult CategoryUpdate(Category p) 
        {
            using var c=new Context();
            var values = c.Find<Category>(p.CategoryID);
            if(values==null) 
            {
                return NotFound();

            }
            else
            {
                values.CategoryName=p.CategoryName;
                c.Update(values);
                c.SaveChanges();
                return NoContent();
            }
        }

    }
}
