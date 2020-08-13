using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.DTOs.FakultetDTO
{
    public class FakultetDTO
    {

        public int FakultetId { get; set; }
        public string FakultetIme { get; set; }
        public string Adresa { get; set; }
        public int? FkMjesto { get; set; }

        public virtual Mjesto FkMjestoNavigation { get; set; }
    }
}
