using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.Models;
using System.IO;
using System.Web.UI.WebControls;

namespace Task_1.Controllers
{
    public class UserController : Controller
    {
        Context db = new Context();

        
        public ActionResult Index()
        {

            IEnumerable<User> user = db.Users;

            ViewBag.Users = user;

            return View();
        }

        public ActionResult Delete(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }



            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(User user, HttpPostedFileBase uploadImage)
        {
            try
            {
                if (uploadImage != null)
                {
                    user.ImageType = uploadImage.ContentType;
                    user.Image = new byte[uploadImage.ContentLength];
                    uploadImage.InputStream.Read(user.Image, 0, uploadImage.ContentLength);
                }
                else
                {

                    DefultImage.GetDefultImage(user);


                }

                db.Users.Add(user);
                db.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {

                return View();
            }

        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            User user = db.Users.Find(id);

            if (user != null)
            {
                return View(user);
            }

            return HttpNotFound();
        }


        [HttpPost]
        public ActionResult Edit(User user, HttpPostedFileBase uploadImage)
        {
            try
            {

                if (uploadImage != null)
                {
                    user.ImageType = uploadImage.ContentType;
                    user.Image = new byte[uploadImage.ContentLength];
                    uploadImage.InputStream.Read(user.Image, 0, uploadImage.ContentLength);

                    db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                }







                return RedirectToAction("Index");

            }
            catch
            {

                return View();
            }

        }


      

        public FileContentResult GetImage(int id)
        {
            User user = db.Users.Find(id);

            if (user.Image == null)
            {
                DefultImage.GetDefultImage(user);
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }


            return File(user.Image, user.ImageType);
        }


    }
}