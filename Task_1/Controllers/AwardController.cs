using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
   /// <summary>
   /// Award controller
   /// </summary>
    public class AwardController : Controller
    {

        Context db = new Context();

        /// <summary>
        /// Shows the list of award
        /// </summary>      
        public ActionResult Index()
        {
            var awards = db.Awards;
            return View(awards);
        }


        /// <summary>
        /// GET: Create an award
        /// </summary>       
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Create an award
        /// </summary>
        /// <param name="award">New award</param>
        /// <param name="uploadImage">Image</param>     
        [HttpPost]
        public ActionResult Create(Award award, HttpPostedFileBase uploadImage)
        {
            try
            {
                //if the user selected an image
                if (uploadImage != null)
                {

                    award.ImageType = uploadImage.ContentType;
                    award.Image = new byte[uploadImage.ContentLength];
                    uploadImage.InputStream.Read(award.Image, 0, uploadImage.ContentLength);

                }
                else
                {
                    //Sets the defult image
                    DefultImage.GetDefultImage(award);
                
                }

                db.Awards.Add(award);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Gets the image
        /// </summary>
        /// <param name="id">Award id</param>
        /// <returns></returns>
        public FileContentResult GetImage(int id)
        {
            Award award  = db.Awards.Find(id);
            //if no image sets default image
            if (award.Image ==null)
            {
                DefultImage.GetDefultImage(award);
                db.Entry(award).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return File(award.Image, award.ImageType);
        }
        
        /// <summary>
        /// GET: Edits the award
        /// </summary>
        /// <param name="id">Award id</param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            Award award = db.Awards.Find(id);

            if (award != null)
            {
                return View(award);
            }

            return HttpNotFound();

        }

     
        /// <summary>
        /// POST: Edits the award
        /// </summary>
        /// <param name="award">Award</param>
        /// <param name="uploadImage">Image</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Edit(Award award, HttpPostedFileBase uploadImage)
        {
            try
            {
                if (uploadImage != null)
                {

                    award.ImageType = uploadImage.ContentType;
                    award.Image = new byte[uploadImage.ContentLength];
                    uploadImage.InputStream.Read(award.Image, 0, uploadImage.ContentLength);
       
                }

                db.Entry(award).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();


                return RedirectToAction("Index", "Award");
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// Deletes the award
        /// </summary>
        /// <param name="id">Award id</param>    
        public ActionResult Delete(int id)
        {
            Award award = db.Awards.Find(id);
            
            if (award != null)
            {
                db.Awards.Remove(award);
                db.SaveChanges();
            }


            return RedirectToAction("Index", "Award");
        }


    }
}
