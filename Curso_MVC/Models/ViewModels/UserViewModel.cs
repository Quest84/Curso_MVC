using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Curso_MVC.Models.ViewModels
{
    public class UserViewModel
    {
        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set;  }

        [Display(Name = "Confirma Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La edad solo puede ser de 0 a 100, lo siento persona milenaria o no nacido" )]
        public int Edad { get; set; }

    }

    public class EditUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "El {0} debe tener al menos {1} caracteres")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Confirma Contraseña")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Las contraseñas no son iguales")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Range(0, 100, ErrorMessage = "La edad solo puede ser de 0 a 100, lo siento persona milenaria o no nacido")]
        public int Edad { get; set; }

    }
}