using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_SWT.DTOs.FakultetDTO;
using WebAPI_SWT.Models;
using WebAPI_SWT.Services.FakultetServices;

namespace WebAPI_SWT.Controllers
{
    
    [ApiController]
    public class FakultetController : ControllerBase
    {
        private readonly IFakultet _repository;
        private readonly IMapper _mapper;

        public FakultetController(IFakultet repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/fakultet")]
        public ActionResult<IEnumerable<Fakultet>> GetAll()
        {
            var fakulteti = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<Fakultet>>(fakulteti));
        }
        [HttpGet("{id}")]
        [Route("api/fakultet/{id}")]
        public ActionResult<FakultetDTO> GetFaxById(int id)
        {
            var fakultet = _repository.GetFakultetById(id);
            if (fakultet != null)
            {
                return Ok(_mapper.Map<Fakultet>(fakultet));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("api/fakultet/")]
        public ActionResult<CreateFakultetDTO> CreateFax(CreateFakultetDTO createFax)
        {
            var faxModel = _mapper.Map<Fakultet>(createFax);
            _repository.CreateFakultet(faxModel);
            _repository.SaveChanges();
            var faxRead = _mapper.Map<FakultetDTO>(faxModel);

            return CreatedAtAction(nameof(GetFaxById), new { Id = faxModel.FakultetId }, faxRead);
        }
        [HttpPut]
        [Route("api/fakultet/{id}")]
        public ActionResult UpdateFax(int id, UpdateFakultetDTO updateFax)
        {
            var faxModel = _repository.GetFakultetById(id);
            if (faxModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateFax, faxModel);
            _repository.UpdateFakultet(faxModel);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("api/fakultet/{id}")]
        public ActionResult DeleteFax(int id)
        {
            var faxModel = _repository.GetFakultetById(id);
            if (faxModel == null)
            {
                return NotFound();
            }
            _repository.DeleteFakultet(faxModel);
            _repository.SaveChanges();
            return NoContent();

        }

    }
}