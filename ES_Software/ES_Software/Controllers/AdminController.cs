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
        [HttpPost]
        public ActionResult AdminIngresarRecurso(ES_Software.Models.AdminModelRecursos model)
        {
            return View();
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
            return View();
        }
    
        public ActionResult Editar(string returnUrl, string id)
        {

            ViewBag.ReturnUrl = returnUrl;
            var sClient = new SmtpClient("smtp-mail.outlook.com");
            var message = new System.Net.Mail.MailMessage();

            sClient.Port = 587;
            sClient.Host = "smtp.office365.com";
            sClient.EnableSsl = true;
            sClient.UseDefaultCredentials = false;
            sClient.EnableSsl = false;
            sClient.Credentials = new NetworkCredential("es.eventos.rs@outlook.com", "Eseventos");
            sClient.UseDefaultCredentials = false;

            message.Body = "Test";
            message.From = new MailAddress("es.eventos.rs@outlook.com");
            message.Subject = "Test";
            message.CC.Add(new MailAddress("ibarqueroga@gmail.com"));

            sClient.Send(message);


            return View("AdminHistorial");

        }

    }
}