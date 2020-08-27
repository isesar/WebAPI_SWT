using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.DTOs.KorisnikDTO;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Profiles
{
    public class KorisnikProfile : AutoMapper.Profile
    {
        public KorisnikProfile()
        {
            CreateMap<Korisnik, KorisnikDTO>();
            CreateMap<CreateKorisnikDTO, Korisnik>();
            CreateMap<CreateKorisnikDTO, Korisnik>();
            CreateMap<Korisnik, CreateKorisnikDTO>();
        }


    }


   
}
