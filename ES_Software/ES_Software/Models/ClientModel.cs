using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ES_Software.Models
{
    public class ClientModel
    {

    }
    public class ClientModelHistorial
    {

    }
    public class ClientModelReservar
    {

    }
    public class ClientModelEditarReservaciones
    {
        [Display(Name = "Fecha (yyyy/mm/dd)")]
        public string Fecha { get; set; }


        [Display(Name = "Hora (24 hrs)")]
        public string Hora { get; set; }
    }
    public class ClientReservar
    {
        [Display(Name = "Fecha (yyyy/mm/dd)")]
        public string Fecha { get; set; }


        [Display(Name = "Hora (24 hrs)")]
        public string Hora { get; set; }
    }
}