using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_SWT.DTOs.ProjektDTO;
using WebAPI_SWT.Models;
using WebAPI_SWT.Services.KorisnikServices;

namespace WebAPI_SWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjektController : ControllerBase
    {
        private readonly IProjektServices _repository;
        private readonly IMapper _mapper;

        public ProjektController(IProjektServices repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("api/projekt")]
        public ActionResult<IEnumerable<Projekt>> GetAll()
        {
            var projekti = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<Projekt>>(projekti));
        }

        [HttpGet("{id}")]
        [Route("api/projekt/{id}")]
        public ActionResult<ProjektDTO> GetProjektById(int id)
        {
            var projekt = _repository.GetProjektById(id);
            if (projekt != null)
            {
                return Ok(_mapper.Map<Projekt>(projekt));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("api/korisnik/")]
        public ActionResult<CreateProjektDTO> CreateProjekt(CreateProjektDTO createProject)
        {
            var projectModel = _mapper.Map<Projekt>(createProject);
            _repository.CreateProject(projectModel);
            _repository.SaveChanges();
            var projectRead = _mapper.Map<ProjektDTO>(projectModel);
            return CreatedAtRoute(nameof(GetProjektById), new { Id = projectModel.ProjektId }, projectRead);
        }
        [HttpPut]
        [Route("api/projekt/{id}")]
        public ActionResult UpdateProjekt(int id, CreateProjektDTO updateProject)
        {
            var projectModel = _repository.GetProjektById(id);
            if (projectModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateProject, projectModel);
            _repository.UpdateProjekt(projectModel);
            _repository.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        [Route("api/projekt/{id}")]
        public ActionResult DeleteKorisnik(int id)
        {
            var projectModel = _repository.GetProjektById(id);
            if (projectModel == null)
            {
                return NotFound();
            }
            _repository.DeleteProjekt(projectModel);
            _repository.SaveChanges();
            return NoContent();

        }
    }
}