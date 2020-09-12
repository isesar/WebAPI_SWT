using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.DTOs.ZadatakDTO;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Profiles
{
    public class ZadatakProfile : Profile
    {

        public ZadatakProfile()
        {
            CreateMap<Zadatak, ZadatakDTO>();
            CreateMap<CreateZadatakDTO, Zadatak>();
            CreateMap<UpdateZadatakDTO, Zadatak>();
            CreateMap<Zadatak, UpdateZadatakDTO>();
        }
    }
}
