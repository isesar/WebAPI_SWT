using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.DTOs.RecenzijaDTO
{
    public class RecenzijaDTO
    {
        public int RecenzijaId { get; set; }
        public string Opis { get; set; }
        public DateTime? DatumKreiranja { get; set; }
        public int? FkKorisnik { get; set; }
        public string ZadatakId { get; set; }
        public int? AktivnostId { get; set; }

        public virtual Aktivnost Aktivnost { get; set; }
        public virtual Korisnik FkKorisnikNavigation { get; set; }

    }
}
