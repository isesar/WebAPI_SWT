using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_SWT.DTOs.AktivnostDTO;
using WebAPI_SWT.Models;
using WebAPI_SWT.Services.AktivnostServices;

namespace WebAPI_SWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AktivnostController : ControllerBase
    {
        private readonly IAktivnostServices _repository;
        private IMapper _mapper;

        public AktivnostController(IAktivnostServices repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("api/aktivnosti")]
        public ActionResult<IEnumerable<Aktivnost>> GetAll()
        {
            var aktivnosti = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<Aktivnost>>(aktivnosti));
        }

        [HttpGet("{id}")]
        [Route("api/aktivnost/{id}")]
        public ActionResult<AktivnostDTO> GetActivityById(int id)
        {
            var activity = _repository.GetAktivnostbyId(id);
            if (activity != null)
            {
                return Ok(_mapper.Map<Aktivnost>(activity));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("api/aktivnost/")]
        public ActionResult<CreateAktivnost> CreateActivity(CreateAktivnost createAktivnost)
        {
            var activityModel = _mapper.Map<Aktivnost>(createAktivnost);
            _repository.CreateAktivnost(activityModel);
            _repository.SaveChanges();
            var activityRead = _mapper.Map<AktivnostDTO>(activityModel);

            return CreatedAtRoute(nameof(GetActivityById), new { Id = activityModel.AktivnostId }, activityRead);
        }
        [HttpPut]
        [Route("api/aktivnost/{id}")]
        public ActionResult UpdateAktivnost(int id, CreateAktivnost updateAktivnost)
        {
            var activityModel = _repository.GetAktivnostbyId(id);
            if (activityModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateAktivnost, activityModel);
            _repository.UpdateAktivnost(activityModel);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("api/aktivnost/{id}")]
        public ActionResult DeleteAktivnost(int id)
        {
            var activityModel = _repository.GetAktivnostbyId(id);
            if (activityModel == null)
            {
                return NotFound();
            }
            _repository.DeleteAktivnost(activityModel);
            _repository.SaveChanges();
            return NoContent();

        }



    }
}