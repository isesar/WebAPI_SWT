using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Services.FirmaServices
{
    public interface IFirmaService
    {
        bool SaveChanges();
        IEnumerable<Firma> GetAll();
        Firma GetFirmaById(int id);
        void CreateFirma(Firma firma);
        void UpdateFirma(Firma firma);
        void DeleteFirma(Firma firma);

    }
}
