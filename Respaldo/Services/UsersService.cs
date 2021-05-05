using Respaldo.DTOs;
using Respaldo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Respaldo.Tools;

namespace Respaldo.Services
{
    public class UsersService : DBS
    {
        public User Login(string Username, string Password)
        {
            var pass = Encrypt.GetSHA256(Password);
            return GetAllUsers().Where(w => w.Username ==Username && w.UserPass == pass).FirstOrDefault();
        }

        public IQueryable<User> GetAllUsers()
        {
            return dataContext.Users.Select(s => s);
        }

        public void AddUser(User newUser)
        {
            var newuser = new User()
            {
                Username = newUser.Username,
                UserPass = Encrypt.GetSHA256(newUser.UserPass),
                Email = newUser.Email
            };

            dataContext.Users.Add(newuser);
            dataContext.SaveChanges();
        }

       
       


    }
}