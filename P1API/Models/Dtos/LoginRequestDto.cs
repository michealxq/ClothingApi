﻿using System.ComponentModel.DataAnnotations;

namespace P1API.Models.Dtos
{
    public class LoginRequestDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
    }
}
