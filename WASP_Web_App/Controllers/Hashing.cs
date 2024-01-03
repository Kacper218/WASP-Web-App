using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WASP_Web_App.Entities;

namespace WASP_Web_App.Controllers {
    public class Hashing
    {
        private readonly PasswordHasher<Auth> _passwordHasher;

        public Hashing(
          )
        {

            _passwordHasher = new PasswordHasher<Auth>();
        }

        public void Login(ref Auth user)
        {
            var hashedPassword = _passwordHasher.HashPassword(user, user.Password);
            user.Password = hashedPassword;

        }


    }
}