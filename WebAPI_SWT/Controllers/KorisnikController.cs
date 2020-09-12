using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using WebAPI_SWT.DTOs.KorisnikDTO;
using WebAPI_SWT.Helpers;
using WebAPI_SWT.Models;
using WebAPI_SWT.Services;
using WebAPI_SWT.Services.KorisnikServices;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace WebAPI_SWT.Controllers
{

    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly IKorisnikService _repository;
        private readonly IMapper _mapper;
        private readonly AppSettings _appSettings;

        public KorisnikController(IKorisnikService repository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _repository = repository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpGet]
        [Authorize(Roles = "Student")]
        [Route("api/korisnik")]
        public ActionResult<IEnumerable<Korisnik>> GetAll()
        {
            var korisnici = _repository.GetAll();

            return Ok(_mapper.Map<IEnumerable<Korisnik>>(korisnici));
        }

        [AllowAnonymous]
        [HttpPost("api/korisnik/authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateDTO model)
        {
            var user = _repository.Authenticate(model.KorisnickoIme, model.Lozinka);
            if (user == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
     {
                    new Claim(ClaimTypes.Name, user.KorisnikId.ToString()),
                    new Claim(ClaimTypes.Role, user.UlogaNavigation.Ime)
     }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return Ok(new
            {
                Id = user.KorisnikId,
                Username = user.Ime,

                Token = tokenString
            });
        }
        [AllowAnonymous]
        [HttpPost("(api/korisnik/register")]
        public IActionResult Register(RegisterDTO model)
        {
            // map model to entity
            var user = _mapper.Map<Korisnik>(model);

            try
            {
                // create user
                _repository.CreateKorisnik(user, user.Lozinka);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
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
        public ActionResult<CreateKorisnikDTO> CreateKorisnik(CreateKorisnikDTO createKorisnik, string password)
        {
            var korisnikModel = _mapper.Map<Korisnik>(createKorisnik);
            _repository.CreateKorisnik(korisnikModel, createKorisnik.Lozinka);
            _repository.SaveChanges();
            var korisnikRead = _mapper.Map<KorisnikDTO>(korisnikModel);
            return CreatedAtAction(nameof(GetKorisnikById), new { Id = korisnikModel.KorisnikId }, korisnikRead);
        }
        [HttpPut]
        [Route("api/korisnik/{id}")]
        public ActionResult UpdateKorisnik(int id, UpdateKorisnikDTO updateKorisnik)
        {
            var korisnikModel = _repository.GetKorisnikById(id);
            if (korisnikModel == null)
            {
                return NotFound();
            }
            _mapper.Map(updateKorisnik, korisnikModel);
            _repository.UpdateKorisnik(korisnikModel, korisnikModel.Lozinka);
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