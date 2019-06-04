using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ES_Software.Models
{
    public class AdminModel
    {
    }

    public class AdminModelHistorial
    {

    }
    public class AdminModelRegistro
    {

    }
    public class AdminModelRecursos
    {
        [Display(Name = "Nombre")]
        public string nombreRecurso { get; set; }

        [Display(Name = "TipoRecurso")]
        public string tipoRecurso { get; set; }

     
        [Display(Name ="Teléfono")]
        public string telefono { get; set; }

        [Display(Name ="Correo")]
        public string correo { get; set; }

        [Display(Name ="Provincia")]
        public string provincia { get; set; }

        public static IEnumerable<SelectListItem> GetGenderSelectItems()
        {
            yield return new SelectListItem { Text = "Música", Value = "Musica" };
            yield return new SelectListItem { Text = "Local", Value = "Local" };
            yield return new SelectListItem { Text = "Decoración", Value = "Decoracion" };
            yield return new SelectListItem { Text = "Catering", Value = "Catering" };
        }


    }
    public class AdminModelPaquetes
    {
  
        [Display(Name = "Nombre")]
        public string nombrePaquete { get; set; }

    }
    public class AdminRegistrarAdministrador
    {
        [Required]
        [Display(Name = "ID Empleado")]
        public string IDEmpleado { get; set; }

        [Required]
        [Display(Name = "Correo")]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Display(Name = "Usuario")]
        public string Usuario { get; set; }

        [Display(Name = "Cédula")]
        public string Cedula { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Contrasena { get; set; }
    }

    public class AdminProductosModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Disponible")]
        public string Disponible { get; set; }

        [Required]
        [Display(Name = "Precio")]
        public string Precio { get; set; }
    }
    public class AdminModelRecursosModificar
    {
        [Display(Name = "Nombre")]
        public string nombreRecurso { get; set; }

        [Display(Name = "TipoRecurso")]
        public string tipoRecurso { get; set; }


        [Display(Name = "Teléfono")]
        public string telefono { get; set; }

        [Display(Name = "Correo")]
        public string correo { get; set; }

        [Display(Name = "Provincia")]
        public string provincia { get; set; }



    }
}