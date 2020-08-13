using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.DTOs.ZadatakDTO
{
    public class ZadatakDTO
    {
        public int ZadatakId { get; set; }
        public string Opis { get; set; }
        public DateTime? DatumKreiranja { get; set; }
        public int? KorisnikId { get; set; }

        public virtual Korisnik Korisnik { get; set; }


    }
}
