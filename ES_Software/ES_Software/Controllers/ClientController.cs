using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace ES_Software.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
        public ActionResult Historial()
        {
            return View();
        }

        public void sendNotificationEmail()
        {

        }
        
        public ActionResult Editar(string returnUrl, string id)
        {


            var sClient = new SmtpClient("smtp-mail.outlook.com");
            var message = new MailMessage();

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


            return View("Historial");

        }
        [AllowAnonymous]
        public ActionResult Reservar(string returnUrl, string id)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();  

        }
    }
}