using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.DTOs.FirmaDTO;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Profiles
{
    public class FirmaProfile : AutoMapper.Profile
    {

        public  FirmaProfile(){
            CreateMap<Firma, FirmaDTO>();
            CreateMap<CreateFirmaDTO, Firma>();
            CreateMap<UpdateFirmaDTO, Firma>();
            CreateMap<Firma, UpdateFirmaDTO>();
        }

    }
}
