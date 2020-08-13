using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.DTOs.ProjektDTO
{
    public class ProjektDTO
    {
        public int ProjektId { get; set; }
        public string Opis { get; set; }
        public string Ime { get; set; }
        public DateTime? DatumPocetka { get; set; }
        public DateTime? DatunZavrsetka { get; set; }
        public int? FkFirma { get; set; }
        public bool? IsOver { get; set; }

        public virtual Firma FkFirmaNavigation { get; set; }
    }
}
