using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ES_Software.Models;
using System.Net.Mail;
using System.Net;
using System.Web.Mail;
using System.Text;

namespace ES_Software.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        public AccountController()
        {
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!model.Admin)
            {
                return View("../Client/Historial");
            }
            else
            {
                return View("../Admin/AdminHistorial");
             }
            
        }
        [HttpPost]
        [AllowAnonymous]
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


            return View("Historial");

        }



        [AllowAnonymous]
        public ActionResult Register (string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Register(ClientRegisterViewModel model)
        {
            return View();
        }
    }
}