using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BEExam.Core.Entities
{
    public class User : IdentityUser
    {
        public User(string name, string surname,string email)
        {
            Name = name;
            Surname = surname;
            Email = email;
            UserName = email;
        }

        public string Name { get; set; }
        public string Surname { get; set; }

    }   
}
