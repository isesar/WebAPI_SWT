using System;
using System.Collections.Generic;

namespace WebAPI_SWT.Models
{
    public partial class Zadatak
    {
        public Zadatak()
        {
            Aktivnost = new HashSet<Aktivnost>();
        }

        public int ZadatakId { get; set; }
        public string Opis { get; set; }
        public DateTime? DatumKreiranja { get; set; }
        public int? KorisnikId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual ICollection<Aktivnost> Aktivnost { get; set; }
    }
}
