using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.DTOs.FakultetDTO;
using WebAPI_SWT.Models;
using AutoMapper;
namespace WebAPI_SWT.Profiles
{
    public class FakultetProfile : AutoMapper.Profile
    {

        public FakultetProfile()
        {
            CreateMap<Fakultet, FakultetDTO>();
            CreateMap<CreateFakultetDTO, Fakultet>();
            CreateMap<UpdateFakultetDTO, Fakultet>();
            CreateMap<Fakultet, UpdateFakultetDTO>();
        }
    }
}
