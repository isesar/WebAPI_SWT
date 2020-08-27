using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_SWT.DTOs.ZadatakDTO;
using WebAPI_SWT.Models;
using WebAPI_SWT.Services.ZadatakServices;

namespace WebAPI_SWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZadatakController : ControllerBase
    {
        private readonly IZadatakServices _repository;
        private readonly IMapper _mapper;

        public ZadatakController(IZadatakServices repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("api/zadatak")]
        public ActionResult<IEnumerable<Zadatak>> GetAll()
        {
            var zadaci = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<Zadatak>>(zadaci));
        }
        [HttpGet("{id}")]
        [Route("api/zadatak/{id}")]
        public ActionResult<ZadatakDTO> GetZadatakById(int id)
        {
            var zadatak = _repository.GetZadatakById(id);
            if (zadatak != null)
            {
                return Ok(_mapper.Map<Zadatak>(zadatak));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("api/zadatak/")]
        public ActionResult<CreateZadatakDTO> CreateZadatak(CreateZadatakDTO createZadatak)
        {
            var zadatakModel = _mapper.Map<Zadatak>(createZadatak);
            _repository.CreateZadatak(zadatakModel);
            _repository.SaveChanges();
            var zadatakRead = _mapper.Map<ZadatakDTO>(zadatakModel);
            return CreatedAtAction(nameof(GetZadatakById), new { Id = zadatakModel.ZadatakId}, zadatakRead);
        }

        [HttpPut]
        [Route("api/zadatak/{id}")]
        public ActionResult UpdateZadatak(int id, UpdateZadatakDTO updateZadatak)
        {
            var zadatakModel = _repository.GetZadatakById(id);
            if (zadatakModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateZadatak,zadatakModel);
            _repository.UpdateZadatak(zadatakModel);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("api/zadatak/{id}")]
        public ActionResult DeleteZadatak(int id)
        {
            var zadatakModel = _repository.GetZadatakById(id);
            if (zadatakModel == null)
            {
                return NotFound();
            }
            _repository.DeleteZadatak(zadatakModel);
            _repository.SaveChanges();
            return NoContent();

        }

    }
}