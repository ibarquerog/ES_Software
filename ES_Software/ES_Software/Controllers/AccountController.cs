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
using System.Data.SqlClient;
using System.Data;

namespace ES_Software.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        static string usario_ctivo = "";

        public static string Usario_ctivo { get => usario_ctivo; set => usario_ctivo = value; }

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
            if (model.Admin)
            {

                SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("LoginAdministrador", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombreUsuario", System.Data.SqlDbType.VarChar, 50).Value = model.Email.ToString();
                cmd.Parameters.Add("@clave", System.Data.SqlDbType.VarChar, 50).Value = model.Password.ToString();
                cmd.Parameters.Add("@retValue", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

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
                int retval = (int)cmd.Parameters["@retValue"].Value;
                if (retval == 0)
                {
                    return Content("<script language='javascript' type='text/javascript'>alert     ('Error: Usuario o contraseña incorrecto ');</script>");
                }
                else
                {
                    return View("../Admin/AdminHistorial");
                }
                

            }
            else
            {
                SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
                SqlCommand cmd = new SqlCommand("LoginCliente", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombreUsuario", System.Data.SqlDbType.VarChar, 50).Value = model.Email.ToString();
                cmd.Parameters.Add("@clave", System.Data.SqlDbType.VarChar, 50).Value = model.Password.ToString();
                cmd.Parameters.Add("@retValue", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;

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
                int retval = (int)cmd.Parameters["@retValue"].Value;
                if (retval == 0)
                {
                    
                    return Content("<script language='javascript' type='text/javascript'>alert     ('Error: Usuario o contraseña incorrecto ');</script>");
                }
                else
                {
                    usario_ctivo = model.Email.ToString();
                    return View("../Client/Historial");
                }
            }
            

        }
        [HttpPost]
        [AllowAnonymous]
        public ActionResult Editar(string returnUrl, string id)
        {

            ViewBag.ReturnUrl = returnUrl;
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
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("RegistrarCliente", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Nombre", System.Data.SqlDbType.VarChar, 50).Value = model.Name.ToString();
            cmd.Parameters.Add("@Usuario", System.Data.SqlDbType.VarChar,50).Value = model.User.ToString();
            cmd.Parameters.Add("@Clave", System.Data.SqlDbType.VarChar, 50).Value = model.Password.ToString();
            cmd.Parameters.Add("@Cedula", System.Data.SqlDbType.BigInt).Value = Int32.Parse(model.clientID.ToString());
            cmd.Parameters.Add("@Telefono", System.Data.SqlDbType.BigInt).Value = Int32.Parse(model.clientID.ToString());
            cmd.Parameters.Add("@Direccion", System.Data.SqlDbType.VarChar, 50).Value = "------";
            cmd.Parameters.Add("@Correo", System.Data.SqlDbType.VarChar, 50).Value = model.Email.ToString();

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
            return View();
        }
    }
}