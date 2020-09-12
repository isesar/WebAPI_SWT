using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.DTOs.KorisnikDTO
{
    public class KorisnikDTO
    {
        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public string KorisnickoIme { get; set; }
        public string Lozinka { get; set; }
        public int? BrojTelefona { get; set; }
        public int? Firma { get; set; }
        public string Mail { get; set; }
        public string Token { get; set; }
        public virtual Fakultet FakultetNavigation { get; set; }
        public virtual Firma FirmaNavigation { get; set; }
        public virtual Projekt ProjektNavigation { get; set; }
        public virtual Uloga UlogaNavigation { get; set; }

    }
}
