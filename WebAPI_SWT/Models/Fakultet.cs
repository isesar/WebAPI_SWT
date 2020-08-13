using System;
using System.Collections.Generic;

namespace WebAPI_SWT.Models
{
    public partial class Fakultet
    {
        public Fakultet()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        public int FakultetId { get; set; }
        public string FakultetIme { get; set; }
        public string Adresa { get; set; }
        public int? FkMjesto { get; set; }

        public virtual Mjesto FkMjestoNavigation { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
