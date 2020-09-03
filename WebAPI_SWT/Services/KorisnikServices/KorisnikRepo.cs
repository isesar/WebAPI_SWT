using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Helpers;
using WebAPI_SWT.Models;


namespace WebAPI_SWT.Services.KorisnikServices
{
    public class KorisnikRepo :IKorisnikService
    {
        private readonly STTPContext _context;
     

        public KorisnikRepo(STTPContext context)
        {
            _context = context;
         
        }

        
        public Korisnik Authenticate(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                return null;

            var user = _context.Korisnik.SingleOrDefault(x => x.KorisnickoIme == username);

            // check if username exists
            if (user == null)
                return null;

            // check if password is correct
            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }
         
        public void CreateKorisnik(Korisnik user, string password)
        {
            /*
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Korisnik.Add(user);
                 */
                  
            if (string.IsNullOrWhiteSpace(password))
                throw new AppException("Password is required");

            if (_context.Korisnik.Any(x => x.KorisnickoIme == user.KorisnickoIme))
                throw new AppException("Username \"" + user.KorisnickoIme + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Korisnik.Add(user);
            _context.SaveChanges();

        }

        public void DeleteKorisnik(Korisnik user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            _context.Korisnik.Remove(user);
        }

        public IEnumerable<Korisnik> GetAll()
        {
            return _context.Korisnik.Include(i => i.FakultetNavigation)
                                    .Include(i=>i.FirmaNavigation)
                                    .Include(i=>i.ProjektNavigation)
                                    .Include(i=>i.UlogaNavigation)
                                    .ToList();
        }

        public Korisnik GetKorisnikById(int id)
        {
            return _context.Korisnik.Include(i => i.FakultetNavigation)
                                    .Include(i => i.FirmaNavigation)
                                    .Include(i => i.ProjektNavigation)
                                    .Include(i => i.UlogaNavigation)
                                    .FirstOrDefault(p => p.KorisnikId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateKorisnik(Korisnik userParam, string password = null)
        {
            var user = _context.Korisnik.Find(userParam.KorisnikId);

            if (user == null)
                throw new AppException("User not found");

            // update username if it has changed
            if (!string.IsNullOrWhiteSpace(userParam.KorisnickoIme) && userParam.KorisnickoIme != user.KorisnickoIme)
            {
                // throw error if the new username is already taken
                if (_context.Korisnik.Any(x => x.KorisnickoIme == userParam.KorisnickoIme))
                    throw new AppException("Username " + userParam.KorisnickoIme + " is already taken");

                user.KorisnickoIme = userParam.KorisnickoIme;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userParam.Ime))
                user.Ime = userParam.Ime;

        
            // update password if provided
            if (!string.IsNullOrWhiteSpace(password))
            {
                byte[] passwordHash, passwordSalt;
                CreatePasswordHash(password, out passwordHash, out passwordSalt);

                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
            }

            _context.Korisnik.Update(user);
            _context.SaveChanges();
        }
        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of password hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of password salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }

}
