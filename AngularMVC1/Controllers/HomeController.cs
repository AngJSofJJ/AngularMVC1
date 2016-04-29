using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularMVC1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetProducts()
        {
            try
            {
                var db = new ProductsDBEntities();
                var products = db.Products.ToList();
                return Json(products, JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException e)
            {
                //foreach (var eve in e.EntityValidationErrors)
                //{
                //    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //    foreach (var ve in eve.ValidationErrors)
                //    {
                //        Debug.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                //         ve.PropertyName,
                //             eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                //             ve.ErrorMessage);
                //    }
                //}
                throw e;
            }
        }

        [HttpPost]
        public JsonResult AddProduct(string newProduct, string newProductPrice, string newProductType)
        {
            try
            {
                var db = new ProductsDBEntities();
                db.Products.Add(new Product() { ProductName = newProduct, Price = float.Parse(newProductPrice), ProductType = newProductType });
                db.SaveChanges();
                var products = db.Products.ToList();
                return Json(products, JsonRequestBehavior.AllowGet);
            }
            catch (DbEntityValidationException e)
            {
                //foreach (var eve in e.EntityValidationErrors)
                //{
                //    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                //        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                //    foreach (var ve in eve.ValidationErrors)
                //    {
                //       Debug.WriteLine ("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                //        ve.PropertyName,
                //            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                //            ve.ErrorMessage);
                //    }
                //}
                throw e;
            }
        }

        [HttpPost]
        public JsonResult DeleteProduct(Product delProduct)
        {
            var db = new ProductsDBEntities();
            var product = db.Products.Find(delProduct.Id);
            db.Products.Remove(product);
            db.SaveChanges();
            var products = db.Products.ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}