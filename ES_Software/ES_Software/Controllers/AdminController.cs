using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ES_Software.Controllers
{
    public class AdminController : Controller
    {
     
        public ActionResult AdminRegistro()
        {
            return View();
        }
        public ActionResult AdminPaquetes()
        {
            return View();
        }
        public ActionResult AdminRecursos()
        {
            return View();
        }
        public ActionResult AdminHistorial()
        {
            return View();  
        }
        
        public ActionResult AdminIngresarRecurso(ES_Software.Models.AdminModelRecursos model, IList<string> MyCheckboxes)
        {
            return View("AdminRecursos");
        }
        public ActionResult AdminEditarRecurso()
        {
            return View();
        }
        public ActionResult AdminIngresarPaquete()
        {
            return View();
        }
        public ActionResult AdminEditarPaquete()
        {
            return View("AdminPaquetes");
        }
    
        public ActionResult EditarRecurso(string returnUrl, string id)
        {

            return View("AdminPaquetes");

        }
        
        public ActionResult EliminarRecurso(string returnUrl, string id)
        {
            return View("AdminHistorial");

        }


    }
}