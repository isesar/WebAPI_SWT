using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.DTOs.AktivnostDTO
{
    public class AktivnostDTO
    {
        public int AktivnostId { get; set; }
        public string Opis { get; set; }
        public DateTime? DatumKreiranja { get; set; }
        public int? FkKorisnik { get; set; }
        public int? ZadatakId { get; set; }
        public bool? Odobreno { get; set; }

        public virtual Korisnik FkKorisnikNavigation { get; set; }
        public virtual Zadatak Zadatak { get; set; }
    }
}
