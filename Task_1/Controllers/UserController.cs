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
    /// <summary>
    /// User Controller
    /// </summary>
    public class UserController : Controller
    {
        Context db = new Context();

        /// <summary>
        /// Shows the list of user
        /// </summary>   
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
        /// <summary>
        /// GET: Create a user
        /// </summary>       
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Create a user
        /// </summary>
        /// <param name="user">New user</param>
        /// <param name="uploadImage">Image</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(User user, HttpPostedFileBase uploadImage)
        {
            try
            {
                //if the user selected an image
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

        /// <summary>
        /// GET: Edits the user
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
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

        /// <summary>
        /// POST: Edit the user
        /// </summary>
        /// <param name="user">User for edit</param>
        /// <param name="uploadImage">Image for the user</param>
        /// <returns></returns>
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


                }




                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();







                return RedirectToAction("Index");

            }
            catch
            {

                return View();
            }

        }



        /// <summary>
        /// Downloads userlist from server
        /// </summary>
        /// <returns></returns>
        public ActionResult Download()
        {
            string fileName;
            return File(UserList.DownloadUserList(out fileName), "text/txt", fileName);
        }

        /// <summary>
        /// Gets the image    
        /// </summary>
        /// <param name="id">User id</param>
        /// <returns></returns>
        public FileContentResult GetImage(int id)
        {
            User user = db.Users.Find(id);

            //if no image sets default image
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