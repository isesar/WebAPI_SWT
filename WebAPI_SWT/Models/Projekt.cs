using System;
using System.Collections.Generic;

namespace WebAPI_SWT.Models
{
    public partial class Projekt
    {
        public Projekt()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        public int ProjektId { get; set; }
        public string Opis { get; set; }
        public string Ime { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public DateTime? DatumZavrsetka { get; set; }
        public int? FkFirma { get; set; }
        public bool? IsOver { get; set; }

        public virtual Firma FkFirmaNavigation { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
