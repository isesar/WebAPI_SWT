using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.DTOs.KorisnikDTO
{
    public class CreateKorisnikDTO
    {
     
    public string Ime { get; set; }
    public string KorisnickoIme { get; set; }
    public string Lozinka { get; set; }
    public int? BrojTelefona { get; set; }
    public int? Firma { get; set; }
    public int? Fakultet { get; set; }
    public int? Uloga { get; set; }
    public int? Projekt { get; set; }

    }

}