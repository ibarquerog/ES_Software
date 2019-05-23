using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Administrador")]
        public bool Admin { get; set; }
    }

    public class ClientRegisterViewModel
    {
        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Usuario")]
        public string User { get; set; }

        [Required]
        [Display(Name="Cédula")]
        public string clientID { get; set; }


        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

    }
    

