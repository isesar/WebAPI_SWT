using System;
using System.Collections.Generic;

namespace WebAPI_SWT.Models
{
    public partial class Mjesto
    {
        public Mjesto()
        {
            Fakultet = new HashSet<Fakultet>();
            Firma = new HashSet<Firma>();
        }

        public int MjestoId { get; set; }
        public string Ime { get; set; }

        public virtual ICollection<Fakultet> Fakultet { get; set; }
        public virtual ICollection<Firma> Firma { get; set; }
    }
}
