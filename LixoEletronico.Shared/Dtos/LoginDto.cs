﻿using System.ComponentModel.DataAnnotations;

namespace LixoEletronico.Shared.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "User name is required")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }
    }
}
