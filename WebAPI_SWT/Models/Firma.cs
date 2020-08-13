using System;
using System.Collections.Generic;

namespace WebAPI_SWT.Models
{
    public partial class Firma
    {
        public Firma()
        {
            Korisnik = new HashSet<Korisnik>();
            Projekt = new HashSet<Projekt>();
        }

        public int FirmaId { get; set; }
        public string FirmaIme { get; set; }
        public int? FkMjesto { get; set; }
        public string Adresa { get; set; }
        public string Email { get; set; }

        public virtual Mjesto FkMjestoNavigation { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
        public virtual ICollection<Projekt> Projekt { get; set; }
    }
}
