﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
//因為model來自DAL
using MODULE04_09.DAL;

namespace MODULE04_09.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        //Get: Home/ProductByID/1
        //Get: Home/ProductByID?ID=1
        public ActionResult ProductByID(int id)
        {
            //NorthwindEntities定義在DAL中
            NorthwindEntities db = new NorthwindEntities();
            var query = from p in db.Products
                        where p.ProductID == id
                        select p;

            //只列第一筆(事實上上面的語法也只會有一筆)
            var result = query.First();

            return View(result);
        }

        public ActionResult ProductsByCategory(int id)
        {
            NorthwindEntities db = new NorthwindEntities();
            var query = from p in db.Products
                        where p.CategoryID == id
                        select p;

            
            var result = query.ToList();

            return View(result);
        }
    }
}