using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class AwardController : Controller
    {

        Context db = new Context();

        // GET: Award
        public ActionResult Index()
        {
            var awards = db.Awards;
            return View(awards);
        }


        // GET: Award/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Award/Create
        [HttpPost]
        public ActionResult Create(Award award, HttpPostedFileBase uploadImage)
        {
            try
            {

                if (uploadImage != null)
                {

                    award.ImageType = uploadImage.ContentType;
                    award.Image = new byte[uploadImage.ContentLength];
                    uploadImage.InputStream.Read(award.Image, 0, uploadImage.ContentLength);

                }
                else
                {
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


        public FileContentResult GetImage(int id)
        {
            Award award  = db.Awards.Find(id);
            if (award.Image ==null)
            {
                DefultImage.GetDefultImage(award);
                db.Entry(award).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return File(award.Image, award.ImageType);
        }

        // GET: Award/Edit/5
        public ActionResult Edit(int id)
        {
            Award award = db.Awards.Find(id);

            if (award != null)
            {
                return View(award);
            }

            return HttpNotFound();

        }

        // POST: Award/Edit/5
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
                    db.Entry(award).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
              

                return RedirectToAction("Index", "Award");
            }
            catch
            {
                return View();
            }
        }

        // GET: Award/Delete/5
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
