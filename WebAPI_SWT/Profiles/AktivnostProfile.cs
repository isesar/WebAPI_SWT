using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.DTOs.AktivnostDTO;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Profiles
{
    public class AktivnostProfile : Profile
    {

        public AktivnostProfile()
        {
            CreateMap<Aktivnost, AktivnostDTO>();
            CreateMap<CreateAktivnostDTO, Aktivnost>();
            CreateMap<UpdateAktivnostDTO, Aktivnost>();
            CreateMap<Aktivnost, UpdateAktivnostDTO>();
        }



    }

}
