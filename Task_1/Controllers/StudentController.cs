using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class StudentController : Controller
    {
        Context db = new Context();

        // GET: Student
        public ActionResult Index()
        {

            IEnumerable<Student> students = db.Students;

            ViewBag.Students = students;

            return View();
        }

        



        
    }
}