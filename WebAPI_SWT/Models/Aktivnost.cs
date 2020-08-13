using System;
using System.Collections.Generic;

namespace WebAPI_SWT.Models
{
    public partial class Aktivnost
    {
        public Aktivnost()
        {
            Recenzija = new HashSet<Recenzija>();
        }

        public int AktivnostId { get; set; }
        public string Opis { get; set; }
        public DateTime? DatumKreiranja { get; set; }
        public int? FkKorisnik { get; set; }
        public int? ZadatakId { get; set; }
        public bool? Odobreno { get; set; }

        public virtual Korisnik FkKorisnikNavigation { get; set; }
        public virtual Zadatak Zadatak { get; set; }
        public virtual ICollection<Recenzija> Recenzija { get; set; }
    }
}
