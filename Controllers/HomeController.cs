using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DemoCrud.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Create()
        {
            WebAppDbContext db = new WebAppDbContext();
            var cityList = db.tbl_Cities.ToList();
            ViewBag.CityList = new SelectList(cityList, "CityId", "CityName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Catagory catagory)
        {
            if (ModelState.IsValid)
            {
                WebAppDbContext db = new WebAppDbContext();
                catagory.CreatedOn = DateTime.Now;
                db.tbl_Catagory.Add(catagory);
                db.SaveChanges();

                return RedirectToAction("List");
            }
            else
            {
                return RedirectToAction("Create");
            }
           
        }
        [HttpGet]
        public ActionResult List()
        {

            WebAppDbContext db = new WebAppDbContext();
            var list = db.tbl_Catagory.ToList();
            return View(list);
        }

        public ActionResult CreateCotagory()
        {

           return View();
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            WebAppDbContext db = new WebAppDbContext();
            var cotagory = db.tbl_Catagory.Find(id);

            var cityList = db.tbl_Cities.ToList();
            ViewBag.CityList = new SelectList(cityList, "CityId", "CityName");

            return View(cotagory);
        }
        [HttpPost]
        public ActionResult Edit(tbl_Catagory catagory)
        {
            WebAppDbContext db = new WebAppDbContext();
            catagory.CreatedOn = DateTime.Now;
            db.Entry(catagory).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("List");

        }

        public ActionResult Delete(int categoryId)
        {
            WebAppDbContext db = new WebAppDbContext();

            var category = db.tbl_Catagory.Find(categoryId);
            db.tbl_Catagory.Remove(category);
            db.SaveChanges();

            return RedirectToAction("List");
        }


    }
}