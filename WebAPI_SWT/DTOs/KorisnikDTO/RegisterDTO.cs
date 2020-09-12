﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SWT.DTOs.KorisnikDTO
{
    public class RegisterDTO
    { 

        [Required]
        public string Ime { get; set; }
        [Required]
        public string KorisnickoIme { get; set; }
        [Required]
        public string Lozinka { get; set; }

    }
}
