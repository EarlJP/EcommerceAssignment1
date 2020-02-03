using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientManager.Controllers
{
    public class PictureController : Controller
    {
        Models.ClientsEntities db = new Models.ClientsEntities();

        // GET: Picture
        public ActionResult Index(int id)
        {
            Models.person thePerson = db.persons.SingleOrDefault(p => p.person_id == id);

            return View(thePerson.pictures);
        }

        // GET: Picture/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Picture/Create
        public ActionResult Create(int id)
        {

            return View();
        }

        // POST: Picture/Create
        [HttpPost]
        public ActionResult Create(int id,FormCollection collection, HttpPostedFile newPicture)
        {
            try
            {
                // TODO: Add insert logic here
                if(newPicture != null && newPicture.ContentLength > 0)
                {
                    Guid g = Guid.NewGuid();
                    string filename = g + "." + Path.GetExtension(newPicture.FileName);
                    string path = Server.MapPath("~/Images/");
                    path = Path.Combine(path, filename);
                    newPicture.SaveAs(path);

                    Models.picture newPic = new Models.picture()
                    {
                        caption = collection["caption"],
                        time_info = collection["time_info"],
                        location = collection["location"],
                        relative_path = filename,
                        person_id = id,
                    };

                    db.pictures.Add(newPic);
                    db.SaveChanges();
                }

                return RedirectToAction("Index", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Picture/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Picture/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Picture/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Picture/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
