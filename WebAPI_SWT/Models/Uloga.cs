using System;
using System.Collections.Generic;

namespace WebAPI_SWT.Models
{
    public partial class Uloga
    {
        public Uloga()
        {
            Korisnik = new HashSet<Korisnik>();
        }

        public int UlogaId { get; set; }
        public string Ime { get; set; }

        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
