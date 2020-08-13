using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SQLitePCL;
using WebAPI_SWT.DTOs.FirmaDTO;
using WebAPI_SWT.Models;
using WebAPI_SWT.Services.FirmaServices;

namespace WebAPI_SWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FirmaController : ControllerBase
    {
        private readonly IFirmaService _repository;
        private readonly IMapper _mapper;

        public FirmaController(IFirmaService repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("api/firma")]
        public ActionResult<IEnumerable<Firma>> GetAll()
        {
            var firme = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<Firma>>(firme));
        }


        [HttpGet("{id}")]
        [Route("api/firma/{id}", Name = "GetKorisnikById")]
        public ActionResult<FirmaDTO> GetFirmaById(int id)
        {
            var firma = _repository.GetFirmaById(id);
            if (firma != null)
            {
                return Ok(_mapper.Map<Firma>(firma));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("api/firma/")]
        public ActionResult<CreateFirmaDTO> CreateCommand(CreateFirmaDTO createFirma)
        {
            var firmaModel = _mapper.Map<Firma>(createFirma);
            _repository.CreateFirma(firmaModel);
            _repository.SaveChanges();
            var firmaRead = _mapper.Map<CreateFirmaDTO>(firmaModel);

            return CreatedAtRoute(nameof(GetFirmaById), new { Id = firmaModel.FirmaId }, firmaRead);
        }
        [HttpPut]
        [Route("api/korisnik/{id}")]
        public ActionResult UpdateKorisnik(int id, CreateFirmaDTO updateFirma)
        {
            var firmaModel = _repository.GetFirmaById(id);
            if (firmaModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateFirma, firmaModel);
            _repository.UpdateFirma(firmaModel);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("api/korisnik/{id}")]
        public ActionResult DeleteKorisnik(int id)
        {
            var firmaModel = _repository.GetFirmaById(id);
            if (firmaModel == null)
            {
                return NotFound();
            }
            _repository.DeleteFirma(firmaModel);
            _repository.SaveChanges();
            return NoContent();

        }
    }
}