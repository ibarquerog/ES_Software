using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
       
        static string paqueteActual = "";

        public static string Paquete { get => paqueteActual; set => paqueteActual = value; }

        static string reservacionActual = "";

        public static string ReservacionActual { get => reservacionActual; set => reservacionActual = value; }

        public ActionResult Historial()
        {
            return View();
        }

        public void sendNotificationEmail()
        {

        }
        
        public ActionResult Editar(string returnUrl, string id)
        {

            return View("Historial");

        }
        public ActionResult EnviarCorreo(string returnUrl,string id)
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


            return View("Reservar");
        }

        [AllowAnonymous]
        public ActionResult Reservar(string returnUrl, string id)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();  

        }
        public ActionResult ReservarPaquete(ES_Software.Models.ClientReservar model, IList<string> MyCheckboxes)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("RealizarReservacion", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            string usuario= ES_Software.Controllers.AccountController.Usario_ctivo; ;
            cmd.Parameters.Add("@nombreCliente", System.Data.SqlDbType.VarChar, 50).Value = usuario;
            cmd.Parameters.Add("@paquete", System.Data.SqlDbType.Int).Value = int.Parse(MyCheckboxes[0]);
            cmd.Parameters.Add("@fecha", System.Data.SqlDbType.VarChar,50).Value = model.Fecha.ToString();
            cmd.Parameters.Add("@hora", System.Data.SqlDbType.VarChar,50).Value = model.Hora.ToString();   


            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
            return View("Reservar");
        }

        public ActionResult MostrarDetalles(string returnUrl, string paquete)
        {
            paqueteActual = paquete;
            return View();
        }
        
        public ActionResult ModificarReservaciones(string returnUrl, string id)
        {
            reservacionActual = id;
            return View("ModificarReservacion");

        }
        [HttpPost]
        public ActionResult ModificarReservacion(ES_Software.Models.ClientReservar model)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("ModificarReservacion", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            string usuario = ES_Software.Controllers.AccountController.Usario_ctivo; ;
            cmd.Parameters.Add("@nombreCliente", System.Data.SqlDbType.VarChar, 50).Value = usuario;
            cmd.Parameters.Add("@numeroReservacion", System.Data.SqlDbType.Int).Value = int.Parse(reservacionActual);
            cmd.Parameters.Add("@fecha", System.Data.SqlDbType.VarChar, 50).Value = model.Fecha.ToString();
            cmd.Parameters.Add("@hora", System.Data.SqlDbType.VarChar, 50).Value = model.Hora.ToString();

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
            return View("Historial");

        }
        public ActionResult EliminarReservacion(string returnUrl, string id)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("EliminarReservacion", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            string usuario = ES_Software.Controllers.AccountController.Usario_ctivo; ;
            cmd.Parameters.Add("@nombreCliente", System.Data.SqlDbType.VarChar, 50).Value = usuario;
            cmd.Parameters.Add("@numeroReservacion", System.Data.SqlDbType.Int).Value = int.Parse(id);

            try
            {
                conexion.Open();
                cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                conexion.Close();
                conexion.Dispose();
            }
            return View("Historial");

        }


    }
}