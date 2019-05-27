using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [Display(Name = "Nombre")]
        public string nombreRecurso { get; set; }

        [Required]
        [Display(Name = "TipoRecurso")]
        public string tipoRecurso { get; set; }

     
        [Display(Name ="Teléfono")]
        public string telefono { get; set; }

        [Display(Name ="Correo")]
        public string correo { get; set; }

        [Display(Name ="Provincia")]
        public string provincia { get; set; }


    }
    public class AdminModelPaquetes
    {
      
    }
}