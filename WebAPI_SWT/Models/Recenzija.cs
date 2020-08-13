using System;
using System.Collections.Generic;

namespace WebAPI_SWT.Models
{
    public partial class Recenzija
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
