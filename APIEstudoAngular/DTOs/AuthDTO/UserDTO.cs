﻿using System.ComponentModel.DataAnnotations;

namespace APIEstudoAngular.API.DTOs.AuthDTO
{
    //public class RegisterUserDTO
    //{
    //    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    //    [EmailAddress(ErrorMessage = "O campo {0} está em um formato inválido.")]
    //    public string Email { get; set; }

    //    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    //    [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
    //    public string Password { get; set; }

    //    [Compare("Password", ErrorMessage = "As senhas não conferem.")]
    //    public string ConfirmPassword { get; set; }
    //}

    public class LoginUserDTO
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [EmailAddress(ErrorMessage = "O campo {0} está em um formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
