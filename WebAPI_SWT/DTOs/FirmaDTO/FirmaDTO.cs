﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.DTOs.FirmaDTO
{
    public class FirmaDTO
    {
        public int FirmaId { get; set; }
        public string FirmaIme { get; set; }
        public int? FkMjesto { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }

       
    }
}
