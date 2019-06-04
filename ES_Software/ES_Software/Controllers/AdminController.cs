using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace ES_Software.Controllers
{
    public class AdminController : Controller
    {
        public static string cliente = "";

        static string recurso = "";

        public static string Recurso { get => recurso; set => recurso = value; }

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
        
        public ActionResult AdminIngresarRecurso(ES_Software.Models.AdminModelRecursos model)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("RegistrarRecurso", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@tipoRecurso", System.Data.SqlDbType.VarChar, 50).Value = model.tipoRecurso.ToString();
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = model.nombreRecurso.ToString();
            cmd.Parameters.Add("@telefono", System.Data.SqlDbType.BigInt).Value = Int32.Parse(model.telefono.ToString());
            cmd.Parameters.Add("@correo", System.Data.SqlDbType.VarChar,50).Value = model.correo.ToString();
            cmd.Parameters.Add("@provincia", System.Data.SqlDbType.VarChar, 50).Value = model.provincia.ToString();

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
            return View("AdminRecursos");
        }
        public ActionResult AdminEditarRecurso()
        {
            return View();
        }

        public ActionResult AdminEditarPaquete()
        {
            return View("AdminPaquetes");
        }





        [HttpPost]
        public ActionResult AdminRegistroAdministrador(ES_Software.Models.AdminRegistrarAdministrador model, string returnUrl)
        {

            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("RegistrarAdministrador", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = model.Nombre.ToString();
            cmd.Parameters.Add("@codigoEmpleado", System.Data.SqlDbType.VarChar, 50).Value = model.IDEmpleado.ToString();
            cmd.Parameters.Add("@usuario", System.Data.SqlDbType.VarChar, 50).Value = model.Usuario.ToString();
            cmd.Parameters.Add("@clave", System.Data.SqlDbType.VarChar, 50).Value = model.Contrasena.ToString();
            cmd.Parameters.Add("@cedula", System.Data.SqlDbType.BigInt).Value = Int32.Parse(model.Cedula.ToString());
            cmd.Parameters.Add("@telefono", System.Data.SqlDbType.BigInt).Value = 55555;
            cmd.Parameters.Add("@direccion", System.Data.SqlDbType.VarChar,50).Value = "-------";
            cmd.Parameters.Add("@correo", System.Data.SqlDbType.VarChar, 50).Value = model.Correo.ToString();


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
            return View("AdminRegistroAdministradores");
        }

        public ActionResult AdminRegistroAdministradores()
        {

            return View();
        }


        public ActionResult EliminarRecurso(string returnUrl, string nombreRecurso)
        {

            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("EliminarRecurso", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = nombreRecurso;

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
            return View("AdminRecursos");

        }

        public ActionResult AdminIngresarPaquete (ES_Software.Models.AdminModelPaquetes model, IList<string> MyCheckboxes)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("RegistrarPaquete", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = model.nombrePaquete.ToString();
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

            if (MyCheckboxes != null)
            {



                for (int i = 0; i < MyCheckboxes.Count(); i++)
                { 
                    SqlConnection conexion2 = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
                    SqlCommand cmd2 = new SqlCommand("AgregarProductosPaquete", conexion2);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add("@nombrePaquete", System.Data.SqlDbType.VarChar, 50).Value = model.nombrePaquete.ToString();
                    cmd2.Parameters.Add("@NombreProducto", System.Data.SqlDbType.VarChar, 50).Value = MyCheckboxes[i].ToString();
                    try
                    {
                        conexion2.Open();
                        cmd2.ExecuteNonQuery();

                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                    finally
                    {
                        conexion2.Close();
                        conexion2.Dispose();
                    }
                }
            }
            
            return View("AdminPaquetes");
        }

        public ActionResult EliminarPaquete(string returnUrl, string id)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View("AdminPaquetes");
        }
        public ActionResult AdminProductos()
        {
            return View();
        }

        public ActionResult AdminIngresarProducto(ES_Software.Models.AdminProductosModel model, IList<string> MyCheckboxes)
        {
            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("RegistrarProducto", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@idRecurso", System.Data.SqlDbType.VarChar, 50).Value = MyCheckboxes[0].ToString();
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = model.Nombre.ToString();
            cmd.Parameters.Add("@disponible", System.Data.SqlDbType.Int).Value = int.Parse(model.Disponible.ToString());
            cmd.Parameters.Add("@precio", System.Data.SqlDbType.Money).Value = int.Parse(model.Precio.ToString());

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
            return View("AdminProductos");
        }

        [HttpPost]
        public ActionResult AdminModificarRecurso(ES_Software.Models.AdminModelRecursos model, string returnUrl)
        {

            SqlConnection conexion = new SqlConnection("Data Source=DESKTOP-2OQBEMO;Initial Catalog=ESSoftware;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("ModificarRecurso", conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar, 50).Value = recurso;
            cmd.Parameters.Add("@telefono", System.Data.SqlDbType.BigInt).Value = Int32.Parse(model.telefono.ToString());
            cmd.Parameters.Add("@correo", System.Data.SqlDbType.VarChar, 50).Value = model.correo.ToString();
            cmd.Parameters.Add("@provincia", System.Data.SqlDbType.VarChar, 50).Value = model.provincia.ToString();

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
            return View("AdminRecursos");
        }
        public ActionResult EditarRecurso(ES_Software.Models.AdminModelRecursos model, string id)
        {

            recurso = id;
            ViewBag.ReturnUrl = returnUrl;
            return View("AdminModificarRecurso");
        }

    }
}