﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text;

namespace SinavProje.Entities.Concrete.ClientEntities.Request
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress(ErrorMessage = "Lütfen geçerli bir email adresi giriniz!")]
        public string Email { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Password en az 5 karakter olmalıdır.")]
        public string Password { get; set; }
    }
}
