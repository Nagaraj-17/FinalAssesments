using ClassLibrary1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BotMvc.Controllers
{
    public class BotuqueController : Controller
    {
        public ActionResult GetCloths()
        {
            var con = new DataBaseConnection();
            var cloth = con.GetCloths();
            return View(cloth);
        }
        public ActionResult AddNewBotuque()
        {
            var con = new DataBaseConnection();
            return View(new botuque());
        }
        [HttpPost]
        public ActionResult AddNewBotuque(botuque Botuque)
        {
           var con=new DataBaseConnection();
            try
            {
                con.AddNewBotuque(Botuque);
                return View("");
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                ViewBag.ErrorMessage = message;
                return View(new botuque());
            }
        }
       
        public ActionResult UpdateBotuque(string id)
        {
            int ClothId = Convert.ToInt32(id)
;
            var con = new DataBaseConnection();
            try
            {
                
                return View("");
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPost]
        public ActionResult UpdateBotuque(botuque Botuque)
        {
           
            var con = new DataBaseConnection();
            try
            {
                con.UpdateBotuque(Botuque);
                return View();
               
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ActionResult DeleteBotuque(string id)
        {
            var con = new DataBaseConnection();
            int ClothId = Convert.ToInt32(id)
;
            try
            {
                con.DeleteBotuque(ClothId);
                return View();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw ex;
            }
        }
    }
}
