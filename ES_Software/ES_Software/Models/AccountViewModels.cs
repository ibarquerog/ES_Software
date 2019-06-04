using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Usuario")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contrasña")]
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

        [Display(Name = "Contraseña")]
        public string Password { get; set; }

    }
    

