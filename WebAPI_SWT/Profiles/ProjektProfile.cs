using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.DTOs.ProjektDTO;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Profiles
{
    public class ProjektProfile : Profile
    { 

        public ProjektProfile()
        {
            CreateMap<Projekt, ProjektDTO>();
            CreateMap<CreateProjektDTO, Projekt>();
            CreateMap<UpdateProjektDTO, Projekt>();
            CreateMap<Projekt, UpdateProjektDTO>();

        }
    }
}
