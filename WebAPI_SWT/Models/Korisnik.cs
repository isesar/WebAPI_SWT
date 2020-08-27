using System;
using System.Collections.Generic;

namespace WebAPI_SWT.Models
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Aktivnost = new HashSet<Aktivnost>();
            Recenzija = new HashSet<Recenzija>();
            Zadatak = new HashSet<Zadatak>();
        }

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public int? BrojTelefona { get; set; }
        public int? Firma { get; set; }
        public int? Fakultet { get; set; }
        public int? Uloga { get; set; }
        public int? Projekt { get; set; }
        public bool? IsAuthenticated { get; set; }
        public string Mail { get; set; }

        public virtual Fakultet FakultetNavigation { get; set; }
        public virtual Firma FirmaNavigation { get; set; }
        public virtual Projekt ProjektNavigation { get; set; }
        public virtual Uloga UlogaNavigation { get; set; }
        public virtual ICollection<Aktivnost> Aktivnost { get; set; }
        public virtual ICollection<Recenzija> Recenzija { get; set; }
        public virtual ICollection<Zadatak> Zadatak { get; set; }
    }
}
