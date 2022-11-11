using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.src.Entity
{
    public class User
    {
        public Guid Id {get; private set;}
        public string Username {get;private set;}
        public string Email {get;private set;}
        public string Password {get; private set;}
        public string Status {get; private set;}


        public User(string username,string email, string password){
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;
            Status = "Active";
        }
    }
}