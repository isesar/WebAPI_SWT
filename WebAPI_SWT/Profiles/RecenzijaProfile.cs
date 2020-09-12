using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.DTOs.RecenzijaDTO;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Profiles
{
    public class RecenzijaProfile : Profile
    {

        public RecenzijaProfile()
        {
            CreateMap<Recenzija, RecenzijaDTO>();
            CreateMap<CreateRecenzijaDTO, Recenzija>();
            CreateMap<UpdateRecenzijaDTO, Recenzija>();
            CreateMap<Recenzija, UpdateRecenzijaDTO>();
        }

    }
}
