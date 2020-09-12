using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_SWT.Models;

namespace WebAPI_SWT.Helpers
{
    public static class ExtensionMethods
    {
        public static IEnumerable<Korisnik> WithoutPasswords (this IEnumerable<Korisnik> users)
        {
            if (users == null) return null;

            return users.Select(x => x.WithoutPassword());
        }
        public static Korisnik WithoutPassword (this Korisnik user)
        {
            if (user == null) return null;

            user.Lozinka = null;
            return user;
        }
    }
}
