using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_SWT.Entities
{
    public class Korisnik
    {

        public int KorisnikId { get; set; }
        public string Ime { get; set; }
        public  string KorisnickoIme { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
