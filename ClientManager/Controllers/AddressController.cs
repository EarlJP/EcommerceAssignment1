﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientManager.Controllers
{
    public class AddressController : Controller
    {
        Models.ClientsEntities db = new Models.ClientsEntities();

        // GET: Address
        public ActionResult Index(int id)
        {
            var result = db.persons.SingleOrDefault(p => p.person_id == id);

            return View(result);
        }

        // GET: Address/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Address/Create
        public ActionResult Create(int id)
        {

            //something like ViewBag.Add("key", value); is happening in the line below
            ViewBag.countries
                = db.countries.Select(c => new SelectListItem() { Value = c.country_code, Text = c.country_name });

            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public ActionResult Create(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                Models.address newAddress = new Models.address()
                {
                    city = collection["city"],
                    country_code = collection["country_code"],
                    description = collection["description"],
                    person_id = id,
                    province = collection["province"],
                    street_address = collection["street_address"],
                    zipcode = collection["zip_postal"],
                };
                db.addresses.Add(newAddress);
                db.SaveChanges();

                return RedirectToAction("Index", new { id = id });
            }
            catch
            {
                return View();
            }
        }

        // GET: Address/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Address/Edit/5
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

        // GET: Address/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Address/Delete/5
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
