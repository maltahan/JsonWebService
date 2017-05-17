using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Web.Script.Services;

namespace FirstRestApi.Controllers
{
    public class HomeController : Controller
    {
        Northwind db = new Northwind();
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string  GetElements()
        {
            var CustomerContactNames = db.Customers.Select(a => a.ContactName).ToArray();

            var test = db.Customers.Select(a => new {

               a.CustomerID,              
               a.ContactTitle,
               a.CompanyName,
               a.City,
               a.Address,
               a.ContactName
            });

            return new JavaScriptSerializer().Serialize(test);
            
        }
     
        public JsonResult GetElements1()
        {
            var CustomerContactNames = db.Customers.Select(a => a.ContactName).ToArray();

            var test = db.Customers.Select(a => new {

                a.CustomerID,
                CustomerTitle = a.ContactTitle,
                a.CompanyName,
                a.City,
                a.Address
            });
            dynamic data = Json(test,JsonRequestBehavior.AllowGet);
            return data;
        }

        public ActionResult test()
        {
            var s = GetElements1();

            List<Customer> jsonObj = null;

             jsonObj = JsonConvert.DeserializeObject<List<Customer>>(GetElements());

            return View(jsonObj);

           
        }

    }
}