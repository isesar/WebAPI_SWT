using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_SWT.DTOs.RecenzijaDTO;
using WebAPI_SWT.Models;
using WebAPI_SWT.Services.RecenzijaServices;

namespace WebAPI_SWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecenzijaController : ControllerBase
    {
        private readonly IRecenzija _repository;
        private IMapper _mapper;

        public RecenzijaController(IRecenzija repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("api/recenzija")]
        public ActionResult<IEnumerable<Recenzija>> GetAll()
        {
            var recenzije = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<Recenzija>>(recenzije));
        }
        [HttpGet("{id}")]
        [Route("api/recenzija/{id}")]
        public ActionResult<RecenzijaDTO> GetRecById(int id)
        {
            var recenzija = _repository.GetRecenzijaById(id);
            if (recenzija != null)
            {
                return Ok(_mapper.Map<Recenzija>(recenzija));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("api/recezija/")]
        public ActionResult<CreateRecenzijaDTO> CreateRecenzija(CreateRecenzijaDTO createRecenzija)
        {
            var recenzijaModel = _mapper.Map<Recenzija>(createRecenzija);
            _repository.CreateRecenzija(recenzijaModel);
            _repository.SaveChanges();
            var recenzijaRead = _mapper.Map<RecenzijaDTO>(recenzijaModel);

            return CreatedAtAction(nameof(GetRecById), new { Id = recenzijaModel.RecenzijaId }, recenzijaRead);
        }

        [HttpPut]
        [Route("api/recenzija/{id}")]
        public ActionResult UpdateRec(int id, UpdateRecenzijaDTO updateRec)
        {
            var recenzijaModel = _repository.GetRecenzijaById(id);
            if (recenzijaModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateRec, recenzijaModel);
            _repository.UpdateRecenzija(recenzijaModel);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("api/recenzija/{id}")]
        public ActionResult DeleteKorisnik(int id)
        {
            var recenzijaModel = _repository.GetRecenzijaById(id);
            if (recenzijaModel == null)
            {
                return NotFound();
            }
            _repository.DeleteRecenzija(recenzijaModel);
            _repository.SaveChanges();
            return NoContent();

        }

    }
}