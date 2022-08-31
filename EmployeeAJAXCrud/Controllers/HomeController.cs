using EmployeeAJAXCrud.Models;
using EmployeeAJAXCrud.Functions;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using EmployeeAJAXCrud.Data;

namespace EmployeeAJAXCrud.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public HomeController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           
            return View();
        }

        public JsonResult GetAll()
        {
            List<Basic> _list = new PersonDA(_db).GetAll();
            return Json(_list);
        }
        public JsonResult GetOne(int id)
        {
            Basic _list = new PersonDA(_db).GetOne(id);
            return Json(_list);
        }
        public JsonResult Save(Basic obj)
        {
            string _list = new PersonDA(_db).Save(obj);
            return Json(_list);
        }        
       
        public JsonResult Remove(int id)
        {
            string _list = new PersonDA(_db).Remove(id);
            return Json(_list);
        }        

    }
}