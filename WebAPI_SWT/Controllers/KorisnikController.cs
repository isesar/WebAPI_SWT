using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebAPI_SWT.DTOs.KorisnikDTO;
using WebAPI_SWT.Helpers;
using WebAPI_SWT.Models;
using WebAPI_SWT.Services;
using WebAPI_SWT.Services.KorisnikServices;


namespace WebAPI_SWT.Controllers
{
    
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _repository;
        private readonly IMapper _mapper;
       

        public KorisnikController(IKorisnikService repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/korisnik")]
        public ActionResult<IEnumerable<Korisnik>> GetAll()
        {
            var korisnici = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<Korisnik>>(korisnici));
        }


        
        [HttpGet("{id}")]
        [Route("api/korisnik/{id}")]
        public ActionResult<KorisnikDTO> GetKorisnikById(int id)
        {
            var korisnik = _repository.GetKorisnikById(id);
            if (korisnik != null)
            {
                return Ok(_mapper.Map<Korisnik>(korisnik));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("api/korisnik/")]
        public ActionResult<CreateKorisnikDTO> CreateKorisnik(CreateKorisnikDTO createKorisnik)
        {
            var korisnikModel = _mapper.Map<Korisnik>(createKorisnik);
            _repository.CreateKorisnik(korisnikModel);
            _repository.SaveChanges();
            var korisnikRead = _mapper.Map<KorisnikDTO>(korisnikModel);
            return CreatedAtAction(nameof(GetKorisnikById), new { Id = korisnikModel.KorisnikId }, korisnikRead);
        }
        [HttpPut]
        [Route("api/korisnik/{id}")]
        public ActionResult UpdateKorisnik(int id,UpdateKorisnikDTO updateKorisnik )
        {
            var korisnikModel = _repository.GetKorisnikById(id);
            if (korisnikModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateKorisnik, korisnikModel);
            _repository.UpdateKorisnik(korisnikModel);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("api/korisnik/{id}")]
        public ActionResult DeleteKorisnik(int id)
        {
            var korisnikModel = _repository.GetKorisnikById(id);
            if (korisnikModel == null)
            {
                return NotFound();
            }
            _repository.DeleteKorisnik(korisnikModel);
            _repository.SaveChanges();
            return NoContent();

        }

    }
}